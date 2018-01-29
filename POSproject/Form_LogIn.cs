using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using formSales;
namespace POSproject
{
    public partial class Form_LogIn : Form
    {
        public Form_LogIn()
        {
            InitializeComponent();
        }

      

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            string pwd = txtPwd.Text;

            if(Prcd.LogIn(id, pwd))
            {
                Form_Main FM =new Form_Main(DateTime.Now,id);
                FM.Owner = this;
                FM.Show();
                
                Prcd.checkin = DateTime.Now;
                //this.Dispose();
            }
            else
            {
                MessageBox.Show("실패!");
            }
        }
    }
}
