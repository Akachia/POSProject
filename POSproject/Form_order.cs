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
/// <summary>
/// 자주 발주하는 제품 선택 -> 제품테이블에 데이터가 있어야 되서 안됨
/// 이 폼은 재고 테이블에서 데이터를 가져와 발주 데이터를 작성하고 발주 테이블에 커밋하는 역할을 한다.
/// </summary>
namespace POSproject_KSM
{
    public partial class order_From : Form
    {
        DataTable ds = null;
        DataTable ds2 = null;
        int orderTtl_Price = 0;
        int orderTtlSell_Price = 0;
        decimal barcodeNo = 0;

        public order_From()
        {
            InitializeComponent();
        }

        public order_From(string ds) : this()
        {
            lbl_User.Text = ds;
        }
        /// <summary>
        /// Dvg에 콤보박스를 만드는 함수
        /// </summary>
        private void MakeComboCell()
        {
            DataGridViewComboBoxColumn boxColumn = new DataGridViewComboBoxColumn();
            List<string> columnList = new List<string>();

            DataGridViewComboBoxColumn boxColumn1 = new DataGridViewComboBoxColumn();
            List<string> columnList1 = new List<string>();
            for (int i = 0; i < 16; i++)
            {
                columnList.Add(i.ToString() + "개");
            }
            for (int i = 0; i < 21; i++)
            {
                columnList1.Add(i.ToString() + "box");
            }

            boxColumn.DataSource = columnList;
            boxColumn.Width = 75;
            boxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            boxColumn.HeaderText = "발주 개수";
            dataGridView1.Columns.Insert(5, boxColumn);
            boxColumn1.DataSource = columnList1;
            boxColumn1.Width = 75;
            boxColumn1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            boxColumn1.HeaderText = "발주 개수(box)";
            dataGridView1.Columns.Insert(5, boxColumn1);
            // 데이터가 없어서 초기 데이터를 설정한다.
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                item.Cells[5].Value = "0box";
                item.Cells[6].Value = "0개";
            }

            dataGridView1.Columns[1].HeaderText = "상품번호";
            dataGridView1.Columns[2].HeaderText = "이름";
            dataGridView1.Columns[3].HeaderText = "가격";
            dataGridView1.Columns[4].HeaderText = "원가";
            dataGridView1.Columns[7].HeaderText = "현재수량";
        }

        private decimal GenBarcode(decimal bar)
        {
            string str = "1880";
            string str2;
            DateTime date = DateTime.Now;
            str2 = date.ToShortDateString().Split('-')[0];
            str2 += date.ToShortDateString().Split('-')[1];
            str2 += date.ToShortDateString().Split('-')[2];
            str2 = str2.Substring(2);
            str += str2;

            str += bar.ToString().Substring(10);
            MessageBox.Show(str);
            return decimal.Parse(str);
        }

