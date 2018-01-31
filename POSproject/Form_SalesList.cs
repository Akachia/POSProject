using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSproject
{
    public partial class Form_SalesList : Form
    {
        public Form_SalesList()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_SalesList_Load(object sender, EventArgs e)
        {
            //BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            //int W = 300;//152.2
            //int H = 75;//41.4
            //b.Alignment = BarcodeLib.AlignmentPositions.CENTER;

            ////barcode alignment
            //b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            ////switch

            //BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;

            //type = BarcodeLib.TYPE.UPCA;

            //try
            //{

            //    b.IncludeLabel = true;

            //    b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "rotatenoneflipnone", true);

            //    b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;


            //    //===== Encoding performed here =====
            //    pictureBox1.Image = b.Encode(type, "123456789012", Color.Black, Color.White, W, H);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}


            DataSet ds = Prcd.SalesListLoad();

            DataTableReader ie = ds.Tables[0].CreateDataReader();

            dgvSaleList.DataSource = ds.Tables[0];

            dgvSaleList.AllowUserToAddRows = false;
            reName();
            ie.Close();


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
    }
}
