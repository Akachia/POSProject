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
    public partial class Form_Disposal : Form
    {
        int ProductNO = 0;
        DataSet ds = null;
        DataTable ds2 = null;
        int modeSwitch = 0;
        SqlDataAdapter dataAdapter = null;
        public Form_Disposal()
        {
            InitializeComponent();
        }

        public Form_Disposal(string id) : this()
        {
            lbl_User.Text = id;
        }
        private SqlDataAdapter GetSqlDataAdapter()
        {
            if (this.dataAdapter == null)
            {
                return new SqlDataAdapter();
            }
            else
            {
                return this.dataAdapter;
            }
        }

        private DataSet GetDataSet()
        {
            if (ds == null)
            {
                return new DataSet();
            }
            else
            {
                ds.Clear();
                return ds;
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {

        }

        private void Disposal_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            DataRowInit();
            tb_StQunt.Text = "0";
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DisposalSelect();
        }

        private void DisposalSelect()
        {
            ds = GetDataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SelectDisposalStock", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = GetSqlDataAdapter();
                    dataAdapter.SelectCommand = cmd;
                    dataAdapter.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void btn_Prod_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SelectDisposalTerm", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = GetSqlDataAdapter();
                    cmd.Parameters.AddWithValue("@SDate1", startDate.Value);
                    cmd.Parameters.AddWithValue("@SDate2", endDate.Value);
                    dataAdapter.SelectCommand = cmd;
                    ds = GetDataSet();
                    dataAdapter.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
        }

        /// <summary>
        /// 폐기상품정보 가져오기
        /// </summary>
        private void SelectDisposalItem(string bar)
        {
            DataRow dataRow = ds2.NewRow();
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
                            if (sdr["ProductQuantity"].ToString() == "0")
                            {
                                MessageBox.Show("재고가 없습니다.");
                                return;
                            }
                            else
                            {
                                MessageBox.Show("Test");
                                ProductNO = (int)sdr["ProductNo"];
                                tb_StCate.Text = sdr["ProductCategory"].ToString();
                                tb_StName.Text = sdr["ProductName"].ToString();
                                tb_StPrice.Text = sdr["ProductPrimeCost"].ToString();
                                if (int.Parse(tb_StQunt.Text)>0)
                                {
                                    tb_StQunt.Text = "1";
                                }
                                else
                                {
                                    tb_StQunt.Text = (int.Parse(tb_StQunt.Text) + 1).ToString();
                                }
                                Byte[] bImg = (Byte[])sdr["ProductImage"];
                                pictureBox1.Image = new Bitmap(new MemoryStream(bImg));
                            }
                        }
                        int i = 0;
                        for (; i < ds2.Rows.Count; i++)
                        {
                            if ((int)ds2.Rows[i].ItemArray[0] == ProductNO)
                            {
                                ds2.Rows[i]["제품수량"] = (int)ds2.Rows[i]["제품수량"] + 1;
                                return;
                            }
                            
                        }
                       // MessageBox.Show(i.ToString() + ds2.Rows.Count.ToString());
                        if (i == ds2.Rows.Count)
                        {
                            dataRow["제품번호"] = ProductNO;
                            dataRow["바코드"] = BarcodeInit(tb_StBar.Text);
                            dataRow["제품이름"] = tb_StName.Text;
                            dataRow["카테고리"] = tb_StCate.Text;
                            dataRow["제품원가"] = tb_StPrice.Text;
                            dataRow["제품수량"] = 1;
                            ImageConverter converter = new ImageConverter();
                            dataRow["제품 이미지"] = converter.ConvertTo(pictureBox1.Image, System.Type.GetType("System.Byte[]"));
                            ds2.Rows.Add(dataRow);
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
                    cmd.Parameters.AddWithValue("@IProductNo", ProductNO);
                    cmd.Parameters.AddWithValue("@IDisposalCount", int.Parse(tb_StQunt.Text));

                    int i = cmd.ExecuteNonQuery();//insert문 1=저장 0=저장 안됨

                    if (i == 0)
                    {
                        MessageBox.Show("저장 안됨");
                        con.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("데이터 반영됨");
                        DisposalSelect();
                        ProductNO = 0;
                        tb_StBar.Text = null;
                        tb_StCate.Text = null;
                        tb_StName.Text = null;
                        tb_StPrice.Text = null;
                        tb_StQunt.Text = null;
                    }
                }
            }
        }
        /// <summary>
        /// 바코드를 13자리로 만들어주는 함수
        /// </summary>
        /// <param name="bar"></param>
        /// <returns></returns>
        private string BarcodeInit(string bar)
        {
            char[] shf = bar.ToCharArray();
            bar = null; 
            for (int i = 0; i < 13; i++)
            {
                bar += shf[i];
            }
            return bar;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_StBar_TextChanged(object sender, EventArgs e)
        {
            ///modeSwitch가 0이면 모든 폐기 모드 
            ///1이면 폐기추가 모드
            if (modeSwitch == 0 && tb_StBar.Text.Length == 13)
            {
                modeSwitch = 1;
                SelectDisposalItem(tb_StBar.Text);
                dataGridView1.DataSource = ds2;
                tb_StBar.SelectAll();
            }
            else
            {
                if (tb_StBar.Text.Length == 13)
                {
                    SelectDisposalItem(tb_StBar.Text);
                    tb_StBar.SelectAll();
                }
                else if (tb_StBar.Text.Length == 18)
                {
                    SelectDisposalItem(BarcodeInit(tb_StBar.Text));
                }
            }
        }

        private void DataRowInit()
        {
            ds2 = new DataTable();
            int count = dataGridView1.Rows.Count;

            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "제품번호";
            ds2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "바코드";
            ds2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "제품이름";
            ds2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "카테고리";
            ds2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "제품원가";
            ds2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "제품수량";
            ds2.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Byte[]");
            column.ColumnName = "제품 이미지";
            ds2.Columns.Add(column);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            SelectDisposalItem(tb_StBar.Text);
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            modeSwitch = 0;
            ds2.Clear();
            DisposalSelect();
        }

        private void btn_StUpdate_Click(object sender, EventArgs e)
        {
            DisposalItem();
        }
    }
}
