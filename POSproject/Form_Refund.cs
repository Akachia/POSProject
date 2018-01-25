using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSproject
{
    public partial class Form_Refund : Form
    {
        DataSet ds = new DataSet();
        DataSet ds2 = new DataSet();
        SqlDataAdapter adapter = new SqlDataAdapter();

        public Form_Refund()
        {
            InitializeComponent();
        }

        private void Form_Refund_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) // 거래번호로 판매기록 조회
        {
            ds.Clear();
            ds2.Clear();
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand("SelectSellNo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sellNo", long.Parse(txtSellNo.Text));

                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];
                    
                    con.Close();
                }
                con.Open();
                SelectRefund();
            }
        }

        public void SelectRefund()
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                using (var cmd = new SqlCommand("SelectSellNoRefund", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sellNo", long.Parse(txtSellNo.Text));

                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds2);

                    dataGridView2.DataSource = ds2.Tables[0];
                }
            }
        }

        private void txtTotalPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        public void Refund(int prodNo, int Count, int reCount)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand("UpdateSalesRefund", con)) // 판매테이블에서 해당 거래번호의 상품번호의 수량, 판매금액 수정
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sellNo", long.Parse(txtSellNo.Text));
                    cmd.Parameters.AddWithValue("@prodNo", prodNo);
                    cmd.Parameters.AddWithValue("@Count", Count);
                    cmd.Parameters.AddWithValue("@reCount", reCount);
                    cmd.ExecuteReader();

                    con.Close();
                }
                con.Open();
                using (var cmd = new SqlCommand("InsertRefund", con)) // 환불테이블에 저장
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sellNo", long.Parse(txtSellNo.Text));
                    cmd.Parameters.AddWithValue("@prodNo", (int)dataGridView1.CurrentRow.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@reCount", reCount);
                    cmd.ExecuteReader();

                    con.Close();
                }
                con.Open();
                using (var cmd = new SqlCommand("ProdCntUp", con)) // 상품 수량 증가
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductNo", (int)dataGridView1.CurrentRow.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@ProductCount", reCount);
                    cmd.ExecuteReader();

                    con.Close();
                }
                con.Open();
                using (var cmd = new SqlCommand("ProdSalesVolDown", con)) // 누적 판매 감소
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductNo", (int)dataGridView1.CurrentRow.Cells[0].Value);
                    cmd.Parameters.AddWithValue("@ProductCount", reCount);
                    cmd.ExecuteReader();

                    con.Close();
                }
            }
        }

        private void btnRecount_Click(object sender, EventArgs e) // 선택상품 일부 반품
        {
            try
            {
                int Count = (int)dataGridView1.CurrentRow.Cells[2].Value; // 기존 수량 보존
                int reCount = int.Parse(txtReCount.Text); // 반품할 물품 수량

                // 반품할 물품 수량이 기존수량보다 많을경우
                if (Count < reCount)
                {
                    MessageBox.Show("입력 수량을 다시 확인해주세요.");
                    txtReCount.Text = "";
                    return;
                }

                dataGridView1.CurrentRow.Cells[2].Value = Count - reCount;

                Refund((int)dataGridView1.CurrentRow.Cells[0].Value, Count, reCount);

                MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " 상품이 " + reCount.ToString() + "개 환불 처리 되었습니다.");
                
                dataGridView1.ClearSelection();

                ds2.Clear();
                dataGridView2.DataSource = null;
                SelectRefund(); // 환불기록 새로고침

                // 동일 거래번호로 이전에 환불한 기록 그리드뷰 만들어서 출력하기
            }
            catch (Exception)
            {
                MessageBox.Show("오류발생 - 환불되지 않음.");
                return;
            }
        }

        private void btnSelectRefund_Click(object sender, EventArgs e) // 선택한 상품 모두 환불
        {
            try
            {
                int Count = (int)dataGridView1.CurrentRow.Cells[2].Value; // 기존 수량, 반품할 수량

                dataGridView1.CurrentRow.Cells[2].Value = 0;

                Refund((int)dataGridView1.CurrentRow.Cells[0].Value, Count, Count);

                MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " 상품이 " + Count.ToString() + "개 환불 처리 되었습니다.");

                dataGridView1.ClearSelection();

                // 환불기록 새로고침
                ds2.Clear();
                dataGridView2.DataSource = null;
                SelectRefund();

                // 동일 거래번호로 이전에 환불한 기록 그리드뷰 만들어서 출력하기
            }
            catch (Exception)
            {
                MessageBox.Show("오류발생 - 환불되지 않음.");
                return;
            }
        }

        private void btnRefundAll_Click(object sender, EventArgs e) // 모든 상품 환불
        {
            try
            {
                int rows = dataGridView1.Rows.Count;
                MessageBox.Show(rows.ToString());
                for (int i = 0; i < rows; i++)
                {
                    int prodNo = (int)dataGridView1.Rows[i].Cells[0].Value;
                    int count = (int)dataGridView1.Rows[i].Cells[2].Value;
                    dataGridView1.Rows[i].Cells[2].Value = 0;

                    Refund(prodNo, count, count);
                }
                MessageBox.Show("모든 상품이 환불 처리 되었습니다.");

                dataGridView1.ClearSelection();

                ds2.Clear();
                dataGridView2.DataSource = null;
                SelectRefund();
            }
            catch (Exception)
            {
                MessageBox.Show("오류발생 - 환불되지 않음.");
                return;
            }
        }
    }
}