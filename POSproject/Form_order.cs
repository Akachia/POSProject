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
    public partial class order_From : Form
    {
        DataTable ds = null;
        int orderTtl_Price = 0;
        int orderTtlSell_Price = 0;
        public order_From()
        {
            InitializeComponent();
        }

        public order_From(DataSet ds) : this()
        {

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
            for (int i = 0; i < 16; i++)
            {
                columnList.Add(i.ToString() + "개");
            }
            for (int i = 0; i < 21; i++)
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
            // 데이터가 없어서 초기 데이터를 설정한다.
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                item.Cells[5].Value = "0box";
                item.Cells[6].Value = "0개";
            }

            dataGridView1.Columns[1].HeaderText = "상품번호";
            dataGridView1.Columns[2].HeaderText = "이름";
            dataGridView1.Columns[3].HeaderText = "가격";
            dataGridView1.Columns[4].HeaderText = "원가";
            dataGridView1.Columns[7].HeaderText = "현재수량";
        }


        private void Order_TtlPrice_Sum()
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                orderTtl_Price += int.Parse(item.Cells[4].Value.ToString());
            }
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                orderTtlSell_Price += int.Parse(item.Cells[3].Value.ToString());
            }

            lbl_TtlPrice.Text = orderTtl_Price.ToString();
            lbl_TtlsellPrice.Text = orderTtlSell_Price.ToString();
        }

        private void order_From_Load(object sender, EventArgs e)
        {
            POS_Stock pOS_ = Owner as POS_Stock;
            
            ds = pOS_.MakeOrderTable().Copy();
            
            dataGridView1.DataSource = pOS_.MakeOrderTable().Copy();

            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            label1.Text = pOS_.label1.Text;
            Timer timer =  new Timer();
            timer.Tick += Timer1_Tick1;
            timer.Start();
            Order_TtlPrice_Sum();
            MakeComboCell();
            //수량을 콤보박스로 표현하기 
            //dataGridView1.Columns["Column2"].DisplayIndex = 4;
        }

        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int numVal = int.Parse(ds.Rows[dataGridView1.CurrentRow.Index].ItemArray[2].ToString());
            int numVal1 = int.Parse(ds.Rows[dataGridView1.CurrentRow.Index].ItemArray[3].ToString());
            //동적 생성한 셀에 데이터가 없어서 오류가 난다.
            //MessageBox.Show();
            if (dataGridView1.CurrentCell.GetType() == new DataGridViewComboBoxCell().GetType())
            {
                int boxNum = int.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString().Split('b')[0]);
                int boxNum1 = int.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString().Split('개')[0]);

                //MessageBox.Show(boxNum.ToString());
                //MessageBox.Show(boxNum1.ToString());
                dataGridView1.CurrentRow.Cells[3].Value = (boxNum * 15) * numVal + (boxNum1 * numVal);
                dataGridView1.CurrentRow.Cells[4].Value = (boxNum * 15) * numVal1 + (boxNum1 * numVal1);
                if (boxNum == 0)
                {
                    dataGridView1.CurrentRow.Cells[3].Value = numVal;
                }
                if (boxNum1 == 0)
                {
                    dataGridView1.CurrentRow.Cells[4].Value = numVal1;
                }
            }
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
