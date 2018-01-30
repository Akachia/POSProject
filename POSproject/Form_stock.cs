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
using System.Collections;

namespace POSproject_KSM
{
    //DB싱글톤 
    public partial class POS_Stock : Form
    { 
        //차후 싱글톤으로 만들자.
        DataSet ds = null;
        DataTable data = null;
        int i = 0;
        string id = null;
        string valid_discount = null;
        string valid_Quantiy = null;
        string[] autoCom = null;
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
            data = new DataTable();
            int count = dataGridView1.Rows.Count;

            DataColumn column;

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "productNo";
            data.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "productName";
            data.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "productPrice";
            data.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "productPrimePrice";
            data.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "productQuantity";
            data.Columns.Add(column);

            DataGridViewCheckBoxCell dgvCell = null;

            for (int i = 0;i < count;i++ )
            {
                dgvCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells[0];
                //MessageBox.Show(dgvCell.Value.ToString());
                if (dgvCell.Value != new DataGridViewCheckBoxCell().FalseValue)
                {
                    //MessageBox.Show(" : " + (dgvCell.RowIndex +1).ToString());
                    DataRow myRow = data.NewRow();

                    myRow["productNo"] = dataGridView1.Rows[i].Cells[1].Value;
                    myRow["productName"] = dataGridView1.Rows[i].Cells[3].Value;
                    myRow["productPrice"] = dataGridView1.Rows[i].Cells[4].Value;
                    myRow["productPrimePrice"] = dataGridView1.Rows[i].Cells[5].Value;
                    myRow["productQuantity"] = dataGridView1.Rows[i].Cells[6].Value;
                    data.Rows.Add(myRow);
                }
            }

            return data;
        }
        /// <summary>
        /// 현재
        /// </summary>
        /// <param name="procesor"></param>
        internal void SelectStock(string procesor)
        {
           DataSet ds = GetDataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(procesor, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = cmd;

                    dataAdapter.Fill(ds);

                    dataGridView1.DataSource = ds.Tables[0];
                    autoCom = new string[ds.Tables[0].Rows.Count];
                    for (int i = 0; i < autoCom.Length; i++)
                    {
                        autoCom[i] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    }
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
            this.tb_Search.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.tb_Search.AutoCompleteSource = AutoCompleteSource.CustomSource;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            SelectStock("SelectStock");
            AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
            collection.AddRange(autoCom);
            this.tb_Search.AutoCompleteCustomSource = collection;
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
            dataGridView1.Columns[9].HeaderText = "누적 판매량";
            dataGridView1.Columns[10].HeaderText = "상품 이미지";
            dataGridView1.Select();
        }

        /// <summary>
        /// 채크박스의 데이터가 동적으로 연결되어있어 order폼로드 후 데이터가 남아있다. 
        /// 체크박스의 내용을 false로 초기화 시켜준다.
        /// </summary>
        internal void CheckBoxinit()
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                item.Cells[0].Value = new DataGridViewCheckBoxCell().FalseValue;
            }
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
                tb_ShelfLIfe.Enabled = true;
                i++;
            }
            else if(i==1)
            {
                tb_StQunt.Enabled = false;
                tb_ShelfLIfe.Enabled = false;
                i = 0;
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
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
                        cmd.Parameters.AddWithValue("@USales_volume", dataGridView1.CurrentRow.Cells[9].Value);
                        cmd.Parameters.AddWithValue("@UDisCount", dataGridView1.CurrentRow.Cells[8].Value);
                        ImageConverter converter = new ImageConverter();
                        byte[] bImg = (byte[])converter.ConvertTo(pictureBox1.Image, typeof(byte[]));
                        cmd.Parameters.AddWithValue("@UProductImage ", bImg);
                        
                        int i = cmd.ExecuteNonQuery();//insert문 1=저장 0=저장 안됨
                        
                        if (i == 1)
                        {
                            MessageBox.Show("저장");
                            SelectStock("SelectStock");
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
            tb_ShelfLIfe.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            tb_TtlSell.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            if (dataGridView1.CurrentRow.Cells[10].Value == DBNull.Value)
            {
                pictureBox1.Image = POSproject.Properties.Resources.noImage;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                Byte[] bImg = (byte[])dataGridView1.CurrentRow.Cells[10].Value;
                pictureBox1.Image = new Bitmap(new MemoryStream(bImg));
            }
            valid_Quantiy = tb_StQunt.Text;
            valid_discount = tb_ShelfLIfe.Text;
        }
        /// <summary>
        /// 발주 폼으로 가게한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_OrderClick(object sender, EventArgs e)
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
            if (openFile.FileName != "")
            {
                pictureBox1.Image = new Bitmap(openFile.FileName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_LstOrd_Click(object sender, EventArgs e)
        {
            new OrderDetail().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btn_InStock_Click(object sender, EventArgs e)
        {
            new Form_InStock(id).ShowDialog(); 
        }

        private void btn_NewStock_Click(object sender, EventArgs e)
        {
            new Form_NewStock(id).ShowDialog();
        }

        private void btn_DIsposal_Click(object sender, EventArgs e)
        {
            new Form_Disposal(id).ShowDialog();
        }

        private void tb_ShelfLIfe_TextChanged(object sender, EventArgs e)
        {
            string sPattern = "^[0-9]{1}$|^[1-4]{1}[0-9]{1}$|^50$|^\\t";

            if (tb_ShelfLIfe.Text != "0" || tb_ShelfLIfe.Text != null)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(tb_ShelfLIfe.Text, sPattern))
                {
                    valid_discount = tb_ShelfLIfe.Text;
                }
                else
                {
                    tb_ShelfLIfe.Text = valid_discount;
                    MessageBox.Show("0~ 50의 숫자만 입력해주세요");
                }
            }

        }

        private void tb_Search_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                if (tb_Search.Text == item.Cells["ProductName"].Value.ToString())
                {
                    dataGridView1.ClearSelection();
                    item.Selected = true;
                    dataGridView1.CurrentCell = item.Cells[0];
                    dataGridView1_Click(null, null);
                }
            }
        }

        private void tb_StQunt_TextChanged(object sender, EventArgs e)
        {
            string sPattern = "^[0-9]{0,4}$";

            if (System.Text.RegularExpressions.Regex.IsMatch(tb_StQunt.Text, sPattern))
            {
                valid_Quantiy = tb_StQunt.Text;
            }
            else
            {
                tb_StQunt.Text = valid_Quantiy;
                MessageBox.Show("5자리 이하 숫자만 입력해주세요");
            }
        }
    }
}
