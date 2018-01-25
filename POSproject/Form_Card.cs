using formSales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSproject
{
    public partial class Form_Card : Form
    {
        Form_Main main;

        public Form_Card()
        {
            InitializeComponent();
        }

        private void Form_Card_Load(object sender, EventArgs e)
        {
            main = this.Owner as Form_Main;
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            main.cancleCard();
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string cardNum = txtCardNum.Text;
            main.getCardNum(cardNum);
            this.Close();
        }
    }
}
