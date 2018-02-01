using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace POSproject
{
    public partial class Form_Preferences : Form
    {
        private object valid_category;

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
                    txtStoreName.Text = sdr.GetString(2);
                    txtBusinessNo.Text = sdr.GetString(0);
                    txtOwner.Text = sdr.GetString(3);
                    txtAddress.Text = sdr.GetString(1);
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

                bool ownerValid = false;
                bool phoneValid = false;
                bool businessNoValid = false;
                bool addrValid = false;
                bool nameValid = false;
                string sPattern = "^[가-힣]{0,5}$";

                if (txtStoreName.Text == "")
                {
                    MessageBox.Show("매장 이름을 입력해주세요");
                }
                else
                {
                    nameValid = true;
                }

                if (txtAddress.Text == "")
                {
                    MessageBox.Show("주소를 입력해주세요");
                }
                else
                {
                    addrValid = true;
                }

                if (txtOwner.Text == "")
                {
                    MessageBox.Show("대표자 이름을 입력해주세요");
                }
                else
                {
                    if (Regex.IsMatch(txtOwner.Text, "^[ㄱ-ㅎㅏ-ㅣ]$"))
                    {
                        MessageBox.Show("이름을 제대로 입력해주세요");
                    }
                    else
                    {
                        if (Regex.IsMatch(txtOwner.Text, sPattern))
                        {
                            ownerValid = true;
                        }
                        else
                        {
                            txtOwner.Text = "";
                            MessageBox.Show("이름을 제대로 입력해주세요");
                        }
                    }
                }

                Regex regex1 = new Regex(@"0\d{2}-\d{3,4}-\d{4}");
                Match phone = regex1.Match(txtPhoneNum.Text);

                if (phone.Success)
                {
                    phoneValid = true;
                }
                else
                {
                    MessageBox.Show("전화번호를 제대로 입력해 주세요");
                }

                Regex regex2 = new Regex(@"\d{3}-\d{2}-\d{5}");
                Match businessNo = regex2.Match(txtBusinessNo.Text);

                if (businessNo.Success)
                {
                    businessNoValid = true;
                }
                else
                {
                    MessageBox.Show("사업자번호를 제대로 입력해 주세요");
                }

                if (ownerValid && phoneValid && businessNoValid && addrValid && nameValid)
                {
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
}