        /// <summary>
        /// 전체 발주가격을 계산하는 메서드
        /// </summary>
        private void Order_TtlPrice_Sum()
        {
            orderTtl_Price = 0;
            orderTtlSell_Price = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                orderTtl_Price += int.Parse(item.Cells[4].Value.ToString());
            }
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                orderTtlSell_Price += int.Parse(item.Cells[3].Value.ToString());
            }
            string ttlPrice = String.Format("{0:#,###}", orderTtl_Price);
            string ttlSellPrice = String.Format("{0:#,###}", orderTtlSell_Price);

            lbl_TtlPrice.Text = ttlPrice + "원";
            lbl_TtlsellPrice.Text = ttlSellPrice + "원";
        }

        private void order_From_Load(object sender, EventArgs e)
        {
            POS_Stock pOS_ = Owner as POS_Stock;

            ds = pOS_.MakeOrderTable().Copy();
            if (ds2 != null)
            {
                ds2.Clear();
            }
            ds2 = pOS_.MakeOrderTable();
            dataGridView1.DataSource = ds2;

            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            label1.Text = pOS_.label1.Text;
            Timer timer = new Timer();
            timer.Tick += Timer1_Tick1;
            timer.Start();
            MakeComboCell();
            //수량을 콤보박스로 표현하기 
            //dataGridView1.Columns["Column2"].DisplayIndex = 4;
        }
        /// <summary>
        /// 그리드뷰에서 셀의 값이 변경되면 실행되는 함수 콤보박스만 해당된다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.GetType() == new DataGridViewComboBoxCell().GetType())
                {
                    int numVal = int.Parse(ds.Rows[dataGridView1.CurrentRow.Index].ItemArray[2].ToString());
                    int numVal1 = int.Parse(ds.Rows[dataGridView1.CurrentRow.Index].ItemArray[3].ToString());
                    int boxNum = int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString().Split('b')[0]);
                    int boxNum1 = int.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString().Split('개')[0]);

                    if (boxNum == 0 && boxNum1 == 0)
                    {
                        dataGridView1.CurrentRow.Cells[3].Value = numVal;
                        dataGridView1.CurrentRow.Cells[4].Value = numVal1;
                    }
                    else
                    {
                        dataGridView1.CurrentRow.Cells[3].Value = (boxNum * 15) * numVal + (boxNum1 * numVal);
                        dataGridView1.CurrentRow.Cells[4].Value = (boxNum * 15) * numVal1 + (boxNum1 * numVal1);
                    }
                    Order_TtlPrice_Sum();
                }
                //발주 가격과 판매가격을 알려주는 함수
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("발주 물건을 선택해 주세요!","알림", MessageBoxButtons.OK , MessageBoxIcon.Warning);
                this.Close();
            }
        }
        // 타이머 함수
        private void Timer1_Tick1(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        /// <summary>
        /// 모든 채크박스를 클릭해주는 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_allCk_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)item.Cells[0];
                checkBoxCell.Value = true;
            }
        }
        /// <summary>
        /// 보내기 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Send_Click(object sender, EventArgs e)
        {
            DataSet oDs = new DataSet();
            int last_idx = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                MessageBox.Show(last_idx.ToString());
                using (SqlCommand cmd = new SqlCommand("SelectLastOrderNo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = cmd;

                    dataAdapter.Fill(oDs);
                    last_idx = int.Parse(oDs.Tables[0].Rows[0].ItemArray[0].ToString()) + 1;
                    barcodeNo = decimal.Parse(oDs.Tables[0].Rows[0].ItemArray[5].ToString()) + 1;
                }
            }
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("InsertOrders2", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UOrderTtlPrice", orderTtlSell_Price);
                    cmd.Parameters.AddWithValue("@UOrderCustomer", lbl_User.Text);
                    cmd.Parameters.AddWithValue("@UOrderBarcode", GenBarcode(barcodeNo));

                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("발주 성공");
                    }
                    else
                    {
                        MessageBox.Show("통신실패 다시 해주세요");
                    }
                }
            }
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    using (SqlCommand cmd = new SqlCommand("InsertStockOrder", con))
                    {
                        DataGridViewCheckBoxCell dgvCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[j].Cells[0];
                        if (dgvCell.Value != new DataGridViewCheckBoxCell().FalseValue)
                        {
                            //MessageBox.Show(" : " + (dgvCell.RowIndex +1).ToString());
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@IOrderNo", last_idx);
                            cmd.Parameters.AddWithValue("@IProductNo", dataGridView1.Rows[j].Cells[1].Value);

                            int boxNum = int.Parse(dataGridView1.Rows[j].Cells[5].Value.ToString().Split('b')[0]);
                            int boxNum1 = int.Parse(dataGridView1.Rows[j].Cells[6].Value.ToString().Split('개')[0]);

                            cmd.Parameters.AddWithValue("@IProductOrderQuantity", ((boxNum * 15) + boxNum1));
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("발주 성공");
                            }
                            else
                            { 
                                MessageBox.Show("통신실패 다시 해주세요");
                            }
                        }
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
