using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSproject_KSM
{
    public partial class OrderDetail : Form
    {
        Timer timer;
        int switchOrderView = 0;
        DataSet ds1 = null;
        DataSet ds2 = null;
        DataGridViewTextBoxColumn textBoxCell = null;
        SqlDataAdapter dataAdapter = null;
        public OrderDetail()
        {
            InitializeComponent();
        }

        public OrderDetail(string id) : this()
        {
            lbl_User.Text = id;
        }

        private SqlDataAdapter GetSqlDataAdapter()
        {
            if (this.dataAdapter == null)
            {
                return new SqlDataAdapter();
            }
            else
            {
                return this.dataAdapter;
            }
        }

        private DataSet GetDataSet(DataSet ds)
        {
            if (ds == null)
            {
                return new DataSet();
            }
            else
            {
                ds.Clear();
                return ds;
            }
        }

        private void OrderDetail_Load(object sender, EventArgs e)
        {

            label1.Text = DateTime.Now.ToLongTimeString();
            timer = new Timer();
            timer.Tick += Timer1_Tick1;
            timer.Start();

            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            OrderedStock();

        }

        private void Timer1_Tick1(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        /// <summary>
        /// 전체 주문을 보여준다.
        /// </summary>
        private void OrderedStock()
        {
            switchOrderView = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                ds1 = GetDataSet(ds1);

                con.Open();
                using (SqlCommand cmd = new SqlCommand("SelectOrders", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = GetSqlDataAdapter();
                    dataAdapter.SelectCommand = cmd;

                    dataAdapter.Fill(ds1);

                    dataGridView1.DataSource = ds1.Tables[0];
                    dataGridView1.Columns[4].ReadOnly = true;
                }
                con.Close();
            }
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                //col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }
        /// <summary>
        /// 해당 발주의 자세한 내용을 나타낸다.
        /// </summary>
        /// <param name="orderNO"></param>
        private void DetailOrderedStock(int orderNO)
        {
            switchOrderView = 1;
            ds2 = GetDataSet(ds2);
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SelectDetailOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SOrderNo", orderNO);
                    SqlDataAdapter dataAdapter = GetSqlDataAdapter();

                    dataAdapter.SelectCommand = cmd;

                    dataAdapter.Fill(ds2);

                    dataGridView1.DataSource = ds2.Tables[0];
                }

            }
            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.timer.Stop();
            this.Dispose();
            this.Close();
        }
        /// <summary>
        /// 해당 셀을 더블클릭하면 세부 내역으로 들어가는 이벤트 함수이다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[7].IsDataBound)
            {
                int orderNo = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                DetailOrderedStock(orderNo);
                textBoxCell = new DataGridViewTextBoxColumn();
                textBoxCell.Width = 75;
                textBoxCell.HeaderText = "발주 금액";
                dataGridView1.Columns.Insert(7, textBoxCell);

                foreach (DataGridViewRow item in dataGridView1.Rows)
                {
                    int tt = (int)item.Cells[5].Value * (int)item.Cells[6].Value;
                    item.Cells[7].Value = tt.ToString() + "원";
                }
            }
        }
        /// <summary>
        /// 다시 전체 발주목록으로 돌아가는 버튼 클릭이벤트함수이다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_orderb_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.RemoveAt(7);
            //textBoxCell.Dispose();
            OrderedStock();
        }

        private void btn_ReOrder_Click(object sender, EventArgs e)
        {
            dataGridView1_CellDoubleClick(null, null);
            order_From order_ = new order_From(ds2, lbl_User.Text);
            order_.Owner = this;
            order_.FormClosed += Order__FormClosed;
            //this.Visible = false;
            order_.Show();
            //this.Close();
        }

        private void Order__FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = true;
        }

        private void btn_OrderDel_Click(object sender, EventArgs e)
        {           
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DeleteOrders", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        cmd.Parameters.AddWithValue("@DOrderNo", dataGridView1.CurrentRow.Cells[0].Value);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("발주할 데이터가 없습니다.");
                    }
                    //상세 발주 내역이면 물품을 삭제하고 전체 발주 내역에서는 전체 발주내역이 삭제되도록 한다.
                    if (switchOrderView == 1)
                    {
                        cmd.Parameters.AddWithValue("@DProductNo", dataGridView1.CurrentRow.Cells[2].Value);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@DProductNo", 0);
                    }
                    //MessageBox.Show(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    int c = cmd.ExecuteNonQuery();
                    
                    if (c == 0)
                    {
                        MessageBox.Show("반영실패");
                    }
                    else
                    {
                        MessageBox.Show("반영완료");
                    }
                }
            }
            OrderedStock();
        }

        private void btn_Prod_Click(object sender, EventArgs e)
        {
            switchOrderView = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                ds1 = GetDataSet(ds1);

                con.Open();
                using (SqlCommand cmd = new SqlCommand("SelectDetailOrderTerm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SDate1", dateStart.Value);
                    cmd.Parameters.AddWithValue("@SDate2", dateEnd.Value);
                    SqlDataAdapter dataAdapter = GetSqlDataAdapter();
                    dataAdapter.SelectCommand = cmd;

                    dataAdapter.Fill(ds1);

                    dataGridView1.DataSource = ds1.Tables[0];
                }
                con.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DetailOrderedStock((int)dataGridView1.CurrentRow.Cells[0].Value);
        }
    }
}
