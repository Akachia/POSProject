using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace POSproject_KSM
{
    //DB싱글톤 
   
    public partial class POS_Stock : Form
    {
        //기본 이미지가 없는것을 표시할때 사용하는 이미지를 저장한 경로
        //string defualtPath = @"C:\Users\gd3-6\Documents\project+\img\noImage.gif";
        //string ddd = 
        //차후 싱글톤으로 만들자.
        DataSet ds = null;
        int i = 0;
        string id = null;
        public POS_Stock()
        {
            InitializeComponent();
        }

        public POS_Stock(string id) : this()
        {
            this.id = id;
        }

        internal DataSet GetDataSet( )
        {
            if(ds == null)
            {
                return new DataSet();
            }
            else
            {
                ds.Clear();
                return ds;
            }
        }
        /// <summary>
        /// 오더 테이블을 만들 dgv를 만든다.
        /// </summary>
        /// <returns></returns>
        internal DataTable MakeOrderTable()
        {
            //값타입이라 계속 같이 동반자살하네 ㅅㅂ넘이

            DataTable data = null; 
            data = ds.Tables[0].Copy();
            int count = data.Rows.Count;

            //ds의 구조만 전해주고 데이터는 지운다.
            for (int i = 0;i < count;i++ )
            {
                DataGridViewCheckBoxCell dgvCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                if (dgvCell.Value == new DataGridViewCheckBoxCell().FalseValue)
                {
                    //MessageBox.Show(" : " + (dgvCell.RowIndex +1).ToString());
                    data.Rows[i].Delete();
                }
            }
            //지워지면 열이 없어서져서 주의해야한다.
            //그래서 같은열을 지우면 알아서 삭제된다.
            
            data.Columns.RemoveAt(6);
            data.Columns.RemoveAt(6);
            data.Columns.RemoveAt(6);
            data.Columns.RemoveAt(6);
            data.Columns.RemoveAt(6);
            data.Columns.RemoveAt(1);
            //지운데이터를 반영한다.
            data.AcceptChanges();

            //MessageBox.Show(data.Rows.Count.ToString());
            //MessageBox.Show(data.Columns.Count.ToString());

            return data;
        }

        internal void SelectStock(string procesor, DataGridView dgv)
        {
            ds = GetDataSet();
            
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(procesor, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = cmd;

                    dataAdapter.Fill(ds);

                    dgv.DataSource = ds.Tables[0];
                }
            }
            
        }

        /// <summary>
        /// 재고 폼이 로드 될때 디비에 접속하고 재고 db에 있는 내용을 출력시킨다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            SelectStock("SelectStock",dataGridView1);
            label1.Text = DateTime.Now.ToLongTimeString();
            lbl_User.Text = id;
            timer1.Start();
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].HeaderText = "수량";
            dataGridView1.Columns[2].HeaderText = "바코드";
            dataGridView1.Columns[5].HeaderText = "원가";
            dataGridView1.Columns[3].HeaderText = "이름";
            dataGridView1.Columns[4].HeaderText = "판매가";
            dataGridView1.Columns[1].HeaderText = "상품번호";
            dataGridView1.Columns[8].HeaderText = "할인";
            dataGridView1.Columns[7].HeaderText = "종류";
            dataGridView1.Columns[9].HeaderText = "유통기한";
            dataGridView1.Columns[10].HeaderText = "누적 판매량";
            dataGridView1.Select();
        }
        /// <summary>
        /// 시계를 돌리기위한 틱 이벤트
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void Timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }
        /// <summary>
        /// 나가기 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stock_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 재고폼을 수정해준다
        /// 스위치요소를 넣어서 폼에서 수정이 필요할때만 필요한 내용을 수정하게 하고
        /// DB에 수정 프로시저를 사용해 데이터를 넣게 한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_StUpdate_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                tb_StQunt.Enabled = true;
                i++;
            }
            else if(i==1)
            {
                tb_StQunt.Enabled = false;
                i = 0;
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["AwsDB"].ConnectionString))
                {
                    
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("UpdateStock", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        
                        cmd.Parameters.AddWithValue("@UProductNo", dataGridView1.CurrentRow.Cells[1].Value);
                        cmd.Parameters.AddWithValue("@UProductBarcode", dataGridView1.CurrentRow.Cells[2].Value);
                        cmd.Parameters.AddWithValue("@UProductName", dataGridView1.CurrentRow.Cells[3].Value);
                        cmd.Parameters.AddWithValue("@UProductPrice", dataGridView1.CurrentRow.Cells[4].Value);
                        cmd.Parameters.AddWithValue("@UProductPrimeCost", dataGridView1.CurrentRow.Cells[5].Value);
                        cmd.Parameters.AddWithValue("@UProductQuantity", int.Parse(tb_StQunt.Text));
                        cmd.Parameters.AddWithValue("@UProductCategory", dataGridView1.CurrentRow.Cells[7].Value);
                        cmd.Parameters.AddWithValue("@UShelf_life", dataGridView1.CurrentRow.Cells[9].Value);
                        cmd.Parameters.AddWithValue("@USales_volume", dataGridView1.CurrentRow.Cells[10].Value);
                        cmd.Parameters.AddWithValue("@UDisCount", dataGridView1.CurrentRow.Cells[8].Value);
                        ImageConverter converter = new ImageConverter();
                        byte[] bImg = (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));
                        cmd.Parameters.AddWithValue("@UProductImage ", bImg);
                        
                        int i = cmd.ExecuteNonQuery();//insert문 1=저장 0=저장 안됨
                        
                        if (i == 1)
                        {
                            MessageBox.Show("저장");
                            SelectStock("SelectStock",dataGridView1);
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
            else
            {
                i = 0;
            }
        }

        /// <summary>
        /// 데이터그리드뷰를 클릭했을때 해당셀의 데이터를 textbox로 전해준다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            tb_StCate.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            tb_StName.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tb_StQunt.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            tb_StPrice.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString() + "원";
            tb_TtlPrice.Text = (int.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString()) 
                * int.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString())).ToString() + "원"; 
            tb_StBar.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tb_ShelfLIfe.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            tb_TtlSell.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[11].Value == DBNull.Value)
            {
                pictureBox1.Image = POSproject.Properties.Resources.noImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                Byte[] bImg = (byte[])dataGridView1.CurrentRow.Cells[11].Value;
                pictureBox1.Image = new Bitmap(new MemoryStream(bImg));

            }
        }
        /// <summary>
        /// 발주 폼으로 가게한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            order_From order_ = new order_From(id);
            order_.Owner = this;
            order_.ShowDialog();
        }
        /// <summary>
        /// picturebox를 클릭하면 이미지 교체가 가능하게 했다.
        /// 실제 사용시에는 필요가 없는 기능이므로 완성시는 막아둔다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.ShowDialog();
            pictureBox1.Image = new Bitmap(openFile.FileName);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_LstOrd_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
