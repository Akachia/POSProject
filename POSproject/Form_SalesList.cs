using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSproject
{
    public partial class Form_SalesList : Form
    {
        string store;
        string bNum;
        string oName;
        string addr;
        string call;
        DataSet ds;
        PrintDocument pd2=new PrintDocument();
        public Form_SalesList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 로드 시 가게 정보 읽어와서 저장 및 그리드뷰 데이터 로드
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_SalesList_Load(object sender, EventArgs e)
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
                    store = sdr.GetString(2);
                    bNum = sdr.GetString(0);
                    oName = sdr.GetString(3);
                    addr = sdr.GetString(1);
                    call = sdr.GetString(4);
                }
                sdr.Close();
            }



            /////
           




            ds = Prcd.SalesListLoad();

           

            dgvSaleList.DataSource = ds.Tables[0];

            dgvSaleList.AllowUserToAddRows = false;
            reName();
            


        }

        private void reName()
        {
            dgvSaleList.Columns[0].HeaderText = "거래번호";
            dgvSaleList.Columns[1].HeaderText = "제품번호";
            dgvSaleList.Columns[2].HeaderText = "제품명";
            dgvSaleList.Columns[3].HeaderText = "갯수";
            dgvSaleList.Columns[4].HeaderText = "가격";
            dgvSaleList.Columns[5].HeaderText = "판매자";
            dgvSaleList.Columns[6].HeaderText = "거래일";
            dgvSaleList.Columns[7].HeaderText = "카드여부";
            dgvSaleList.Columns[8].HeaderText = "카드번호";


        }

        private void dgvSaleList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox1.Image = null;
            txtReceipt.Text = "";
            DateTime time = (DateTime)dgvSaleList.CurrentRow.Cells[6].Value;
            DataTableReader ie = ds.Tables[0].CreateDataReader();
            string sum="";
            int price = 0;
            string check = "현금";
            while(ie.Read())
            {
                
                if(dgvSaleList.CurrentRow.Cells[0].Value.ToString()==ie[0].ToString())
                {
                    
                    sum += ie[2].ToString() + "\r\t" + ie[3].ToString() + "\r\t" + ie[4].ToString() + "\r\n";
                    price += int.Parse(ie["SellPrice"].ToString());
                    
                }
            }
            txtReceipt.Text = "\r\t\r\t" + store + "\r\n\r\n사업자 번호 : " + bNum + "\r\n대표: " + oName + "\r\t연락처 : " + call + "\r\n주소 : " + addr + "\r\n\r\n--------------------------------------------\r\n정부 방침에 의거,\r\n12년 7월 1일부터 현금 결제 취소시,\r\n영수증이 없으면 교환/ 환불이 불가합니다.\r\n --------------------------------------------\r\n" + dgvSaleList.CurrentRow.Cells[0].Value.ToString() + "\r\t" + time.ToShortDateString() + "\r\n\r\n" + sum + "\r\n\r\n\r\n";
            if(dgvSaleList.CurrentRow.Cells[7].Value.ToString() =="True")
            {
                txtReceipt.Text += "카드번호 : \r\t" + dgvSaleList.CurrentRow.Cells[8].Value.ToString() + "\r\n";
                check = "신용카드";

            }
            txtReceipt.Text += "\r\n합계 : \r\t\r\t\r\t\r\t" + price+ "---------------------------------------- -\r\n\r\n내실 돈: \r\t\r\t\r\t\r\t" + price+"\r\n"+check+ "\r\t\r\t\r\t\r\t"+price+"\r\n\r\n환불은 30일내 영수증/ 카드지참시 가능합니다.";



            //거래번호로 바코드 생성
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            int W = 300;//152.2
            int H = 75;//41.4
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;

            //barcode alignment
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            //switch

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;

            type = BarcodeLib.TYPE.UPCA;

            try
            {

                b.IncludeLabel = true;

                b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "rotatenoneflipnone", true);

                b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;


                //===== Encoding performed here =====
                pictureBox1.Image = b.Encode(type, dgvSaleList.CurrentRow.Cells[0].Value.ToString(), Color.Black, Color.White, W, H);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            ie.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(txtReceipt.Width, txtReceipt.Height);
            Graphics gp = Graphics.FromImage(bitmap);

            Point xp = PointToScreen(new Point(txtReceipt.Location.X, 0));
            Point yp = PointToScreen(new Point(0, txtReceipt.Location.Y));
            //여기서 시작 포지션...그리고 0,0 하고 사이즈 정해주면 그 만큼 캡쳐를함
            //이때 좌표를 프로세스 내 좌표를 할 지 스크린 좌표로 할 지 그것만 정하면 됨
            gp.CopyFromScreen(
                xp.X,
                yp.Y,
                0,//this.Location.X + this.Width,
                0,//this.Location.Y + this.Height,
                new Size(bitmap.Width, bitmap.Height));
            bitmap.Save(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\test.png", System.Drawing.Imaging.ImageFormat.Bmp);

            PrintDialog pd = new PrintDialog();

            pd.Document = pd2;

            if (DialogResult.OK == pd.ShowDialog())
            {
                pd2.PrintPage += Pd2_PrintPage;
                pd2.Print();
            }
        }

        private void Pd2_PrintPage(object sender, PrintPageEventArgs e)
        {
            Image img = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)+@"\test.png");
            Point loc = new Point(0, 0);
            e.Graphics.DrawImage(img, 0, 0);
        }
    }
}



    