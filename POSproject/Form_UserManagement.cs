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
    public partial class Form_UserManagement : Form
    {
        string user;
        public Form_UserManagement()
        {
            InitializeComponent();
        }
        public Form_UserManagement(string user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if(txtSearch.Text.Length>=2)
            {

            }
        }

        private void Form_UserManagement_Load(object sender, EventArgs e)
        {
            DataSet ds=Prcd.UserManagementLoad(user);

            DataTableReader ie = ds.Tables[0].CreateDataReader();

            
            while (ie.Read())
            {
                //textBox1.Text += ie[0] + " - 출근 : " + ie[1].ToString() + "\r\n";
            }

        }
    }
}
