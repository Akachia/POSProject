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

namespace TF
{
    public partial class Form_Account : Form
    {
        DataSet ds;
        List<string[]> orderPrice = new List<string[]>();

        public Form_Account()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void Form_Account_Load(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SelectTables", con);
                
                ds = new DataSet();
                adapter.Fill(ds);
                
                DataTable table1 = ds.Tables[0]; // SellDate, ProductName, SellCount, SellPrice, CardWhether
                DataTable table2 = ds.Tables[1]; // OrderDate, OrderTotalPrice

                int cashD = 0; // 일 현금 매출
                int cardD = 0; // 일 카드 매출
                int cashM = 0; // 월 현금 매출
                int cardM = 0; // 월 카드 매출
                int order = 0; // 입고가
                string standardDate = "";
                string orderDate = "";
                string[] orderArr;
                int rowCount = 0;

                foreach (DataRow row in table1.Rows)
                {
                    if (row.ItemArray[4].ToString() == "False")
                    {
                        cashD += int.Parse(row.ItemArray[3].ToString());
                    }
                    else
                    {
                        cardD += int.Parse(row.ItemArray[3].ToString());
                    }
                }

                txtCashD.Text += cashD;
                txtCardD.Text += cardD;
                txtTotalD.Text = (cashD + cardD).ToString();

                foreach (DataRow row in table2.Rows)
                {
                    rowCount += 1;
                    string[] date = row.ItemArray[0].ToString().Split('-');
                    if (orderDate == "")
                    {
                        orderDate = date[0] + " - " + date[1];
                    }

                    if (orderDate == (date[0] + " - " + date[1]))
                    {
                        order += int.Parse(row.ItemArray[1].ToString());
                        if (table2.Rows.Count == rowCount)
                        {
                            orderArr = new string[2];
                            orderArr[0] = orderDate;
                            orderArr[1] = order.ToString();

                            orderPrice.Add(orderArr);
                        }
                    }
                    else
                    {
                        orderArr = new string[2];
                        orderArr[0] = orderDate;
                        orderArr[1] = order.ToString();

                        orderPrice.Add(orderArr);
                        orderDate = date[0] + " - " + date[1];
                        order = int.Parse(row.ItemArray[1].ToString());
                    }
                }

                foreach (DataRow row in table1.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray[1], row.ItemArray[3], row.ItemArray[2]);

                    string[] date = row.ItemArray[0].ToString().Split('-');

                    if (standardDate == "")
                    {
                        standardDate = date[0] + " - " + date[1];
                    }

                    if(standardDate == (date[0] + " - " + date[1]))
                    {
                        if (row.ItemArray[4].ToString() == "False")
                        {
                            cashM += int.Parse(row.ItemArray[3].ToString());
                        }
                        else
                        {
                            cardM += int.Parse(row.ItemArray[3].ToString());
                        }
                    }
                    else
                    {
                        foreach (string[] arr in orderPrice)
                        {
                            if (orderDate == standardDate)
                            {
                                dataGridView2.Rows.Add(standardDate, cashM, cardM, cashM + cardM, order, 0, 0);
                            }
                        }
                        standardDate = date[0] + " - " + date[1];
                        if (row.ItemArray[4].ToString() == "False")
                        {
                            cashM = int.Parse(row.ItemArray[3].ToString());
                        }
                        else
                        {
                            cardM = int.Parse(row.ItemArray[3].ToString());
                        }
                    }
                }
                foreach (string[] arr in orderPrice)
                {
                    if (orderDate == standardDate)
                    {
                        dataGridView2.Rows.Add(standardDate, cashM, cardM, cashM + cardM, order, 0, 0);
                    }
                }
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            string now = DateTime.Now.Year.ToString();

            foreach (string[] arr in orderPrice)
            {
                if (now == DateTime.Now.Year.ToString())
                {
                    chart.Series[0].Points.AddXY(arr[0], int.Parse(arr[1]));
                }
            }
        }
    }
}
