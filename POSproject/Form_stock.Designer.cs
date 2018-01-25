namespace POSproject_KSM
{
    partial class POS_Stock
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            System.Windows.Forms.Label label12;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Stock_exit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_StUpdate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tb_StCate = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_StName = new System.Windows.Forms.TextBox();
            this.tb_StQunt = new System.Windows.Forms.TextBox();
            this.tb_StPrice = new System.Windows.Forms.TextBox();
            this.tb_TtlPrice = new System.Windows.Forms.TextBox();
            this.tb_StBar = new System.Windows.Forms.TextBox();
            this.tb_ShelfLIfe = new System.Windows.Forms.TextBox();
            this.tb_TtlSell = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_LstOrd = new System.Windows.Forms.Button();
            this.btn_NewStock = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(7, 69);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(65, 12);
            label4.TabIndex = 3;
            label4.Text = "상품 종류 :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(7, 96);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(65, 12);
            label5.TabIndex = 4;
            label5.Text = "상품 이름 :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(7, 123);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(65, 12);
            label6.TabIndex = 5;
            label6.Text = "제품 수량 :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(231, 69);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(81, 12);
            label7.TabIndex = 10;
            label7.Text = "총 판매 금액 :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(7, 150);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(69, 12);
            label8.TabIndex = 9;
            label8.Text = "제품 가격 : ";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(231, 96);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(77, 12);
            label10.TabIndex = 12;
            label10.Text = "제품 바코드 :";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(231, 123);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(61, 12);
            label11.TabIndex = 13;
            label11.Text = "유통기한 :";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(231, 150);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(77, 12);
            label12.TabIndex = 15;
            label12.Text = "누적 판매량 :";
            // 
            // Stock_exit
            // 
            this.Stock_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Stock_exit.Location = new System.Drawing.Point(722, 522);
            this.Stock_exit.Name = "Stock_exit";
            this.Stock_exit.Size = new System.Drawing.Size(75, 75);
            this.Stock_exit.TabIndex = 5;
            this.Stock_exit.Text = "나가기";
            this.Stock_exit.UseVisualStyleBackColor = true;
            this.Stock_exit.Click += new System.EventHandler(this.Stock_exit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(722, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 75);
            this.button1.TabIndex = 1;
            this.button1.Text = "발주";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_StUpdate
            // 
            this.btn_StUpdate.Location = new System.Drawing.Point(600, 66);
            this.btn_StUpdate.Name = "btn_StUpdate";
            this.btn_StUpdate.Size = new System.Drawing.Size(119, 102);
            this.btn_StUpdate.TabIndex = 0;
            this.btn_StUpdate.Text = "재고 수정";
            this.btn_StUpdate.UseVisualStyleBackColor = true;
            this.btn_StUpdate.Click += new System.EventHandler(this.btn_StUpdate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(3, 174);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(716, 423);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.Click += new System.EventHandler(this.dataGridView1_Click);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.FalseValue = "0";
            this.Column1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Column1.HeaderText = "제품 선택";
            this.Column1.IndeterminateValue = "0";
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.TrueValue = "1";
            this.Column1.Width = 82;
            // 
            // tb_StCate
            // 
            this.tb_StCate.Enabled = false;
            this.tb_StCate.Location = new System.Drawing.Point(78, 66);
            this.tb_StCate.Name = "tb_StCate";
            this.tb_StCate.Size = new System.Drawing.Size(147, 21);
            this.tb_StCate.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 63);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(480, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(190, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 12);
            this.label9.TabIndex = 11;
            // 
            // tb_StName
            // 
            this.tb_StName.Enabled = false;
            this.tb_StName.Location = new System.Drawing.Point(78, 94);
            this.tb_StName.Name = "tb_StName";
            this.tb_StName.Size = new System.Drawing.Size(147, 21);
            this.tb_StName.TabIndex = 14;
            // 
            // tb_StQunt
            // 
            this.tb_StQunt.Enabled = false;
            this.tb_StQunt.Location = new System.Drawing.Point(78, 120);
            this.tb_StQunt.Name = "tb_StQunt";
            this.tb_StQunt.Size = new System.Drawing.Size(147, 21);
            this.tb_StQunt.TabIndex = 16;
            // 
            // tb_StPrice
            // 
            this.tb_StPrice.Enabled = false;
            this.tb_StPrice.Location = new System.Drawing.Point(78, 147);
            this.tb_StPrice.Name = "tb_StPrice";
            this.tb_StPrice.Size = new System.Drawing.Size(147, 21);
            this.tb_StPrice.TabIndex = 17;
            // 
            // tb_TtlPrice
            // 
            this.tb_TtlPrice.Enabled = false;
            this.tb_TtlPrice.Location = new System.Drawing.Point(318, 66);
            this.tb_TtlPrice.Name = "tb_TtlPrice";
            this.tb_TtlPrice.Size = new System.Drawing.Size(137, 21);
            this.tb_TtlPrice.TabIndex = 18;
            // 
            // tb_StBar
            // 
            this.tb_StBar.Enabled = false;
            this.tb_StBar.Location = new System.Drawing.Point(318, 94);
            this.tb_StBar.Name = "tb_StBar";
            this.tb_StBar.Size = new System.Drawing.Size(137, 21);
            this.tb_StBar.TabIndex = 19;
            // 
            // tb_ShelfLIfe
            // 
            this.tb_ShelfLIfe.Enabled = false;
            this.tb_ShelfLIfe.Location = new System.Drawing.Point(318, 120);
            this.tb_ShelfLIfe.Name = "tb_ShelfLIfe";
            this.tb_ShelfLIfe.Size = new System.Drawing.Size(137, 21);
            this.tb_ShelfLIfe.TabIndex = 20;
            // 
            // tb_TtlSell
            // 
            this.tb_TtlSell.Enabled = false;
            this.tb_TtlSell.Location = new System.Drawing.Point(318, 147);
            this.tb_TtlSell.Name = "tb_TtlSell";
            this.tb_TtlSell.Size = new System.Drawing.Size(137, 21);
            this.tb_TtlSell.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            //this.pictureBox1.ErrorImage = global::POSproject.Properties.Resources.noImage;
            this.pictureBox1.Location = new System.Drawing.Point(461, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 102);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // btn_LstOrd
            // 
            this.btn_LstOrd.Location = new System.Drawing.Point(722, 368);
            this.btn_LstOrd.Name = "btn_LstOrd";
            this.btn_LstOrd.Size = new System.Drawing.Size(75, 75);
            this.btn_LstOrd.TabIndex = 23;
            this.btn_LstOrd.Text = "발주 내역";
            this.btn_LstOrd.UseVisualStyleBackColor = true;
            this.btn_LstOrd.Click += new System.EventHandler(this.btn_LstOrd_Click);
            // 
            // btn_NewStock
            // 
            this.btn_NewStock.Location = new System.Drawing.Point(722, 291);
            this.btn_NewStock.Name = "btn_NewStock";
            this.btn_NewStock.Size = new System.Drawing.Size(75, 75);
            this.btn_NewStock.TabIndex = 24;
            this.btn_NewStock.Text = "상품 추가";
            this.btn_NewStock.UseVisualStyleBackColor = true;
            this.btn_NewStock.Click += new System.EventHandler(this.button2_Click);
            // 
            // POS_Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.Stock_exit;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.btn_NewStock);
            this.Controls.Add(this.btn_LstOrd);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tb_TtlSell);
            this.Controls.Add(this.tb_ShelfLIfe);
            this.Controls.Add(this.tb_StBar);
            this.Controls.Add(this.tb_TtlPrice);
            this.Controls.Add(this.tb_StPrice);
            this.Controls.Add(this.tb_StQunt);
            this.Controls.Add(label12);
            this.Controls.Add(this.tb_StName);
            this.Controls.Add(label11);
            this.Controls.Add(label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(label8);
            this.Controls.Add(label7);
            this.Controls.Add(label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(label5);
            this.Controls.Add(this.tb_StCate);
            this.Controls.Add(label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_StUpdate);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Stock_exit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "POS_Stock";
            this.ShowIcon = false;
            this.Text = "Stock";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Stock_exit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_StUpdate;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox tb_StCate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_StName;
        private System.Windows.Forms.TextBox tb_StQunt;
        private System.Windows.Forms.TextBox tb_StPrice;
        private System.Windows.Forms.TextBox tb_TtlPrice;
        private System.Windows.Forms.TextBox tb_StBar;
        private System.Windows.Forms.TextBox tb_ShelfLIfe;
        private System.Windows.Forms.TextBox tb_TtlSell;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_LstOrd;
        private System.Windows.Forms.Button btn_NewStock;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
    }
}

