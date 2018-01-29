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
    }
}
