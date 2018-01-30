using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    public partial class Form_UserModify : Form
    {
        string user;
        string file;
        public Form_UserModify()
        {
            InitializeComponent();
        }
        public Form_UserModify(string user)
        { 


            this.user = user;
            InitializeComponent();
        }
        private void Form_UserModify_Load(object sender, EventArgs e)
        {

            pnl_Modify.Visible = false;
        }

        private void btn_Chk_Click(object sender, EventArgs e)
        {
            if (Prcd.LogIn(user, txt_chkPwd.Text))
            {
                pnl_CheckPwd.Hide();
                pnl_Modify.Visible = true;

                Hashtable info = Prcd.CheckUser(user);


                IDictionaryEnumerator ide = info.GetEnumerator();
                txt_Name.Text = user;
                while (ide.MoveNext())
                {

                    if (ide.Key.ToString() == "UserName")
                    {
                        txt_Id.Text = ide.Value.ToString();
                    }
                    if (ide.Key.ToString() == "UserPhone")
                    {
                        txt_Phone.Text = ide.Value.ToString();
                    }
                    if (ide.Key.ToString() == "UserPic")
                    {
                        byte[] newimg = (byte[])ide.Value;
                        if (ide.Value.ToString() != "")
                        {
                            picUser.Image = new Bitmap(new MemoryStream(newimg));
                        }

                    }
                }


            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string Pwd = txt_Pwd.Text;
            string Phone = txt_Phone.Text;
            byte[] img;
            if (file != null)
            {
                FileStream fs = new FileStream(file.ToString(), FileMode.Open, FileAccess.Read);

                img = new byte[fs.Length];
                fs.Read(img, 0, (int)fs.Length);
            }
            else
            {
                ImageConverter converter = new ImageConverter();
                img = (byte[])converter.ConvertTo(picUser.Image, typeof(byte[]));
                


               

            }

            if (Prcd.UserModify(user, Pwd, Phone, img))
            {
                MessageBox.Show("업데이트에 성공하였습니다.");
            }
            else
            {
                MessageBox.Show("업데이트에 실패하였습니다.");
            }

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            file = null;
            var dlg = openPic.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                picUser.Image = new Bitmap(Image.FromFile(openPic.FileName));
                file = openPic.FileName;
            }
        }

       
    }
}
