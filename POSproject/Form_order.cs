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
using System.Data.OleDb;
using System.Windows.Forms;
using System.Collections;
/// <summary>
/// 자주 발주하는 제품 선택 -> 제품테이블에 데이터가 있어야 되서 안됨
/// 이 폼은 재고 테이블에서 데이터를 가져와 발주 데이터를 작성하고 발주 테이블에 커밋하는 역할을 한다.
/// </summary>
namespace POSproject_KSM
{
    public partial class order_From : Form
    {
        Timer timer;
        private Hashtable hashtable = new Hashtable();
        DataTable ds = null;
        DataTable ds2 = null;
        private Hashtable preference = new Hashtable();

        int orderTtl_Price = 0;
        int orderTtlSell_Price = 0;
        int massageCount = 0;
        int productNo = 0;
        //decimal barcodeNo = 0;

        public order_From()
        {
            InitializeComponent();
        }

        public order_From(string id) : this()
        {
            lbl_User.Text = id;
        }

        public order_From(DataSet ds, string id) : this()
        {
            lbl_User.Text = id;
            this.ds = ds.Tables[0];
            ds2 = this.ds.Copy();
            ds2.Columns.RemoveAt(0);
            ds2.Columns.RemoveAt(0);

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
            dataGridView1.Columns.Insert(6, boxColumn);
            boxColumn1.DataSource = columnList1;
            boxColumn1.Width = 75;
            boxColumn1.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            boxColumn1.HeaderText = "발주 개수(box)";
            dataGridView1.Columns.Insert(6, boxColumn1);
            // 데이터가 없어서 초기 데이터를 설정한다.
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                item.Cells[6].Value = "0box";
                item.Cells[7].Value = "0개";
            }
            dataGridView1.Columns[1].HeaderText = "상품번호";
            dataGridView1.Columns[2].HeaderText = "이름";
            dataGridView1.Columns[3].HeaderText = "카테고리";
            dataGridView1.Columns[4].HeaderText = "가격";
            dataGridView1.Columns[5].HeaderText = "원가";
            dataGridView1.Columns[8].HeaderText = "현재수량";
        }

        private decimal GenBarcode(decimal bar)
        {
            string str = "1880";
            string str2;
            DateTime date = DateTime.Now;
            str2 = date.ToShortDateString().Split('-')[0];
            str2 += date.ToShortDateString().Split('-')[1];
            str2 += date.ToShortDateString().Split('-')[2];
            str2 = str2.Substring(2);
            str += str2;

            str += bar.ToString().Substring(10);
            return decimal.Parse(str);
        }

