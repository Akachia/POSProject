using formSales;
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
    public partial class UserAccount : Form
    {
        Form_Main FM;
        string user;
        TimeSpan time;
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

            FM = (Form_Main)Owner;
            FM.Visible = false;

            
            #region 로드시 직원 정보 출력
            lbl_checkin.Text = lbl_checkin.Text + Prcd.checkin;


            var infoTable = Prcd.CheckInfo(user);

            IDictionaryEnumerator ide = infoTable.GetEnumerator();

            while (ide.MoveNext())
            {

                if (ide.Key.ToString() == "UserName")
                {
                    lbl_name.Text = lbl_name.Text + ide.Value.ToString();
                }
                if (ide.Key.ToString() == "UserPhone")
                {
                    lbl_Phone.Text = lbl_Phone.Text + ide.Value.ToString();
                }
                if (ide.Key.ToString() == "UserPic")
                {
                    byte[] newimg = (byte[])ide.Value;

                    
                    
                    if (ide.Value.ToString() != "")
                    {
                        pic_User.Image = new Bitmap(new MemoryStream(newimg));
                    }
                }
                if (ide.Key.ToString() == "StoreName")
                {
                    lblStoreName.Text = lblStoreName.Text + ide.Value.ToString();

                }
                if (ide.Key.ToString() == "StoreAddr")
                {
                    lblStoreAddr.Text = lblStoreAddr.Text + ide.Value.ToString();

                }
                if (ide.Key.ToString() == "CallNumber")
                {
                    lblStoreCall.Text = lblStoreCall.Text + ide.Value.ToString();

                }
            }
            #endregion



            DataSet ds = Prcd.TodayWorker();
            DataTableReader ie = ds.Tables[0].CreateDataReader();

            while(ie.Read())
            {
                textBox1.Text += ie[0]+" - 출근 : "+ie[1].ToString()+"\r\n";
            }
           
            
            timer1.Start();
        }

        private void btn_mgr_Click(object sender, EventArgs e)
        {
            new Form_UserManagement(user).Show();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            FM.Visible = true;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = DateTime.Now.Subtract(Prcd.checkin);
            lbl_curWorkTime.Text = "근무 시간 : " + time.ToString().Split('.')[0];
        }

       

        private void btn_CheckOut_Click(object sender, EventArgs e)
        {
            
            Prcd.EndWork(user,DateTime.Now);
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_InfoModify_Click(object sender, EventArgs e)
        {
            new Form_UserModify(user).Show();
        }
    }
}
