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

        public Form_Account()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //new Form1().Show();
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
                DataTable table2 = ds.Tables[1]; // OrderTotalPrice, UserPay, WorkTime

                int cashD = 0;
                int cardD = 0;
                int cashM = 0;
                int cardM = 0;
                string standardDate = "";

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
                        dataGridView2.Rows.Add(standardDate, cashM, cardM, cashM + cardM, 0, 0, 0);
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

                dataGridView2.Rows.Add(standardDate, cashM, cardM, cashM + cardM, 0, 0, 0);

                //this.dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
