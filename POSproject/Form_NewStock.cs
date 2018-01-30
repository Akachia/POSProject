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
        string bar = null;
        char[] cBar;
        POS_Stock pOS_ = null;
        // 폐기 1, 등록 0
        string ProductNO = null;
        Image img = POSproject.Properties.Resources.noImage;
        int disOrNew;
        public Form_NewStock()
        {
            InitializeComponent();
        }

        public Form_NewStock(string id, int i) : this()
        {
            lbl_user.Text = id;
            disOrNew = i;
        }

        private void Form_NewStock_Load(object sender, EventArgs e)
        {
            pOS_ = Owner as POS_Stock;

            //lbl_Timer.Text = pOS_.label1.Text;
            Timer timer = new Timer();
            timer.Tick += Timer1_Tick1;
            timer.Interval = 1000;
            timer.Start();
            if (disOrNew == 1)
            {
                tb_category.Enabled = false;
                tb_name.Enabled = false;
                tb_price.Enabled = false;
                tb_primePrice.Enabled = false;
            }
        }

        private void Timer1_Tick1(object sender, EventArgs e)
        {
            lbl_Timer.Text = DateTime.Now.ToLongTimeString();
        }

        private void btn_NCh_Click(object sender, EventArgs e)
        {
            if (disOrNew == 0)
            {
                InsertStock();
                pOS_ = Owner as POS_Stock;
                pOS_.SelectStock("SelectStock");
                this.Close();
            }
            else
            {
                DisposalItem();
            }
        }
        /// <summary>
        /// 폐기상품정보 가져오기
        /// </summary>
        private void SelectDisposalItem()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SelectStock2", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SProductBarcode", bar);
                    SqlDataReader sdr = cmd.ExecuteReader();//select문 실행
                    if (!sdr.HasRows)
                    {
                        MessageBox.Show("Not Data");
                        return;
                    }
                    else
                    {
                        while (sdr.Read())
                        {
                            ProductNO = sdr["ProductNo"].ToString();
                            tb_category.Text = sdr["ProductCategory"].ToString();
                            tb_name.Text = sdr["ProductName"].ToString();
                            tb_price.Text = sdr["ProductPrice"].ToString();
                            tb_primePrice.Text = sdr["ProductPrimeCost"].ToString();
                            Byte[] bImg = (Byte[])sdr["ProductImage"];
                            pictureBox1.Image = new Bitmap(new MemoryStream(bImg));
                            if (sdr["ProductQuantity"].ToString() == "0")
                            {
                                MessageBox.Show("재고가 없습니다.");
                            }
                        }
                        
                    }
                }
            }
        }
        /// <summary>
        /// 폐기 테이블에 정보를 올리고 
        /// 재고테이블에 -1을 한다.
        /// </summary>
        private void DisposalItem()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("InsertDisposal", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    MessageBox.Show(ProductNO);
                    cmd.Parameters.AddWithValue("@IProductNo",int.Parse(ProductNO));
                    cmd.Parameters.AddWithValue("@IDisposalCount", 1);

                    int i = cmd.ExecuteNonQuery();//insert문 1=저장 0=저장 안됨

                    if (i == 0)
                    { 
                        MessageBox.Show("저장 안됨");
                        con.Close();
                        return;
                    }
                }

                using (SqlCommand cmd = new SqlCommand("UpdateStock2", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UProductNo", int.Parse(ProductNO));
                    cmd.Parameters.AddWithValue("@UProductQuantity", -1);

                    int i = cmd.ExecuteNonQuery();//insert문 1=저장 0=저장 안됨

                    if (i == 1)
                    {
                        MessageBox.Show("저장");
                        con.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("저장 안됨2");
                        con.Close();
                        return;
                    }
                }
            }
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
                    cmd.Parameters.AddWithValue("@UProductCategory", tb_category.Text);
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
            if (disOrNew == 0)
            {
                BarcodeFit();
            }
        }

        private void tb_barcode_TextChanged(object sender, EventArgs e)
        {
            if (tb_barcode.TextLength == 18 && disOrNew==1)
            {
                BarcodeFit();
                SelectDisposalItem();
            }
        }
    }
}
