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
    public partial class Form_Preferences : Form
    {
        public Form_Preferences()
        {
            InitializeComponent();
        }

        private void lblStoreOwner_Load(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SelectPreferences", con);
                
                con.Open();

                SqlCommand cmd = new SqlCommand("SelectPreferences", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    txtStoreName.Text = sdr.GetString(0);
                    txtBusinessNo.Text = sdr.GetString(1);
                    txtOwner.Text = sdr.GetString(2);
                    txtAddress.Text = sdr.GetString(3);
                    txtPhoneNum.Text = sdr.GetString(4);
                }
                sdr.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();

                using (var cmd = new SqlCommand("ModifyPreferences", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@StoreName", txtStoreName.Text);
                    cmd.Parameters.AddWithValue("@BusinessNo", txtBusinessNo.Text);
                    cmd.Parameters.AddWithValue("@StoreOwner", txtOwner.Text);
                    cmd.Parameters.AddWithValue("@Addr", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@CallNumber", txtPhoneNum.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("매장 정보가 수정되었습니다");
                    this.Close();
                }
            }
        }
    }
}
