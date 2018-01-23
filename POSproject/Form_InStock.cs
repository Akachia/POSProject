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

namespace POSproject_KSM
{
    
    public partial class Form_InStock : Form
    {
        DataSet ds = null;
        public Form_InStock()
        {
            InitializeComponent();
        }

        private void btn_BarCh_Click(object sender, EventArgs e)
        {
            
            ds = new DataSet();
            ds.Clear();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SelectDetailOrder2", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SOrderBarcode", decimal.Parse(tb_Barcode.Text));
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();

                    dataAdapter.SelectCommand = cmd;

                    dataAdapter.Fill(ds);
                    lv_OrderCh.Clear();
                    lv_OrderCh.View = View.Details;
                    lv_OrderCh.GridLines = true;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                       // MessageBox.Show(dr["발주번호"].ToString());
                        ListViewItem listitem = new ListViewItem(dr["발주번호"].ToString());
                        DateTime date = (DateTime)dr["발주날짜"];
                        listitem.SubItems.Add(date.ToShortDateString());
                        listitem.SubItems.Add(dr["상품번호"].ToString());
                        listitem.SubItems.Add(dr["이름"].ToString());
                        listitem.SubItems.Add(dr["가격"].ToString());
                        listitem.SubItems.Add(dr["원가"].ToString());
                        listitem.SubItems.Add(dr["발주수량"].ToString());
                        lv_OrderCh.Items.Add(listitem);
                    }
                    lv_OrderCh.Columns.Add("발주번호", 60, HorizontalAlignment.Center);
                    lv_OrderCh.Columns.Add("발주날짜", 120, HorizontalAlignment.Center);
                    lv_OrderCh.Columns.Add("상품번호", 60, HorizontalAlignment.Center);
                    lv_OrderCh.Columns.Add("이름", 120, HorizontalAlignment.Center);
                    lv_OrderCh.Columns.Add("가격", 40, HorizontalAlignment.Center);
                    lv_OrderCh.Columns.Add("원가", 40, HorizontalAlignment.Center);
                    lv_OrderCh.Columns.Add("발주수량", 60, HorizontalAlignment.Center);
                    lv_OrderCh.EndUpdate();
                }
                con.Close();
            }
        }

        private void AddStockOrder()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
                {
                    con.Open();
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        using (SqlCommand cmd = new SqlCommand("UpdateStock2", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@UProductNo", int.Parse(item.ItemArray[2].ToString()));
                            cmd.Parameters.AddWithValue("@UProductQuantity", int.Parse(item.ItemArray[6].ToString()));

                            int i = cmd.ExecuteNonQuery();
                        }
                    }
                    using (SqlConnection con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
                    {
                        con2.Open();
                        using (SqlCommand cmd = new SqlCommand("UpdateOrders2", con2))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@UOrderNo", int.Parse(ds.Tables[0].Rows[0].ItemArray[0].ToString()));
                            int i = cmd.ExecuteNonQuery();
                            if (i > 0)
                            {
                                MessageBox.Show("데이터 반영");
                                POS_Stock pOS_ = new POS_Stock();
                                pOS_.SelectStock("SelectStock", pOS_.dataGridView1);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("데이터 반영 실패");
                                return;
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("데이터를 확인해 주세요");
            }
        }
        private void btn_check_Click(object sender, EventArgs e)
        {
            AddStockOrder();
        }
        
        private void tb_Barcode_TextChanged(object sender, EventArgs e)
        {
            if (tb_Barcode.Text.Length == 14)
            {
                btn_BarCh_Click(null,null);
            }
        }
    }
}
