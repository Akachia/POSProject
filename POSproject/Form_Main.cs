using System;
using System.Collections;
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
using POSproject;
using POSproject_KSM;
using TF;

namespace formSales
{
    public partial class Form_Main : Form
    {
        Form_LogIn FL;
        string user;
        public Form_Main()
        {
            InitializeComponent();
        }
        public Form_Main(DateTime checkIn, string id)
        {
            InitializeComponent();
            user = id;
            lbl_user.Text = id + "님 환영합니다. ";
            lbl_time.Text = DateTime.Now.ToLongTimeString();
        }
        
        DataSet ds = new DataSet("SalesList");
        SqlDataAdapter adapter = new SqlDataAdapter();
        ArrayList ProdNoList = new ArrayList(); // 그리드 뷰에 있는 상품의 상품번호 저장할 배열
        int totalPrice = 0; // 물품 합산 금액
        int totalDis = 0; // 총 할인 금액
        int finalPrice = 0; // 총 계산금액
        
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;

            FL = (Form_LogIn)Owner;
            FL.Visible=false;

            timer1.Start();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Length != 0)
            {
                for (int i = 0; i < ProdNoList.Count; i++)
                {
                    ProdNoList[i].ToString();
                }
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
                {
                    using (var cmd = new SqlCommand("SelectSalesStock", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                        cmd.Parameters.AddWithValue("@count", 1); // 최초 상품등록시 수량은 1개

                        adapter.SelectCommand = cmd;
                        adapter.Fill(ds);
                        
                    }
                }
                this.dataGridView1.DataSource = ds.Tables[0];

                int rowCount = dataGridView1.Rows.Count-1; // 여기서 항상 값이 초기화됨
                
                bool check = false; // for문 빠져나오기위해 만듬
                //
                //
                ProdNoList.Clear(); // 배열 비우기

                // 등록된 상품이 중복되는지 확인하는 부분
                if (rowCount > 0) // 1개의 상품이라도 등록되있어야 실행 -> 리스트 상 2번째 상품부터 적용
                {
                    //MessageBox.Show(dataGridView1.Rows[rowCount].Cells[0].Value.ToString());
                    for (int i = 0; i < rowCount; i++)
                    {
                        ProdNoList.Add(dataGridView1.Rows[i].Cells[0].Value.ToString()); // 목록에 올라와있는 상품 번호 배열에 저장
                        //MessageBox.Show(rowCount.ToString());
                        for (int j = 0; j < ProdNoList.Count; j++)
                        {
                            if (int.Parse(dataGridView1.Rows[rowCount].Cells[0].Value.ToString()) == int.Parse(ProdNoList[j].ToString())) // 배열안의 값과 같은게 있다면...
                            {
                                //MessageBox.Show("Test");
                                dataGridView1.Rows.Remove(dataGridView1.Rows[rowCount]); // 마지막 행을 지운다.
                                dataGridView1.Rows[j].Cells[2].Value = (int.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString()) + 1); // 물품 수량 증가

                                // 총액 계산식
                                priceCalc(j);

                                check = true;
                                break;
                            }
                        }
                        if (check)
                        {
                            check = false;
                            break;
                        }
                    }
                }

                Total();
                // 총 계산 금액 정산할 부분

                // 검색 결과가 없을경우 분기점 마련해야함
            }
            else
            {
                MessageBox.Show("바코드가 등록되지 않았습니다");
            }

            // 상품등록이 발생했을때(지금 위치) 합계, 할인된 금액, 총액 계산해서 텍스트박스에 삽입 메서드로 만들것(취소에서도 사용해야함)

            txtBarcode.Focus();
        }

        private void priceCalc(int j)
        {
            int price = int.Parse(dataGridView1.Rows[j].Cells[4].Value.ToString());
            int count = int.Parse(dataGridView1.Rows[j].Cells[2].Value.ToString());
            int dis = price * int.Parse(dataGridView1.Rows[j].Cells[5].Value.ToString()) / 100;
            dataGridView1.Rows[j].Cells[3].Value = (price - (dis)) * count;// ((가격[4] * 갯수[2])*((100-할인율[5])/100)
        }

        private void Total()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                totalPrice += int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) * int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                totalDis += int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()) * int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()) - int.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString()); // 원가*수량 - 할인되서계산된금액
            }
            finalPrice += totalPrice - totalDis;
            txtBarcode.Text = "";
            txtTotalPrice.Text = totalPrice.ToString();
            txtTotalDis.Text = totalDis.ToString();
            txtFinalPrice.Text = finalPrice.ToString();
            Reset();
        }

        private void Reset()
        {
            totalPrice = 0;
            totalDis = 0;
            finalPrice = 0;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(dataGridView1.CurrentRow.Index.ToString());
            DataTable dataTable = ds.Tables[0];
            try
            {
                DataRow dr = dataTable.Rows[dataGridView1.CurrentCell.RowIndex];
                txtProdCount.Text = dr[2].ToString();
            }
            catch (Exception)
            {
                txtProdCount.Text = "";
            }
        }

        private void btnCancle_Click(object sender, EventArgs e) // 선택한 제품 취소
        {
            txtTotalPrice.Text = "0";
            txtTotalDis.Text = "0";
            txtFinalPrice.Text = "0";
            try
            {
                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
            }
            catch (Exception)
            {
                MessageBox.Show("삭제할 내용이 없습니다.");
            }

            Reset();
            Total();
            // 상품 취소가 발생했을때 합계, 할인금액.... 메서드

        }

        private void btnCntMod_Click(object sender, EventArgs e) // 선택한 제품의 수량 정정
        {
            dataGridView1.CurrentRow.Cells[2].Value = txtProdCount.Text;
            dataGridView1.ClearSelection();
            txtProdCount.Text = "";
            MessageBox.Show(dataGridView1.CurrentRow.Index.ToString());
            Reset();
            priceCalc(dataGridView1.CurrentRow.Index);
            Total();
        }
        
        private void btnPay_Click(object sender, EventArgs e) // 결제 - Sales 테이블에 넣기
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_user.Text = user + "님 환영합니다.";
            lbl_time.Text = DateTime.Now.ToLongTimeString();


            lbl_user.Left = lbl_user.Left - 3;





            if (lbl_user.Right < 0)

                lbl_user.Left = this.Width-lbl_time.Left;
        }

        private void btnUserSet_Click(object sender, EventArgs e)
        {
            UserAccount ua = new UserAccount(user);
            ua.Owner = this;
            ua.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new POSproject_KSM.Form_stock().Show();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            new Form_Account().Show();
        }
    }
}
