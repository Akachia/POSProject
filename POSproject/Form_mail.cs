using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace POSproject
{
    public partial class Form_mail : Form
    {
        string file;
        string user;
        public Form_mail()
        {
            InitializeComponent();
        }
        public Form_mail(string user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string str = txtAddress.Text;
            bool chk = false;
            if (str.Contains("@"))
            {
                if (str.Contains("."))
                {
                    if (str.Split('@')[0] != "" && str.Split('@')[1] != "")
                    {
                        if (str.Split('.')[0] != "" && str.Split('.')[1] != "")
                        {
                            if (txtAddress.Text != "")
                            {
                                chk = true;
                            }
                        }
                    }
                }
            }
            if(chk)
            {
                MailAddress mailAddr = new MailAddress("1re@naver.com", user, Encoding.UTF8);
                MailAddress MailAddr2 = new MailAddress(txtAddress.Text, "사장님", Encoding.UTF8);

                SmtpClient smtp = new SmtpClient("smtp.naver.com", 587);

                MailMessage mail = new MailMessage(mailAddr, MailAddr2);

                mail.Subject = "문의";
                mail.Body = txtBody.Text;
                mail.BodyEncoding = Encoding.UTF8;
                mail.SubjectEncoding = Encoding.UTF8;
                if (file != null)
                {
                    FileStream fs = new FileStream(file, FileMode.Open);
                    mail.Attachments.Add(new Attachment(fs, file.Split('\\')[file.Split('\\').Length - 1]));
                }
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("1re@naver.com", "l931127l");



                smtp.Send(mail);

                MessageBox.Show("전송 요청이 완료되었습니다!");
                this.Close();
            }
            else
            {
                MessageBox.Show("주소를 확인해주세요.");
            }

        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            file = null;
            var dlg = openFile.ShowDialog();
            if (dlg == DialogResult.OK)
            { 
                file = openFile.FileName;
                lblFile.Text = file.Split('\\')[file.Split('\\').Length - 1];
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
