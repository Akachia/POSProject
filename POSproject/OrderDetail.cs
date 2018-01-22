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
        DataSet ds = null;
        DataSet ds2 = null;
        public OrderDetail()
        {
            InitializeComponent();
            
        }

        private void OrderDetail_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dataGridView2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            OrderedStock();
        }

        private void OrderedStock()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                ds = new DataSet();

                con.Open();
                using (SqlCommand cmd = new SqlCommand("SelectOrders", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = cmd;

                    dataAdapter.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];
                }
                con.Close();
            }
        }

        private void DetailOrderedStock(int orderNO)
        {
            ds2 = new DataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {       
                using (SqlCommand cmd = new SqlCommand("SelectDetailOrder", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SOrderNo",orderNO);
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();

                    dataAdapter.SelectCommand = cmd;

                    dataAdapter.Fill(ds2);

                    dataGridView1.DataSource = ds2.Tables[0];
                }
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click_1(object sender, EventArgs e)
        {
            int orderNo = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DetailOrderedStock(orderNo);
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int orderNo = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            DetailOrderedStock(orderNo);
        }

        private void btn_orderb_Click(object sender, EventArgs e)
        {
            OrderedStock();
        }
    }
}
