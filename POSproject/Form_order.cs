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
/// <summary>
/// 자주 발주하는 제품 선택 -> 제품테이블에 데이터가 있어야 되서 안됨
/// 이 폼은 재고 테이블에서 데이터를 가져와 발주 데이터를 작성하고 발주 테이블에 커밋하는 역할을 한다.
/// </summary>
namespace POSproject_KSM
{
    public partial class Form_order : Form
    {
        DataSet ds = null;
        DataSet ds2 = null;
        public Form_order()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Dvg에 콤보박스를 만드는 함수
        /// </summary>
        private void MakeComboCell()
        {
            DataGridViewComboBoxColumn boxColumn = new DataGridViewComboBoxColumn();
            List<string> columnList = new List<string>();

            DataGridViewComboBoxColumn boxColumn1 = new DataGridViewComboBoxColumn();
            List<string> columnList1 = new List<string>();
            for (int i = 1; i < 16; i++)
            {
                columnList.Add(i.ToString() + "개");
            }
            for (int i = 1; i < 21; i++)
            {
                columnList1.Add(i.ToString() + "box");
            }
            boxColumn.DataSource = columnList;
            boxColumn.Width = 75;
            boxColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            boxColumn.HeaderText = "발주 개수";
            dataGridView1.Columns.Insert(5, boxColumn);
            boxColumn1.DataSource = columnList1;
            boxColumn1.Width = 75;
            boxColumn1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            boxColumn1.HeaderText = "발주 개수(box)";
            dataGridView1.Columns.Insert(5, boxColumn1);
        }

        public Form_order(DataSet ds): this()
        {

        }

        private void order_From_Load(object sender, EventArgs e)
        {
            Form_stock pOS_ = Owner as Form_stock;
            ds = new DataSet();

            DataTable dt = new DataTable();
            //dt = ds2.Tables[0];

            //dt.Columns[1];
            //ds.Tables[0].Columns.Add();

            //ds2 = pOS_.GetDataSet();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SelectOrders", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter dataAdapter = new SqlDataAdapter();
                    dataAdapter.SelectCommand = cmd;

                    //dataAdapter.Fill(ds);

                    dataGridView1.DataSource = pOS_.MakeOrderTable();
                }
            }
            label1.Text = pOS_.label1.Text;
            Timer timer =  new Timer();
            timer.Tick += Timer1_Tick1;
            timer.Start();

            MakeComboCell();
            //수량을 콤보박스로 표현하기 
            //dataGridView1.Columns["Column2"].DisplayIndex = 4;
            
        }

        private void Timer1_Tick1(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
