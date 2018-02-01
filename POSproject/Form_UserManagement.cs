using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace POSproject
{
    public partial class Form_UserManagement : Form
    {
        string file;
        string user;

        UserAccount ua;
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

            string find = txtSearch.Text;
            DataSet dset = Prcd.findUser(find);



            dgvWorker.DataSource = null;
            dgvWorker.DataSource = dset.Tables[0];

            foreach (DataGridViewRow row in dgvWorker.Rows)
            {

                if (row.Cells[2].Value.ToString() == "delete")
                {
                    dgvWorker.Rows.Remove(dgvWorker.Rows[row.Index]);
                }
            }
            reName();

        }

        private void Form_UserManagement_Load(object sender, EventArgs e)
        {

            ua = (UserAccount)Owner;
            ua.Visible = false;

            DataSet ds = Prcd.UserManagementLoad();

            DataTableReader ie = ds.Tables[0].CreateDataReader();

            dgvWorker.DataSource = ds.Tables[0];

            dgvWorker.AllowUserToAddRows = false;
            reName();
            ie.Close();


            foreach (DataGridViewRow row in dgvWorker.Rows)
            {

                if (row.Cells[2].Value.ToString() == "delete")
                {
                    dgvWorker.Rows.Remove(dgvWorker.Rows[row.Index]);
                }
            }

        }
        private void reName()
        {
            dgvWorker.Columns[0].HeaderText = "아이디";
            dgvWorker.Columns[1].HeaderText = "이름";
            dgvWorker.Columns[2].HeaderText = "전화번호";
            dgvWorker.Columns[3].HeaderText = "시급";
            dgvWorker.Columns[4].HeaderText = "권한 여부";
            dgvWorker.Columns[5].HeaderText = "사진";
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            ua.Visible = true;
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

                if (dgvWorker.CurrentRow.Cells[4].Value.ToString() == "True")
                {
                    rbnMaster.Checked = true;
                }
                else
                {
                    rbnWorker.Checked = true;
                }


                if (dgvWorker.CurrentRow.Cells[5].Value != null)
                {
                    img = (byte[])dgvWorker.CurrentRow.Cells[5].Value;
                    Userpic.Image = new Bitmap(new MemoryStream(img));
                }

            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (!checkVal())
            {
                string userid = txtID.Text;
                string Pwd = txtPwd.Text;
                string name = txtName.Text;
                int pay = int.Parse(txtPay.Text);
                string Phone = txtPhone.Text;
                byte[] img;
                string authority;
                if (rbnMaster.Checked)
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


                if (Prcd.UserManagement(userid, Pwd, name, pay, authority, Phone, img))
                {
                    MessageBox.Show("업데이트에 성공하였습니다.");
                }
                else
                {
                    MessageBox.Show("업데이트에 실패하였습니다.");
                }

                DataSet ds = Prcd.UserManagementLoad();



                dgvWorker.DataSource = ds.Tables[0];
                foreach (DataGridViewRow row in dgvWorker.Rows)
                {

                    if (row.Cells[2].Value.ToString() == "delete")
                    {
                        dgvWorker.Rows.Remove(dgvWorker.Rows[row.Index]);
                    }
                }

                reName();
            }
            else
            {
                MessageBox.Show("비밀번호 변경시를 제외한 다른 정보는 필수 입력사항입니다.", "경고", MessageBoxButtons.OK);
            }

        }

        private bool checkVal()
        {
            if (txtID.Text == "" || txtName.Text == "" || txtPay.Text == "" || txtPhone.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("편집중인 항목이 초기화됩니다. \r\n 계속하시겠습니까?", "경고", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
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
            if (userid != "master")
            {

                if (Prcd.UserDelete(userid))
                {
                    MessageBox.Show(userid + " 계정이 완전히 제거되었습니다.");
                }
                else
                {
                    MessageBox.Show(userid + " 계정 제거에 실패하였습니다.");
                }

                DataSet ds = Prcd.UserManagementLoad();

                DataTableReader ie = ds.Tables[0].CreateDataReader();



                dgvWorker.DataSource = ds.Tables[0];
                foreach (DataGridViewRow row in dgvWorker.Rows)
                {

                    if (row.Cells[2].Value.ToString() == "delete")
                    {
                        dgvWorker.Rows.Remove(dgvWorker.Rows[row.Index]);
                    }
                }
                reName();
            }
            else
            {
                MessageBox.Show("Master계정은 삭제하실수 없습니다.");
            }
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            string sPattern = "^[ㄱ-ㅎ가-힣]{0,3}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtName.Text, sPattern))
            {
                txtName.Text = "";
                MessageBox.Show("4자리 이하 한글만 입력해주세요");
            }
        }

        private void txtPay_Leave(object sender, EventArgs e)
        {
            string sPattern = "^[0-9]{0,8}$";

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPay.Text, sPattern))
            {
                txtPay.Text = "";
                MessageBox.Show("숫자만 입력해주세요");
            }
        }

        private void txtPwd_Leave(object sender, EventArgs e)
        {
            if (txtPwd.Text.Length >= 1)
            {
                if (txtPwd.Text.Length < 4)
                {
                    MessageBox.Show("비밀번호는 4자리 이상입니다.", "경고", MessageBoxButtons.OK);
                    txtPwd.Text = "";
                }
            }
        }
    }
}
