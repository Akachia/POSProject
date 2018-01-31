using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSproject_KSM
{
    public partial class Form_NewStock : Form
    {
        private Timer timer;
        private string bar = null;
        private char[] cBar;
        private POS_Stock pOS_ = null;
        private Image img = POSproject.Properties.Resources.noImage;
        private List<string> cb_list = new List<string>();

        /// <summary>
        /// 유효성검사 에 쓰일 스트링 변수
        /// </summary>
        private string valid_category;
        private string valid_barcode;
        private string valid_name;

        public Form_NewStock()
        {
            InitializeComponent();
        }

        public Form_NewStock(string id) : this()
        {
            lbl_user.Text = id;
        }

        private void Form_NewStock_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pOS_ = Owner as POS_Stock;
            for (int i = 0; i < 6; i++)
            {
                cb_quantiy.Items.Add(i);
            }
            SelectComboBox();
            lbl_Timer.Text = DateTime.Now.ToLongTimeString();
            timer = new Timer();
            timer.Tick += Timer1_Tick1;
            timer.Interval = 1000;
            timer.Start();
        }

        private void SelectComboBox()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SelectDistinctStock", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr =  cmd.ExecuteReader();

                    while (sdr.Read())
                    {

                            cb_list.Add(sdr["ProductCategory"].ToString());
                    }
                }
                cb_category.DataSource = cb_list;
            }
        }
        
        private void Timer1_Tick1(object sender, EventArgs e)
        {
            lbl_Timer.Text = DateTime.Now.ToLongTimeString();
        }

        private void btn_NCh_Click(object sender, EventArgs e)
        {
            InsertStock();
            pOS_ = Owner as POS_Stock;
            //pOS_.SelectStock("SelectStock");
            this.Close();
        }
        private void InsertStock()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            { 
                con.Open();
                using (SqlCommand cmd = new SqlCommand("InsertStock", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UProductBarcode", bar);
                    cmd.Parameters.AddWithValue("@UProductName", tb_name.Text);
                    cmd.Parameters.AddWithValue("@UProductPrice", tb_price.Text);
                    cmd.Parameters.AddWithValue("@UProductPrimeCost", tb_primePrice.Text);
                    cmd.Parameters.AddWithValue("@UProductQuantity", int.Parse(cb_quantiy.Text));
                    cmd.Parameters.AddWithValue("@UProductCategory", cb_category.Text);
                    ImageConverter converter = new ImageConverter();
                    byte[] bImg = (byte[])converter.ConvertTo(img, typeof(byte[]));
                    cmd.Parameters.AddWithValue("@UProductImage ", bImg);

                    int i = cmd.ExecuteNonQuery();//insert문 1=저장 0=저장 안됨

                    if (i == 1)
                    {
                        MessageBox.Show("저장");
                        con.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("저장 안됨");
                        con.Close();
                        return;
                    }
                }
            }
        }
        private void btn_CC_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.timer.Stop();
            this.Close();
        }

        private void BarcodeFit()
        {
            cBar = tb_barcode.Text.ToArray();

            for (int i = 0; i < 13; i++)
            {
                bar += cBar[i].ToString();
            }
        }

        private void tb_barcode_Leave(object sender, EventArgs e)
        {
            if (tb_barcode.Text.Length >= 13)
            {
                BarcodeFit();
            }
        }

        private void tb_barcode_TextChanged(object sender, EventArgs e)
        {

            string sPattern = "^[0-9]{0,18}$";
            if (tb_barcode.Text.Length <19)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb_barcode.Text, sPattern))
                {
                    valid_barcode = tb_barcode.Text;
                }
                else
                {
                    tb_barcode.Text = valid_barcode;
                    tb_barcode.Select(tb_barcode.Text.Length, tb_barcode.Text.Length);
                    MessageBox.Show("숫자만 입력해주세요");
                }
            }
            else
            {
                tb_barcode.Text = valid_barcode;
                tb_barcode.Select(tb_barcode.Text.Length, tb_barcode.Text.Length);
                MessageBox.Show("인식 가능한 바코드는 최대18자리입니다.");
            }
                    
            if (tb_barcode.TextLength == 18)
            {
                BarcodeFit();
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            pictureBox1.Image = new Bitmap(openFile.FileName);
            img = pictureBox1.Image;
        }

        private void tb_name_TextChanged(object sender, EventArgs e)
        {
            string sPattern = "^[ㄱ-ㅎ가-힣0-9a-zA-Z()]*$";

            if (System.Text.RegularExpressions.Regex.IsMatch(tb_name.Text, sPattern))
            {
                valid_name = tb_name.Text;
            }
            else
            {
                tb_name.Text = valid_name;
                tb_name.Select(tb_name.Text.Length, tb_name.Text.Length);
                MessageBox.Show("괄호를 제외한 특수문자는 입력할 수 없습니다.");
            }
        }

        private void cb_category_TextChanged(object sender, EventArgs e)
        {
            string sPattern = "^[ㄱ-ㅎ가-힣]{0,5}$";

            if (System.Text.RegularExpressions.Regex.IsMatch(cb_category.Text, sPattern))
            {
                valid_category = cb_category.Text;
            }
            else
            {
                cb_category.Text = valid_category;
                cb_category.Select(cb_category.Text.Length, cb_category.Text.Length);
                MessageBox.Show("5자리 이하 한글만 입력해주세요");
            }
        }

        private void tb_price_TextChanged(object sender, EventArgs e)
        {
            string sPattern = "^[0-9]{0,6}$";

            if (System.Text.RegularExpressions.Regex.IsMatch(cb_category.Text, sPattern))
            {
                valid_category = cb_category.Text;
            }
            else
            {
                cb_category.Text = valid_category;
                cb_category.Select(cb_category.Text.Length, cb_category.Text.Length);
                MessageBox.Show("6자리 이하 숫자만 입력해주세요");
            }
        }

        private void tb_primePrice_TextChanged(object sender, EventArgs e)
        {
            string sPattern = "^[0-9]{0,6}$";

            if (System.Text.RegularExpressions.Regex.IsMatch(cb_category.Text, sPattern))
            {
                valid_category = cb_category.Text;
            }
            else
            {
                cb_category.Text = valid_category;
                cb_category.Select(cb_category.Text.Length, cb_category.Text.Length);
                MessageBox.Show("6자리 이하 숫자만 입력해주세요");
            }
        }
    }
}
