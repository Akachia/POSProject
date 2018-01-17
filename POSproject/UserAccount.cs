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
    public partial class UserAccount : Form
    {
        string user;
        public UserAccount()
        {
            InitializeComponent();
        }
        public UserAccount(string user)
        {
            InitializeComponent();
            this.user = user;

            if(Prcd.CheckAdmin(user)!="True")
            {
                btn_mgr.Hide();
            }
        }
        private void UserAccount_Load(object sender, EventArgs e)
        {

        }

        private void btn_mgr_Click(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
