using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSproject
{
    public partial class Form_UserManagement : Form
    {
        string file;
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
            DataSet ds=Prcd.UserManagementLoad();

            DataTableReader ie = ds.Tables[0].CreateDataReader();

            dgvWorker.DataSource = ds.Tables[0];
           

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            file = null;
            var dlg = openPic.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                Userpic.Image = new Bitmap(Image.FromFile(openPic.FileName));
                file = openPic.FileName;
            }
        }

        private void dgvWorker_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.ReadOnly = true;
            byte[] img = null;
            if (dgvWorker.DataSource != null)
            {
                txtID.Text = dgvWorker.CurrentRow.Cells[0].Value.ToString();
                txtName.Text = dgvWorker.CurrentRow.Cells[1].Value.ToString();
                txtPhone.Text = dgvWorker.CurrentRow.Cells[2].Value.ToString();
                txtPay.Text = dgvWorker.CurrentRow.Cells[3].Value.ToString();
                //textBox5.Text = dgvWorker.CurrentRow.Cells[4].Value.ToString();
                
                if (dgvWorker.CurrentRow.Cells[4].Value.ToString()=="True")
                {
                    rbnMaster.Checked = true;
                }
                else
                {
                    rbnWorker.Checked = true;
                }
               
                   
                if(dgvWorker.CurrentRow.Cells[5].Value!=null)
                {
                    img = (byte[])dgvWorker.CurrentRow.Cells[5].Value;
                    Userpic.Image = new Bitmap(new MemoryStream(img));
                }
                
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string userid = txtID.Text;
            string Pwd = txtPwd.Text;
            string name = txtName.Text;
            int pay = int.Parse(txtPay.Text);
            string Phone = txtPhone.Text;
            byte[] img;
            string authority;
            if(rbnMaster.Checked)
            {
                authority = "True";
            }
            else
            {
                authority = "False";
            }
            if (file != null)
            {
                FileStream fs = new FileStream(file.ToString(), FileMode.Open, FileAccess.Read);

                img = new byte[fs.Length];
                fs.Read(img, 0, (int)fs.Length);
            }
            else
            {
                ImageConverter converter = new ImageConverter();
                img = (byte[])converter.ConvertTo(Userpic.Image, typeof(byte[]));





            }

            if (Prcd.UserManagement(userid,Pwd,name,pay,authority,Phone,img))
            {
                MessageBox.Show("업데이트에 성공하였습니다.");
            }
            else
            {
                MessageBox.Show("업데이트에 실패하였습니다.");
            }

            DataSet ds = Prcd.UserManagementLoad();

            DataTableReader ie = ds.Tables[0].CreateDataReader();

            dgvWorker.DataSource = ds.Tables[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var res=MessageBox.Show("편집중인 항목이 초기화됩니다. \r\n 계속하시겠습니까?", "경고", MessageBoxButtons.OKCancel);
            if(res==DialogResult.OK)
            {
                txtID.ReadOnly = false;
                txtID.Text = "";
                txtName.Text = "";
                txtPay.Text = "";
                txtPhone.Text = "";
                txtPwd.Text = "";
                Userpic.Image = POSproject.Properties.Resources.nouserpic;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string userid = txtID.Text;

            if(Prcd.UserDelete(userid))
            {
                MessageBox.Show(userid+" 계정이 완전히 제거되었습니다.");
            }
            else
            {
                MessageBox.Show(userid + " 계정 제거에 실패하였습니다.");
            }
        }
    }
}