        /// <summary>
        /// 전체 발주가격을 계산하는 메서드
        /// </summary>
        private void Order_TtlPrice_Sum()
        {
            orderTtl_Price = 0;
            orderTtlSell_Price = 0;
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                orderTtl_Price += int.Parse(item.Cells[5].Value.ToString());
            }
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                orderTtlSell_Price += int.Parse(item.Cells[4].Value.ToString());
            }
            string ttlPrice = String.Format("{0:#,###}", orderTtl_Price);
            string ttlSellPrice = String.Format("{0:#,###}", orderTtlSell_Price);

            lbl_TtlPrice.Text = ttlPrice + "원";
            lbl_TtlsellPrice.Text = ttlSellPrice + "원";
        }

        private void order_From_Load(object sender, EventArgs e)
        {

            if (ds2 != null)
            {
                Load_FromDOrder();
                Dgv_MakeHash(ds2);
            }
            else
            {
                Load_FromStock();
                Dgv_MakeHash(ds);
            }
            dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            MakePreference();
        }
        /// <summary>
        /// OrderDetail form에서 넘어올때 실행되는 함수
        /// </summary>
        private void Load_FromDOrder()
        {
            dataGridView1.DataSource = ds2;
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            label1.Text = DateTime.Now.ToLongTimeString();
            timer = new Timer();
            timer.Tick += Timer1_Tick1;
            timer.Start();
            MakeComboCell();
        }
        /// <summary>
        /// stock폼에서 넘어올때 실행되는 함수
        /// </summary>
        private void Load_FromStock()
        {
            POS_Stock pOS_ = Owner as POS_Stock;
            if (ds == null)
            {
                ds = pOS_.MakeOrderTable();
                if (ds2 != null)
                {
                    ds2.Clear();
                }
                ds2 = ds.Copy();
            }

            dataGridView1.DataSource = ds2;
            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);
            dataGridView1.CellValueChanged += DataGridView1_CellValueChanged;
            label1.Text = pOS_.label1.Text;
            timer = new Timer();
            timer.Tick += Timer1_Tick1;
            timer.Start();
            MakeComboCell();
            pOS_.CheckBoxinit();

            //수량을 콤보박스로 표현하기 
            //dataGridView1.Columns["Column2"].DisplayIndex = 4;
        }

        /// <summary>
        /// 데이터 그리드뷰에서 원가랑 가격을 저장할 해시테이블을 사용한다.
        /// 해시테이블의 구조는 key는 제품번호, value는 string배열을 사용해서 저장했다.
        /// </summary>
        /// <param name="dataSet"></param>
        private void Dgv_MakeHash(DataTable dataSet)
        {
            foreach (DataRow item in dataSet.Rows)
            {
                string[] str = { item[3].ToString(), item[4].ToString() };
                hashtable.Add(item[0].ToString(), str);
            }
        }

        /// <summary>
        /// 그리드뷰에서 셀의 값이 변경되면 실행되는 함수 콤보박스만 해당된다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.GetType() == new DataGridViewComboBoxCell().GetType())
                {
                    string[] strs = (String[])hashtable[dataGridView1.CurrentRow.Cells[1].Value.ToString()];
                    int numVal = int.Parse(strs[0]);
                    int numVal1 = int.Parse(strs[1]);
                    //int numVal = int.Parse(ds.Rows[dataGridView1.CurrentRow.Index].ItemArray[4].ToString());
                    //int numVal1 = int.Parse(ds.Rows[dataGridView1.CurrentRow.Index].ItemArray[5].ToString());
                    int boxNum = int.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString().Split('b')[0]);
                    int boxNum1 = int.Parse(dataGridView1.CurrentRow.Cells[7].Value.ToString().Split('개')[0]);

                    if (boxNum == 0 && boxNum1 == 0)
                    {
                        dataGridView1.CurrentRow.Cells[4].Value = numVal;
                        dataGridView1.CurrentRow.Cells[5].Value = numVal1;
                    }
                    else
                    {
                        dataGridView1.CurrentRow.Cells[4].Value = (boxNum * 15) * numVal + (boxNum1 * numVal);
                        dataGridView1.CurrentRow.Cells[5].Value = (boxNum * 15) * numVal1 + (boxNum1 * numVal1);
                    }
                    Order_TtlPrice_Sum();
                }
                //발주 가격과 판매가격을 알려주는 함수
            }
            catch (NullReferenceException)
            {
                if (massageCount == 0)
                {
                    MessageBox.Show("발주 물건을 선택해 주세요!", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    massageCount++;
                }
            }
        }
        // 타이머 함수
        private void Timer1_Tick1(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.timer.Stop();
            this.Close();
        }
        /// <summary>
        /// 모든 채크박스를 클릭해주는 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_allCk_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkBoxCell = (DataGridViewCheckBoxCell)item.Cells[0];
                checkBoxCell.Value = true;
            }
        }
        /// <summary>
        /// 보내기 함수
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Send_Click(object sender, EventArgs e)
        {
            DataSet oDs = new DataSet();
            int last_idx = 0;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                //MessageBox.Show(last_idx.ToString());

                using (SqlCommand cmd = new SqlCommand("InsertOrders2", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UOrderTtlPrice", orderTtlSell_Price);
                    cmd.Parameters.AddWithValue("@UOrderCustomer", lbl_User.Text);

                    int i = cmd.ExecuteNonQuery();
                    if (i == 0)
                    {
                        MessageBox.Show("통신실패 다시 해주세요");
                        return;
                    }//if
                }
                int hi = 0;
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    using (SqlCommand cmd = new SqlCommand("InsertStockOrder", con))
                    {

                        DataGridViewCheckBoxCell dgvCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[j].Cells[0];
                        if (dgvCell.Value != new DataGridViewCheckBoxCell().FalseValue)
                        {
                            //MessageBox.Show(" : " + (dgvCell.RowIndex +1).ToString());
                            cmd.CommandType = CommandType.StoredProcedure;
                            //cmd.Parameters.AddWithValue("@IOrderNo", last_idx);
                            cmd.Parameters.AddWithValue("@IProductNo", dataGridView1.Rows[j].Cells[1].Value);

                            int boxNum = int.Parse(dataGridView1.Rows[j].Cells[6].Value.ToString().Split('b')[0]);
                            int boxNum1 = int.Parse(dataGridView1.Rows[j].Cells[7].Value.ToString().Split('개')[0]);

                            cmd.Parameters.AddWithValue("@IProductOrderQuantity", ((boxNum * 15) + boxNum1));
                            hi = cmd.ExecuteNonQuery();

                        }//using
                    }
                }
                if (hi > 0)
                {
                    MessageBox.Show("발주 성공");
                }
                else
                {
                    MessageBox.Show("통신실패 다시 해주세요");
                    return;
                }
            }
        }

        private void MakePreference()
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("[dbo].SelectPerferences", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        preference.Add("BusinessNo", sdr["BusinessNo"].ToString());
                        preference.Add("Addr", sdr["Addr"].ToString());
                        preference.Add("StoreName", sdr["StoreName"].ToString());
                        preference.Add("StoreOwner", sdr["StoreOwner"].ToString());
                        preference.Add("CallNumber", sdr["CallNumber"].ToString());
                    }
                }
                con.Close();
            }
        }
        
        private Image GenBarcodeImg()
        {
            BarcodeLib.Barcode b = new BarcodeLib.Barcode();
            string barcode = null;
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["PosSystem"].ConnectionString))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SelectOrderBarcode", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        barcode = sdr["OrderBarcode"].ToString();
                        productNo = (int)sdr["OrderNo"]+1;
                        //MessageBox.Show("Test : "+barcode);
                    }

                    barcode = (Int64.Parse(barcode) + 1).ToString();
                }
                con.Close();
            }

            int W = 300;//152.2
            int H = 75;//41.4
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;

            //barcode alignment
            b.Alignment = BarcodeLib.AlignmentPositions.CENTER;
            //switch

            BarcodeLib.TYPE type = BarcodeLib.TYPE.UNSPECIFIED;

            type = BarcodeLib.TYPE.ITF14;

            try
            {

                b.IncludeLabel = true;

                b.RotateFlipType = (RotateFlipType)Enum.Parse(typeof(RotateFlipType), "rotatenoneflipnone", true);

                b.LabelPosition = BarcodeLib.LabelPositions.BOTTOMCENTER;


                //===== Encoding performed here =====
                
                return b.Encode(type, barcode, Color.Black, Color.White, W, H);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return POSproject.Properties.Resources.noImage;
            }
        }

        private void btn_ExcelShow_Click(object sender, EventArgs e)
        {

            string excelPath = System.IO.Path.GetTempPath();
                //.Combine(System.Windows.Forms.Application.StartupPath, "Resources"); ;
            string excelSave = excelPath+"order"
            + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + ".xlsx";

            //MessageBox.Show(excelPath);
            Clipboard.SetDataObject(GenBarcodeImg());
            Microsoft.Office.Interop.Excel.Application excelApp = null;
            Microsoft.Office.Interop.Excel.Workbook wb = null;
            Microsoft.Office.Interop.Excel.Worksheet ws = null;

            excelApp = new Microsoft.Office.Interop.Excel.Application();
            //기존 데이터 불러오기
            //wb = excelApp.Workbooks.Open(excelPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            wb = excelApp.Workbooks.Add();
            // 첫번째 Worksheet
            ws = wb.Worksheets.get_Item(1) as Microsoft.Office.Interop.Excel.Worksheet;
            ///전체
            Microsoft.Office.Interop.Excel.Range range = null;
            ws.Columns.ColumnWidth = 10.75;
            range = ws.Range[ws.Cells[1, 1], ws.Cells[43, 7]];
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;
            ///헤더
            range = ws.Range[ws.Cells[1, 1], ws.Cells[3, 7]];
            range.Merge();
            range.Value2 = "발주서";
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;
            ///셀 나누기
            range = ws.Range[ws.Cells[4, 1], ws.Cells[9, 7]];
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideHorizontal].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlInsideVertical].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;

            range = ws.Range[ws.Cells[40, 1], ws.Cells[40, 7]];
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;

            range = ws.Range[ws.Cells[4, 1], ws.Cells[40, 7]];
            range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            range.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
            ///업주정보
            range = ws.Range[ws.Cells[4, 1], ws.Cells[8, 1]];
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;

            ws.Cells[4, 1] = "사업자번호";
            range = ws.Range[ws.Cells[5, 1], ws.Cells[6, 1]];
            range.Merge();
            range.Value2 = "주소";
            ws.Cells[7, 1] = "발주번호";
            ws.Cells[8, 1] = "발주일자";
            ///사업자번호
            range = ws.Range[ws.Cells[4, 2], ws.Cells[4, 4]];
            range.Merge();
            range.Value2 = preference["BusinessNo"];

            ///주소 병합칸
            range = ws.Range[ws.Cells[5, 2], ws.Cells[6, 4]];
            range.Merge();
            range.Value2 = preference["Addr"];

            ///발주번호
            range = ws.Range[ws.Cells[7, 2], ws.Cells[7, 4]];
            range.Merge();
            range.Value2 = productNo;

            ///발주일자
            range = ws.Range[ws.Cells[8, 2], ws.Cells[8, 4]];
            range.Merge();
            range.Value2 = DateTime.Now.ToShortDateString();

            range = ws.Range[ws.Cells[4, 5], ws.Cells[8, 5]];
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeRight].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeLeft].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;

            ws.Cells[4, 5] = "상호명";
            range = ws.Range[ws.Cells[4, 6], ws.Cells[4, 7]];
            range.Merge();
            range.Value2 = preference["StoreName"]; 

            ws.Cells[5, 5] = "대표자";
            range = ws.Range[ws.Cells[5, 6], ws.Cells[5, 7]];
            range.Merge();
            range.Value2 = preference["StoreOwner"];

            ws.Cells[6, 5] = "연락처";
            range = ws.Range[ws.Cells[6, 6], ws.Cells[6, 7]];
            range.Merge();
            range.Value2 = preference["CallNumber"];

            ws.Cells[7, 5] = "작성자";
            range = ws.Range[ws.Cells[7, 6], ws.Cells[7, 7]];
            range.Merge();
            range.Value2 = "작성자";

            ws.Cells[8, 5] = "발주금";
            range = ws.Range[ws.Cells[8, 6], ws.Cells[8, 7]];
            range.Merge();
            range.Value2 = orderTtl_Price;

            range = ws.Range[ws.Cells[9, 1], ws.Cells[9, 7]];
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeBottom].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
            range.Borders[Microsoft.Office.Interop.Excel.XlBordersIndex.xlEdgeTop].Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThick;

            ws.Cells[9, 1] = "상품번호";
            ws.Cells[9, 2] = "상품명";
            ws.Cells[9, 3] = "카테고리";
            ws.Cells[9, 4] = "판매가";
            ws.Cells[9, 5] = "원가";
            ws.Cells[9, 6] = "수량";
            ws.Cells[9, 7] = "발주가";


            DataGridViewRowCollection rows = dataGridView1.Rows;

            for (int i = 10; i < rows.Count + 10; i++)
            {
                string[] strs = (String[])hashtable[rows[i - 10].Cells[1].Value.ToString()];
                int numVal1 = int.Parse(strs[1]);
                int numVal = int.Parse(strs[0]);
                for (int j = 1; j < 8; j++)
                {
                    if (j < 4)
                    {
                        ws.Cells[i, j] = rows[i - 10].Cells[j].Value;
                    }
                    else if (j == 4)
                    {
                        ws.Cells[i, j] = numVal;
                    }
                    else if (j == 5)
                    {

                        ws.Cells[i, j] = numVal1;
                    }
                    else if (j == 6)
                    {
                        ws.Cells[i, j] = (int.Parse(rows[i - 10].Cells[6].Value.ToString().Split('b')[0]) * 15)
                            + int.Parse(rows[i - 10].Cells[7].Value.ToString().Split('개')[0]);
                    }
                    else
                    {
                        ws.Cells[i, j] = rows[i - 10].Cells[5].Value + "원";
                    }
                }
            }

            try
            {
                range = ws.Range[ws.Cells[rows.Count + 12, 3], ws.Cells[rows.Count + 12, 5]];
                range.Select();
                ws.Paste();
                //Clipboard.Clear();
            }
            catch (Exception)
            {
                MessageBox.Show("바코드 생성 실패");
            }

            // 엑셀파일 저장
           
            // wb.Close();
            //wb = excelApp.Workbooks.Open(excelPath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
            //    Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            excelApp.Visible = true;
            bool userDidntCancel = excelApp.Dialogs[Microsoft.Office.Interop.Excel.XlBuiltInDialog.xlDialogPrintPreview].Show(
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            //wb.Close(false, Type.Missing, Type.Missing);
            excelApp.Quit();
            //MessageBox.Show("저장되었습니다.");

            GC.Collect();
            GC.WaitForPendingFinalizers();
            //wb.Close(false, Type.Missing, Type.Missing);

            this.Show();
            ReleaseExcelObject(ws);
            ReleaseExcelObject(wb);
            ReleaseExcelObject(excelApp);

            //this.Show();
            //DialogResult dr = MessageBox.Show(excelPath + "에 저장됩니다. 저장하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //this.Show();
            //switch (dr)
            //{
            //    case DialogResult.Yes:
            //        //wb.SaveAs(excelSave);
            //        wb.Close(false, Type.Missing, Type.Missing);
            //        excelApp.Quit();
            //        MessageBox.Show("저장되었습니다.");
                    
            //        GC.Collect();
            //        GC.WaitForPendingFinalizers();
            //        //wb.Close(false, Type.Missing, Type.Missing);
                    
            //        this.Show();
            //        ReleaseExcelObject(ws);
            //        ReleaseExcelObject(wb);
            //        ReleaseExcelObject(excelApp);
            //        break;
            //    case DialogResult.No:
            //        MessageBox.Show("저장하지 않았습니다.");
                    
            //        GC.Collect();
            //        GC.WaitForPendingFinalizers();
                    
            //        //excelApp.Quit();
            //        this.Show();
            //        ReleaseExcelObject(ws);
            //        ReleaseExcelObject(wb);
            //        ReleaseExcelObject(excelApp);
            //        break;
            //}
            //return;
        }

        private static void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
