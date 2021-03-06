﻿using System;
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
        DataGridViewTextBoxColumn textBoxCell = null;
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
        /// <summary>
        /// 전체 주문을 보여준다.
        /// </summary>
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
                    dataGridView1.Columns[4].ReadOnly = true;
                }
                con.Close();
            }
        }
        /// <summary>
        /// 해당 발주의 자세한 내용을 나타낸다.
        /// </summary>
        /// <param name="orderNO"></param>
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

        private void btn_Exit_Click(object sender, EventArgs e)
        {
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
            textBoxCell.Dispose();
            OrderedStock();
        }

        private void btn_ReOrder_Click(object sender, EventArgs e)
        {
            dataGridView1_CellDoubleClick(null, null);
            order_From order_ = new order_From(ds2);
            order_.Owner = this;
            order_.Show();
            //this.Close();
        }
    }
}
