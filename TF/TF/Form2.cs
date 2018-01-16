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
    public partial class Form2 : Form
    {
        DataSet ds;

        public Form2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Test"].ConnectionString))
            {
                con.Open();
                
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("selectDAC", con);
                
                ds = new DataSet();
                adapter.Fill(ds);
                
                DataTable table = ds.Tables[0];

                string[] str = DateTime.Now.ToString().Split('-');

                int cash = 0;
                int card = 0;
                int alba = 100000;
                int rent = 50000;

                foreach (DataRow row in table.Rows)
                {
                    cash += int.Parse(row.ItemArray[4].ToString());
                    card += int.Parse(row.ItemArray[3].ToString());
                }

                dataGridView2.Rows.Add(str[0] + "-" + str[1], cash, card, cash + card, alba, rent, cash + card - alba - rent);

                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
