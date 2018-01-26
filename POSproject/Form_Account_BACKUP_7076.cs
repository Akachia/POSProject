using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TF
{
    public partial class Form_Account : Form
    {
        DataSet ds;
<<<<<<< HEAD
=======
        List<string[]> orderList = new List<string[]>();
        List<string[]> list = new List<string[]>();
        List<string[]> chartList = new List<string[]>();
        DateTime time1;
        string thisYear = "";
>>>>>>> origin/이호현

        public Form_Account()
        {
            InitializeComponent();
        }

<<<<<<< HEAD
        private void button3_Click(object sender, EventArgs e)
        {
            //new Form1().Show();
        }

=======
>>>>>>> origin/이호현
        private void Form_Account_Load(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
<<<<<<< HEAD
                con.Open();
                
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SelectTables", con);
                
                ds = new DataSet();
                adapter.Fill(ds);
                
                DataTable table1 = ds.Tables[0]; // SellDate, ProductName, SellCount, SellPrice, CardWhether
                DataTable table2 = ds.Tables[1]; // OrderTotalPrice, UserPay, WorkTime

                int cashD = 0;
                int cardD = 0;
                int cashM = 0;
                int cardM = 0;
                string standardDate = "";

                foreach (DataRow row in table1.Rows)
                {
                    if (row.ItemArray[4].ToString() == "False")
                    {
                        cashD += int.Parse(row.ItemArray[3].ToString());
                    }
                    else
                    {
                        cardD += int.Parse(row.ItemArray[3].ToString());
=======
                time1 = DateTime.Now;
                con.Open();
                lblTime.Text = DateTime.Now.ToString();
                lblDate.Text = time1.ToShortDateString();

                timer1.Start();
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand("SelectTables", con);

                ds = new DataSet();
                adapter.Fill(ds);

                DataTable table1 = ds.Tables[0]; // SellDate, ProductName, SellCount, SellPrice, CardWhether
                DataTable table2 = ds.Tables[1]; // OrderDate, OrderTotalPrice
                DataTable table3 = ds.Tables[2]; // UserPay, UserCheckIn, WorkingTime

                int cashD = 0; // 일 현금 매출
                int cardD = 0; // 일 카드 매출
                int cashM = 0; // 월 현금 매출
                int cardM = 0; // 월 카드 매출
                int order = 0; // 입고가
                int salary = 0; // 알바비
                string standardDate = "";
                string orderDate = "";
                string workDate = "";
                string[] orderArr;
                string[] salaryArr;
                int rowCount = 0;
                int rowCount2 = 0;

                foreach (DataRow row in table1.Rows)
                {
                    string[] ar = row.ItemArray[0].ToString().Split(' ');

                    if (ar[0] == lblDate.Text)
                    {
                        if (row.ItemArray[4].ToString() == "False")
                        {
                            cashD += int.Parse(row.ItemArray[3].ToString());
                        }
                        else
                        {
                            cardD += int.Parse(row.ItemArray[3].ToString());
                        }
>>>>>>> origin/이호현
                    }
                }

                txtCashD.Text += cashD;
                txtCardD.Text += cardD;
                txtTotalD.Text = (cashD + cardD).ToString();

<<<<<<< HEAD
                foreach (DataRow row in table1.Rows)
                {
                    dataGridView1.Rows.Add(row.ItemArray[1], row.ItemArray[3], row.ItemArray[2]);
=======
                foreach (DataRow row in table2.Rows)
                {
                    rowCount += 1;
                    string[] date = row.ItemArray[0].ToString().Split('-');
                    if (orderDate == "")
                    {
                        orderDate = date[0] + " - " + date[1];
                    }

                    if (orderDate == (date[0] + " - " + date[1]))
                    {
                        order += int.Parse(row.ItemArray[1].ToString());
                        if (table2.Rows.Count == rowCount)
                        {
                            orderArr = new string[2];
                            orderArr[0] = orderDate;
                            orderArr[1] = order.ToString();

                            orderList.Add(orderArr);
                        }
                    }
                    else
                    {
                        orderArr = new string[2];
                        orderArr[0] = orderDate;
                        orderArr[1] = order.ToString();

                        orderList.Add(orderArr);
                        orderDate = date[0] + " - " + date[1];
                        order = int.Parse(row.ItemArray[1].ToString());
                    }
                }

                foreach (DataRow row in table3.Rows)
                {
                    rowCount2 += 1;
                    string[] date = row.ItemArray[0].ToString().Split('-');

                    if (workDate == "")
                    {
                        workDate = date[0] + " - " + date[1];
                    }

                    if (workDate == date[0] + " - " + date[1])
                    {
                        salary += int.Parse(row.ItemArray[1].ToString()) * int.Parse(row.ItemArray[2].ToString());
                        if (table3.Rows.Count == rowCount2)
                        {
                            salaryArr = new string[2];
                            salaryArr[0] = workDate;
                            salaryArr[1] = salary.ToString();

                            list.Add(salaryArr);
                        }
                    }
                    else
                    {
                        salaryArr = new string[2];
                        salaryArr[0] = workDate;
                        salaryArr[1] = salary.ToString();

                        list.Add(salaryArr);

                        workDate = date[0] + " - " + date[1];
                        salary = int.Parse(row.ItemArray[1].ToString()) * int.Parse(row.ItemArray[2].ToString());
                    }
                }

                //foreach (string[] ar in list)
                //{
                //    MessageBox.Show(ar[0] + ", " + ar[1]);
                //}

                foreach (DataRow row in table1.Rows)
                {
                    if (row.ItemArray[0].ToString() == lblDate.Text)
                    {
                        dataGridView1.Rows.Add(row.ItemArray[1], row.ItemArray[3], row.ItemArray[2]);
                    }
>>>>>>> origin/이호현

                    string[] date = row.ItemArray[0].ToString().Split('-');

                    if (standardDate == "")
                    {
                        standardDate = date[0] + " - " + date[1];
                    }

<<<<<<< HEAD
                    if(standardDate == (date[0] + " - " + date[1]))
=======
                    if (standardDate == (date[0] + " - " + date[1]))
>>>>>>> origin/이호현
                    {
                        if (row.ItemArray[4].ToString() == "False")
                        {
                            cashM += int.Parse(row.ItemArray[3].ToString());
                        }
                        else
                        {
                            cardM += int.Parse(row.ItemArray[3].ToString());
                        }
                    }
                    else
                    {
<<<<<<< HEAD
                        dataGridView2.Rows.Add(standardDate, cashM, cardM, cashM + cardM, 0, 0, 0);
=======
                        foreach (string[] arr in orderList)
                        {
                            if (arr[0] == standardDate)
                            {
                                foreach (string[] arr2 in list)
                                {
                                    if (arr2[0] == standardDate)
                                    {
                                        dataGridView2.Rows.Add(standardDate, cashM, cardM, cashM + cardM, arr[1], arr2[1], cashM + cardM - int.Parse(arr[1].ToString()) - int.Parse(arr2[1].ToString()));
                                        chartList.Add(new string[] { standardDate, (cashM + cardM).ToString(), (cashM + cardM - int.Parse(arr[1].ToString()) - int.Parse(arr2[1].ToString())).ToString() });
                                    }
                                }
                            }
                        }
>>>>>>> origin/이호현
                        standardDate = date[0] + " - " + date[1];
                        if (row.ItemArray[4].ToString() == "False")
                        {
                            cashM = int.Parse(row.ItemArray[3].ToString());
<<<<<<< HEAD
                        }
                        else
                        {
=======
                            cardM = 0;
                        }
                        else
                        {
                            cashM = 0;
>>>>>>> origin/이호현
                            cardM = int.Parse(row.ItemArray[3].ToString());
                        }
                    }
                }
<<<<<<< HEAD

                dataGridView2.Rows.Add(standardDate, cashM, cardM, cashM + cardM, 0, 0, 0);

                //this.dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
=======
                foreach (string[] arr in orderList)
                {
                    if (arr[0] == standardDate)
                    {
                        foreach (string[] arr2 in list)
                        {
                            if (arr2[0] == standardDate)
                            {
                                dataGridView2.Rows.Add(standardDate, cashM, cardM, cashM + cardM, arr[1], arr2[1], cashM + cardM - int.Parse(arr[1].ToString()) - int.Parse(arr2[1].ToString()));
                                chartList.Add(new string[] { standardDate, (cashM + cardM).ToString(), (cashM + cardM - int.Parse(arr[1].ToString()) - int.Parse(arr2[1].ToString())).ToString() });
                            }
                        }
                    }
                }
            }
        }

        private void btnPrevDate_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                dataGridView1.Rows.Clear();

                DataTable table1 = ds.Tables[0];
                TimeSpan time = new TimeSpan(1, 0, 0, 0);
                time1 = time1 - time;
                lblDate.Text = time1.ToShortDateString();

                int cashD = 0; // 일 현금 매출
                int cardD = 0; // 일 카드 매출

                foreach (DataRow row in table1.Rows)
                {
                    string[] ar = row.ItemArray[0].ToString().Split(' ');

                    if (ar[0] == lblDate.Text)
                    {
                        if (row.ItemArray[4].ToString() == "False")
                        {
                            cashD += int.Parse(row.ItemArray[3].ToString());
                        }
                        else
                        {
                            cardD += int.Parse(row.ItemArray[3].ToString());
                        }
                        dataGridView1.Rows.Add(row.ItemArray[1], row.ItemArray[3], row.ItemArray[2]);
                    }

                    txtCardD.Text = cardD.ToString();
                    txtCashD.Text = cashD.ToString();
                    txtTotalD.Text = (cardD + cashD).ToString();
                }
            }
        }

        private void btnNextDate_Click(object sender, EventArgs e)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                dataGridView1.Rows.Clear();

                DataTable table1 = ds.Tables[0];
                TimeSpan time = new TimeSpan(1, 0, 0, 0);
                time1 = time1 + time;
                lblDate.Text = time1.ToShortDateString();

                int cashD = 0; // 일 현금 매출
                int cardD = 0; // 일 카드 매출

                foreach (DataRow row in table1.Rows)
                {
                    string[] ar = row.ItemArray[0].ToString().Split(' ');

                    if (ar[0] == lblDate.Text)
                    {
                        if (row.ItemArray[4].ToString() == "False")
                        {
                            cashD += int.Parse(row.ItemArray[3].ToString());
                        }
                        else
                        {
                            cardD += int.Parse(row.ItemArray[3].ToString());
                        }
                        dataGridView1.Rows.Add(row.ItemArray[1], row.ItemArray[3], row.ItemArray[2]);
                    }

                    txtCardD.Text = cardD.ToString();
                    txtCashD.Text = cashD.ToString();
                    txtTotalD.Text = (cardD + cashD).ToString();
                }
            }
        }

        private void btnChart_Click(object sender, EventArgs e)
        {
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();

            thisYear = DateTime.Now.Year.ToString();

            foreach (string[] arr in chartList)
            {
                string[] temp = arr[0].Split(' ');

                if (temp[0] == thisYear)
                {
                    chart.Series[0].Points.AddXY(arr[0], int.Parse(arr[1]));
                    chart.Series[1].Points.AddXY(arr[0], int.Parse(arr[2]));
                }
            }
        }

        private void btnPrevYear_Click_1(object sender, EventArgs e)
        {
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();
            thisYear = (int.Parse(thisYear) - 1).ToString();

            foreach (string[] arr in chartList)
            {
                string[] temp = arr[0].Split(' ');

                if (temp[0] == thisYear)
                {
                    chart.Series[0].Points.AddXY(arr[0], int.Parse(arr[1]));
                    chart.Series[1].Points.AddXY(arr[0], int.Parse(arr[2]));
                }
            }
        }

        private void btnNextYear_Click_1(object sender, EventArgs e)
        {
            chart.Series[0].Points.Clear();
            chart.Series[1].Points.Clear();
            thisYear = (int.Parse(thisYear) + 1).ToString();

            foreach (string[] arr in chartList)
            {
                string[] temp = arr[0].Split(' ');

                if (temp[0] == thisYear)
                {
                    chart.Series[0].Points.AddXY(arr[0], int.Parse(arr[1]));
                    chart.Series[1].Points.AddXY(arr[0], int.Parse(arr[2]));
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGoMain2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
>>>>>>> origin/이호현
        }
    }
}
