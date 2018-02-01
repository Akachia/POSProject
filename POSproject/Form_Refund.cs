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
        int checkTakeBack = 0;

        public Form_Refund()
        {
            InitializeComponent();
        }

        private void Form_Refund_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            dataGridView2.AllowUserToAddRows = false;
            HeaderSet();
        }

        public void HeaderSet()
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGridView2.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e) // 거래번호로 판매기록 조회
        {
            if (string.IsNullOrEmpty(txtSellNo.Text))
            {
                return;
            }

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
                HeaderSet();
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

        private int CheckRefund(int prodNo)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand("CheckTakeBack", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sellNo", long.Parse(txtSellNo.Text));
                    cmd.Parameters.AddWithValue("@prodNo", prodNo);
                    checkTakeBack = (int)cmd.ExecuteScalar();
                    return checkTakeBack;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prodNo">상품번호</param>
        /// <param name="reCount">환불하고자 하는 수량</param>
        private void ModRefund(int prodNo, int reCount) // 이미 존재하는 동일한 거래번호-상품에 대한 환불 내용 수정
        {
            int sellC = 0;
            bool modType = false;
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand("SellCountFromSales", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sellNo", long.Parse(txtSellNo.Text));
                    cmd.Parameters.AddWithValue("@prodNo", prodNo);

                    sellC = (int)cmd.ExecuteScalar(); // 상품 잔여 수량
                    if (sellC == reCount)
                    {
                        modType = true;
                    }
                }
                if (modType) // true = allmod
                {
                    using (var cmd = new SqlCommand("UpdateSalesModRefund", con)) // 판매테이블에서 해당 거래번호의 상품번호의 수량, 판매금액 수정
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sellNo", long.Parse(txtSellNo.Text));
                        cmd.Parameters.AddWithValue("@prodNo", prodNo);
                        cmd.ExecuteReader();

                        con.Close();
                    }
                }
                else
                {
                    using (var cmd = new SqlCommand("UpdateSalesRefund", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sellNo", long.Parse(txtSellNo.Text));
                        cmd.Parameters.AddWithValue("@prodNo", prodNo);
                        cmd.Parameters.AddWithValue("@Count", sellC);
                        cmd.Parameters.AddWithValue("@reCount", reCount);
                        cmd.ExecuteReader();

                        con.Close();
                    }
                }
                con.Open();
                using (var cmd = new SqlCommand("ProdCntUp", con)) // 상품 수량 증가
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductNo", prodNo);
                    cmd.Parameters.AddWithValue("@ProductCount", reCount);
                    cmd.ExecuteReader();

                    con.Close();
                }
                con.Open();
                using (var cmd = new SqlCommand("ProdSalesVolDown", con)) // 누적 판매 감소
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductNo", prodNo);
                    cmd.Parameters.AddWithValue("@ProductCount", reCount);
                    cmd.ExecuteReader();

                    con.Close();
                }
                con.Open();
                using (var cmd = new SqlCommand("ModTakeBack", con)) // 기존 존재하는 상품번호-거래번호에서 수량 업데이트
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sellNo", long.Parse(txtSellNo.Text));
                    cmd.Parameters.AddWithValue("@prodNo", prodNo);
                    cmd.Parameters.AddWithValue("@reCount", reCount);
                    cmd.ExecuteReader();
                }
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
                using (var cmd = new SqlCommand("ProdCntUp", con)) // 상품 수량 증가
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductNo", prodNo);
                    cmd.Parameters.AddWithValue("@ProductCount", reCount);
                    cmd.ExecuteReader();

                    con.Close();
                }
                con.Open();
                using (var cmd = new SqlCommand("ProdSalesVolDown", con)) // 누적 판매 감소
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ProductNo", prodNo);
                    cmd.Parameters.AddWithValue("@ProductCount", reCount);
                    cmd.ExecuteReader();

                    con.Close();
                }
                con.Open();
                using (var cmd = new SqlCommand("InsertRefund", con)) // 환불테이블에 저장
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sellNo", long.Parse(txtSellNo.Text));
                    cmd.Parameters.AddWithValue("@prodNo", prodNo);
                    cmd.Parameters.AddWithValue("@reCount", reCount);
                    cmd.ExecuteReader();

                    con.Close();
                }
            }
        }

        private void btnRecount_Click(object sender, EventArgs e) // 선택상품 일부 환불
        {
            if (string.IsNullOrEmpty(txtReCount.Text))
            {
                return;
            }

            try
            {
                int Count = (int)dataGridView1.CurrentRow.Cells[2].Value; // 기존 수량 보존
                int reCount = int.Parse(txtReCount.Text); // 반품할 물품 수량

                // 환불할 물품 수량이 기존수량보다 많을경우
                if (Count < reCount)
                {
                    MessageBox.Show("입력 수량을 다시 확인해주세요.");
                    txtReCount.Text = "";
                    return;
                }
                
                if (CheckRefund((int)dataGridView1.CurrentRow.Cells[0].Value) == 0) // 이전에 환불된 동일한 상품이 없다면
                {
                    Refund((int)dataGridView1.CurrentRow.Cells[0].Value, Count, reCount);
                }
                else
                {
                    ModRefund((int)dataGridView1.CurrentRow.Cells[0].Value, reCount);
                }

                dataGridView1.CurrentRow.Cells[2].Value = Count - reCount;

                MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " 상품이 " + reCount.ToString() + "개 환불 처리 되었습니다.");
                
                dataGridView1.ClearSelection();

                ds2.Clear();
                dataGridView2.DataSource = null;
                SelectRefund(); // 환불기록 새로고침
                HeaderSet();

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
            if (dataGridView1.Rows.Count == 0)
            {
                txtSellNo.Focus();
                return;
            }

            try
            {
                int Count = (int)dataGridView1.CurrentRow.Cells[2].Value; // 기존 수량, 반품할 수량
                
                if (CheckRefund((int)dataGridView1.CurrentRow.Cells[0].Value) == 0)
                {
                    Refund((int)dataGridView1.CurrentRow.Cells[0].Value, Count, Count); 
                }
                else
                {
                    ModRefund((int)dataGridView1.CurrentRow.Cells[0].Value, Count);
                }

                dataGridView1.CurrentRow.Cells[2].Value = 0;

                MessageBox.Show(dataGridView1.CurrentRow.Cells[1].Value.ToString() + " 상품이 " + Count.ToString() + "개 환불 처리 되었습니다.");

                dataGridView1.ClearSelection();

                // 환불기록 새로고침
                ds2.Clear();
                dataGridView2.DataSource = null;
                SelectRefund();
                HeaderSet();

                // 동일 거래번호로 이전에 환불한 기록 그리드뷰 만들어서 출력하기
            }
            catch (Exception g)
            {
                MessageBox.Show(g.Message);
                MessageBox.Show("오류발생 - 상품이 선택되지 않음.");
                return;
            }
        }

        private void btnRefundAll_Click(object sender, EventArgs e) // 모든 상품 환불
        {
            if (dataGridView1.Rows.Count == 0)
            {
                txtSellNo.Focus();
                return;
            }

            try
            {
                //MessageBox.Show(rows.ToString());
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    int prodNo = (int)dataGridView1.Rows[i].Cells[0].Value;
                    int count = (int)dataGridView1.Rows[i].Cells[2].Value;

                    if (CheckRefund(prodNo) == 0)
                    {
                        Refund(prodNo, count, count); 
                    }
                    else
                    {
                        ModRefund(prodNo, count);
                    }

                    dataGridView1.Rows[i].Cells[2].Value = 0;
                }
                MessageBox.Show("모든 상품이 환불 처리 되었습니다.");

                dataGridView1.ClearSelection();

                ds2.Clear();
                dataGridView2.DataSource = null;
                SelectRefund();
                HeaderSet();
            }
            catch (Exception g)
            {
                MessageBox.Show(g.ToString());
                MessageBox.Show("오류발생 - 환불되지 않음.");
                return;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtSellNo.Text = "";
            txtSellNo.Focus();
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}