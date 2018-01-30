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
        string[] checkItem;
        string cardNum = "";
        int totalPrice = 0; // 물품 합산 금액
        int totalDis = 0; // 총 할인 금액
        int finalPrice = 0; // 총 계산금액
        int checkProdno = 0;
        int prodCount = 0;


        private void Form1_Load(object sender, EventArgs e)
        {
            txtBarcode.Focus();

            dataGridView1.AllowUserToAddRows = false;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            FL = (Form_LogIn)Owner;
            FL.Visible = false;

            timer1.Start();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Text.Length != 0)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand("SelectStock2", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SProductBarcode", txtBarcode.Text);

                        checkProdno = (int)cmd.ExecuteScalar();
                    }

                    using (var cmd = new SqlCommand("SelectSalesStock", con))
                    {
                        prodCount = 0;

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@barcode", txtBarcode.Text);
                        cmd.Parameters.AddWithValue("@count", 1); // 최초 상품등록시 수량은 1개

                        SqlDataReader sdr = cmd.ExecuteReader(); // 상품 존재여부 확인
                        if (!sdr.HasRows)
                        {
                            MessageBox.Show("상품이 존재하지 않습니다.");
                            txtBarcode.Text = "";
                            con.Close();
                            return;
                        }
                        sdr.Close();

                        prodCount = (int)cmd.ExecuteScalar(); // 상품 재고수량 확인
                        if (prodCount <= 0)
                        {
                            MessageBox.Show("상품 수량이 부족하여 판매할 수 없습니다.");
                            txtBarcode.Text = "";
                            con.Close();
                            return;
                        }

                        checkItem = new string[2];

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if ((int)dataGridView1.Rows[i].Cells[0].Value == checkProdno)
                            {
                                checkItem = CheckItemCount(checkProdno, (int)dataGridView1.Rows[i].Cells[2].Value);

                                if (checkItem[0].ToString() == "1")
                                {
                                    dataGridView1.Rows[i].Cells[2].Value = (int)dataGridView1.Rows[i].Cells[2].Value + 1;
                                    txtProdCount.Text = "";
                                    Reset();
                                    priceCalc(i);
                                    Total();
                                }
                                else
                                {
                                    MessageBox.Show("재고가 부족합니다. 잔여 수량 : " + checkItem[1].ToString());
                                    txtBarcode.Text = "";
                                    return;
                                }
                            }
                        }

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
                // 총 계산 금액 정산할 부분
                Total();
            }
            else
            {
                MessageBox.Show("바코드가 등록되지 않았습니다");
            }

            // 상품등록이 발생했을때(지금 위치) 합계, 할인된 금액, 총액 계산해서 텍스트박스에 삽입 메서드로 만들것(취소에서도 사용해야함)

            // 헤더로 인한 정렬 금지
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
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
            if (rbtCard.Checked)
            {
                txtPay.Text = txtFinalPrice.Text;
            }
            Reset();
        }

        private void Reset()
        {
            totalPrice = 0;
            totalDis = 0;
            finalPrice = 0;
        }

        private string[] CheckItemCount(int prodNo, int rowCount) // + (-는 필요없음 -> 수동증가 +증가 모두 막아놨음)
        {
            string[] reCheckItem = new string[2];
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand("CheckProdQuanProdNo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prodNo", prodNo);

                    int ProdCount = (int)cmd.ExecuteScalar();

                    if (ProdCount < rowCount + 1) // 재고량 < 증가량 => 판매불가
                    {
                        con.Close();
                        reCheckItem[0] = "0";
                    }
                    else
                    {
                        con.Close();
                        reCheckItem[0] = "1";
                    }
                    reCheckItem[1] = ProdCount.ToString();
                    return reCheckItem;
                }
            }
        }

        private string[] CheckItemCount(int selectNo, string intputCount) // 수량 비교 결과전송
        {
            string[] reCheckItem = new string[2];
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (var cmd = new SqlCommand("CheckProdQuanProdNo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@prodNo", selectNo);

                    int ProdCount = (int)cmd.ExecuteScalar();

                    if (ProdCount < int.Parse(intputCount)) // 재고량 < 판매량 => 판매불가
                    {
                        con.Close();
                        reCheckItem[0] = "0";
                    }
                    else
                    {
                        con.Close();
                        reCheckItem[0] = "1";
                    }
                    reCheckItem[1] = ProdCount.ToString();
                    return reCheckItem;
                }
            }
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

        private void btnCntPlus_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(dataGridView1.CurrentRow.Index.ToString());
            try
            {
                checkItem = new string[2];
                checkItem = CheckItemCount((int)dataGridView1.CurrentRow.Cells[0].Value, (int)dataGridView1.CurrentRow.Cells[2].Value);
                if (checkItem[0].ToString() == "1")
                {
                    dataGridView1.CurrentRow.Cells[2].Value = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) + 1;
                    txtProdCount.Text = "";
                    //MessageBox.Show(dataGridView1.CurrentRow.Index.ToString());
                    Reset();
                    priceCalc(dataGridView1.CurrentRow.Index);
                    Total();
                }
                else
                {
                    MessageBox.Show("재고가 부족합니다. 잔여 수량 : " + checkItem[1].ToString());
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("선택된 항목이 없습니다.");
            }
        }

        private void btnCntMod_Click(object sender, EventArgs e) // 선택한 제품의 수량 정정
        {
            try
            {
                if (int.Parse(txtProdCount.Text) < 0)
                {
                    MessageBox.Show("수량은 0개 이하로 설정하실 수 없습니다.");
                    return;
                }

                checkItem = new string[2];
                checkItem = CheckItemCount((int)dataGridView1.CurrentRow.Cells[0].Value, txtProdCount.Text);
                //MessageBox.Show(checkItem[0].ToString());
                if (checkItem[0].ToString() == "1") // 재고량 - 판매량 수량비교 결과
                {
                    dataGridView1.CurrentRow.Cells[2].Value = txtProdCount.Text;
                    dataGridView1.ClearSelection();
                    txtProdCount.Text = "";
                    //MessageBox.Show(dataGridView1.CurrentRow.Index.ToString());
                    Reset();
                    priceCalc(dataGridView1.CurrentRow.Index);
                    Total();
                }
                else
                {
                    MessageBox.Show("재고가 부족합니다. 잔여 수량 : " + checkItem[1].ToString());
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("선택된 상품이 없습니다.");
                return;
            }

        }

        private void btnCntMin_Click(object sender, EventArgs e)
        {
            try
            {
                if ((int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) - 1) < 0)
                {
                    MessageBox.Show("상품 수량이 0개 입니다.");
                    dataGridView1.CurrentRow.Cells[2].Value = 0;
                    return;
                }
                else
                {
                    dataGridView1.CurrentRow.Cells[2].Value = int.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString()) - 1;
                    txtProdCount.Text = "";
                    //MessageBox.Show(dataGridView1.CurrentRow.Index.ToString());
                    Reset();
                    priceCalc(dataGridView1.CurrentRow.Index);
                    Total();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("선택된 항목이 없습니다.");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_user.Text = user + "님 환영합니다.";
            lbl_time.Text = DateTime.Now.ToLongTimeString();


            lbl_user.Left = lbl_user.Left - 3;


            if (lbl_user.Right < 0)

                lbl_user.Left = this.Width - lbl_time.Left;
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
            new POSproject_KSM.POS_Stock(user).Show();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            new Form_Account().Show();
        }

        private void txtPay_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPay.Text == "")
                {
                    txtChange.Text = "";
                    return;
                }
                else if (long.Parse(txtPay.Text) > int.MaxValue || txtPay.Text.Length > 10)
                {
                    txtPay.Text = "";
                    return;
                }
                else
                {
                    txtChange.Text = (int.Parse(txtPay.Text) - int.Parse(txtFinalPrice.Text)).ToString();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("숫자만 입력이 가능합니다.");
                txtPay.Text = "";
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnRegister_Click(null, null);
            }
        }

        public string getCardNum()
        {
            return cardNum;
        }

        private void btnPay_Click(object sender, EventArgs e) // 결제 - Sales 테이블에 넣기
        {
            long sellNo = long.Parse(DateTime.Now.ToString("yyMMddHHmmss")); // 연월일시분 10자리
            int prodNo = 0;
            string userId = user;
            int sellCount = 0;
            int checkCashOrCard = 0;
            cardNum = "";
            //MessageBox.Show(sellNo.ToString());

            if (rbtCard.Checked)
            {
                txtPay.Text = txtFinalPrice.Text;
                checkCashOrCard = 1;
                //카드 번호 입력하는 폼 띄워서 입력 -> 가져와서 변수값 변경시킨다.
            }

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("등록된 상품이 없습니다.");
                txtBarcode.Focus();
                return;
            }
            if (txtPay.Text.Length == 0 || txtPay.Text == "0" || rbtCash.Checked && int.Parse(txtPay.Text) <= int.Parse(txtFinalPrice.Text))
            {
                MessageBox.Show("금액이 입력되지 않았습니다.");
                txtPay.Focus();
                return;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //MessageBox.Show(i.ToString());
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
                {
                    con.Open();
                    using (var cmd = new SqlCommand("InsertSales", con))
                    {
                        prodNo = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                        sellCount = int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString());
                        //MessageBox.Show(prodNo.ToString());

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@sellNo", sellNo);
                        cmd.Parameters.AddWithValue("@prodNo", prodNo);
                        cmd.Parameters.AddWithValue("@userID", userId);
                        cmd.Parameters.AddWithValue("@sellCount", sellCount);
                        cmd.Parameters.AddWithValue("@cardWhether", checkCashOrCard); // 카드 사용 여부
                        cmd.Parameters.AddWithValue("@cardNumber", cardNum);

                        cmd.ExecuteReader();
                    }
                    con.Close();
                    con.Open();
                    using (var cmd = new SqlCommand("ProdCntDown", con)) // 상품 재고 감소
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductNo", int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                        cmd.Parameters.AddWithValue("@ProductCount", int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                        cmd.ExecuteReader();
                    }

                    con.Close();
                    con.Open();
                    using (var cmd = new SqlCommand("ProdSalesVolUp", con)) // 상품 누적 판매 증가
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ProductNo", int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()));
                        cmd.Parameters.AddWithValue("@ProductCount", int.Parse(dataGridView1.Rows[i].Cells[2].Value.ToString()));
                        cmd.ExecuteReader();
                    }
                }
            }
            MessageBox.Show("결제가 완료되었습니다.");
            cardNum = ""; // 카드번호 초기화 필수
            txtTotalPrice.Text = "0";
            txtTotalDis.Text = "0";
            txtFinalPrice.Text = "0";
            txtPay.Text = "";
            txtChange.Text = "";
            ds.Clear();
            dataGridView1.DataSource = null;
            //전체 try catch걸고 예외발생시 거래 오류 메시지 출력 -> return;
            //맨위에 현금거래일경우 지불금 적혀있지 않으면 메시지박스 출력시키고 return하는것 만들것 
        }

        private void btnRefund_Click(object sender, EventArgs e)
        {
            Form_Refund fr = new Form_Refund();
            fr.Show();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnPayReset_Click(object sender, EventArgs e)
        {
            txtPay.Text = "";
        }

        private void paySet(object sender, EventArgs e)
        {
            int money = int.Parse(sender.ToString().Split(',')[1].Split(':')[1].Trim().ToString());
            int payMoney;
            if (txtPay.Text == "")
            {
                payMoney = 0;
            }
            else
            {
                payMoney = int.Parse(txtPay.Text);
            }
            txtPay.Text = (payMoney + money).ToString();
        }

        private void rbtCash_Click(object sender, EventArgs e)
        {
            txtPay.Text = "";
        }

        private void rbtCard_Click(object sender, EventArgs e)
        {
            Form_Card fc = new Form_Card();
            fc.Show(this);
        }

        public void getCardNum(string num)
        {
            this.cardNum = num;
            //MessageBox.Show(cardNum);
            //성공적으로 카드번호를 가져왔다면...
            if (cardNum.Trim().Length == 19)
            {
                txtPay.Text = txtFinalPrice.Text;
                //MessageBox.Show("카드번호 정상적으로 가져옴");
            }
            else
            {
                MessageBox.Show("카드번호가 잘못되었습니다.");
                cancleCard();
            }
        }

        public void cancleCard()
        {
            rbtCash.Checked = true;
            txtPay.Text = "";
            cardNum = "";
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            new Form_Preferences().Show();
        }
    }
}