namespace POSproject_KSM
{
    partial class Form_Disposal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label13;
            System.Windows.Forms.Label label14;
            System.Windows.Forms.Label label15;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_User = new System.Windows.Forms.Label();
            this.lbl_Timer = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.startDate = new System.Windows.Forms.DateTimePicker();
            this.endDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_DisTtl = new System.Windows.Forms.Label();
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.btn_Prod = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tb_StBar = new System.Windows.Forms.TextBox();
            this.tb_StPrice = new System.Windows.Forms.TextBox();
            this.tb_StQunt = new System.Windows.Forms.TextBox();
            this.tb_StName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_StCate = new System.Windows.Forms.TextBox();
            this.btn_StUpdate = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_Expire = new System.Windows.Forms.TextBox();
            this.btn_search = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            label3.ForeColor = System.Drawing.Color.Black;
            label3.Location = new System.Drawing.Point(307, 196);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(41, 12);
            label3.TabIndex = 24;
            label3.Text = "날짜 :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            label5.ForeColor = System.Drawing.Color.Black;
            label5.Location = new System.Drawing.Point(12, 196);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(72, 12);
            label5.TabIndex = 28;
            label5.Text = "폐기 금액 :";
            label5.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(405, 22);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(144, 21);
            label2.TabIndex = 3;
            label2.Text = "현재 접속자 :";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            label10.ForeColor = System.Drawing.Color.Black;
            label10.Location = new System.Drawing.Point(16, 21);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(85, 12);
            label10.TabIndex = 61;
            label10.Text = "제품 바코드 :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            label8.ForeColor = System.Drawing.Color.Black;
            label8.Location = new System.Drawing.Point(489, 57);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(77, 12);
            label8.TabIndex = 58;
            label8.Text = "제품 원가 : ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            label13.ForeColor = System.Drawing.Color.Black;
            label13.Location = new System.Drawing.Point(336, 57);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(72, 12);
            label13.TabIndex = 56;
            label13.Text = "제품 수량 :";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            label14.ForeColor = System.Drawing.Color.Black;
            label14.Location = new System.Drawing.Point(336, 21);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(72, 12);
            label14.TabIndex = 55;
            label14.Text = "상품 이름 :";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            label15.ForeColor = System.Drawing.Color.Black;
            label15.Location = new System.Drawing.Point(336, 94);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(72, 12);
            label15.TabIndex = 54;
            label15.Text = "상품 종류 :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            label1.ForeColor = System.Drawing.Color.Black;
            label1.Location = new System.Drawing.Point(489, 94);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(72, 12);
            label1.TabIndex = 73;
            label1.Text = "유통 기한 :";
            // 
            // btn_Exit
            // 
            this.btn_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btn_Exit.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Exit.ForeColor = System.Drawing.Color.White;
            this.btn_Exit.Location = new System.Drawing.Point(721, 522);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 75);
            this.btn_Exit.TabIndex = 20;
            this.btn_Exit.Text = "나가기";
            this.btn_Exit.UseVisualStyleBackColor = false;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_User);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(this.lbl_Timer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 63);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // lbl_User
            // 
            this.lbl_User.AutoSize = true;
            this.lbl_User.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_User.Location = new System.Drawing.Point(547, 22);
            this.lbl_User.Name = "lbl_User";
            this.lbl_User.Size = new System.Drawing.Size(0, 21);
            this.lbl_User.TabIndex = 4;
            // 
            // lbl_Timer
            // 
            this.lbl_Timer.AutoSize = true;
            this.lbl_Timer.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbl_Timer.Location = new System.Drawing.Point(14, 22);
            this.lbl_Timer.Name = "lbl_Timer";
            this.lbl_Timer.Size = new System.Drawing.Size(64, 21);
            this.lbl_Timer.TabIndex = 0;
            this.lbl_Timer.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 220);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(800, 297);
            this.dataGridView1.TabIndex = 18;
            // 
            // startDate
            // 
            this.startDate.Location = new System.Drawing.Point(350, 192);
            this.startDate.Name = "startDate";
            this.startDate.Size = new System.Drawing.Size(170, 21);
            this.startDate.TabIndex = 22;
            // 
            // endDate
            // 
            this.endDate.Location = new System.Drawing.Point(546, 192);
            this.endDate.Name = "endDate";
            this.endDate.Size = new System.Drawing.Size(169, 21);
            this.endDate.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(526, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "~";
            // 
            // lbl_DisTtl
            // 
            this.lbl_DisTtl.AutoSize = true;
            this.lbl_DisTtl.Location = new System.Drawing.Point(81, 198);
            this.lbl_DisTtl.Name = "lbl_DisTtl";
            this.lbl_DisTtl.Size = new System.Drawing.Size(0, 12);
            this.lbl_DisTtl.TabIndex = 29;
            this.lbl_DisTtl.Visible = false;
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btn_Cancle.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Cancle.ForeColor = System.Drawing.Color.White;
            this.btn_Cancle.Location = new System.Drawing.Point(643, 522);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(75, 75);
            this.btn_Cancle.TabIndex = 30;
            this.btn_Cancle.Text = "폐기 취소";
            this.btn_Cancle.UseVisualStyleBackColor = false;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // btn_Prod
            // 
            this.btn_Prod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btn_Prod.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.btn_Prod.ForeColor = System.Drawing.Color.White;
            this.btn_Prod.Location = new System.Drawing.Point(721, 191);
            this.btn_Prod.Name = "btn_Prod";
            this.btn_Prod.Size = new System.Drawing.Size(75, 23);
            this.btn_Prod.TabIndex = 32;
            this.btn_Prod.Text = "기간검색";
            this.btn_Prod.UseVisualStyleBackColor = false;
            this.btn_Prod.Click += new System.EventHandler(this.btn_Prod_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.ErrorImage = global::POSproject.Properties.Resources.noImage;
            this.pictureBox1.Location = new System.Drawing.Point(655, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 102);
            this.pictureBox1.TabIndex = 71;
            this.pictureBox1.TabStop = false;
            // 
            // tb_StBar
            // 
            this.tb_StBar.Location = new System.Drawing.Point(99, 18);
            this.tb_StBar.Name = "tb_StBar";
            this.tb_StBar.Size = new System.Drawing.Size(181, 21);
            this.tb_StBar.TabIndex = 68;
            this.tb_StBar.TextChanged += new System.EventHandler(this.tb_StBar_TextChanged);
            // 
            // tb_StPrice
            // 
            this.tb_StPrice.Enabled = false;
            this.tb_StPrice.Location = new System.Drawing.Point(564, 52);
            this.tb_StPrice.Name = "tb_StPrice";
            this.tb_StPrice.Size = new System.Drawing.Size(66, 21);
            this.tb_StPrice.TabIndex = 66;
            // 
            // tb_StQunt
            // 
            this.tb_StQunt.Enabled = false;
            this.tb_StQunt.Location = new System.Drawing.Point(417, 52);
            this.tb_StQunt.Name = "tb_StQunt";
            this.tb_StQunt.Size = new System.Drawing.Size(66, 21);
            this.tb_StQunt.TabIndex = 65;
            // 
            // tb_StName
            // 
            this.tb_StName.Enabled = false;
            this.tb_StName.Location = new System.Drawing.Point(417, 18);
            this.tb_StName.Name = "tb_StName";
            this.tb_StName.Size = new System.Drawing.Size(213, 21);
            this.tb_StName.TabIndex = 63;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Enabled = false;
            this.label9.Location = new System.Drawing.Point(267, 101);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 12);
            this.label9.TabIndex = 60;
            // 
            // tb_StCate
            // 
            this.tb_StCate.Enabled = false;
            this.tb_StCate.Location = new System.Drawing.Point(417, 91);
            this.tb_StCate.Name = "tb_StCate";
            this.tb_StCate.Size = new System.Drawing.Size(66, 21);
            this.tb_StCate.TabIndex = 57;
            // 
            // btn_StUpdate
            // 
            this.btn_StUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btn_StUpdate.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.btn_StUpdate.ForeColor = System.Drawing.Color.White;
            this.btn_StUpdate.Location = new System.Drawing.Point(565, 522);
            this.btn_StUpdate.Name = "btn_StUpdate";
            this.btn_StUpdate.Size = new System.Drawing.Size(75, 75);
            this.btn_StUpdate.TabIndex = 53;
            this.btn_StUpdate.Text = "폐기 추가";
            this.btn_StUpdate.UseVisualStyleBackColor = false;
            this.btn_StUpdate.Click += new System.EventHandler(this.btn_StUpdate_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_Expire);
            this.groupBox2.Controls.Add(label1);
            this.groupBox2.Controls.Add(this.tb_StQunt);
            this.groupBox2.Controls.Add(this.tb_StPrice);
            this.groupBox2.Controls.Add(this.btn_search);
            this.groupBox2.Controls.Add(label13);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.tb_StCate);
            this.groupBox2.Controls.Add(this.tb_StName);
            this.groupBox2.Controls.Add(label15);
            this.groupBox2.Controls.Add(label8);
            this.groupBox2.Controls.Add(this.tb_StBar);
            this.groupBox2.Controls.Add(label10);
            this.groupBox2.Controls.Add(label14);
            this.groupBox2.Location = new System.Drawing.Point(0, 59);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 123);
            this.groupBox2.TabIndex = 72;
            this.groupBox2.TabStop = false;
            // 
            // tb_Expire
            // 
            this.tb_Expire.Enabled = false;
            this.tb_Expire.Location = new System.Drawing.Point(564, 89);
            this.tb_Expire.Name = "tb_Expire";
            this.tb_Expire.Size = new System.Drawing.Size(66, 21);
            this.tb_Expire.TabIndex = 74;
            // 
            // btn_search
            // 
            this.btn_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btn_search.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.btn_search.ForeColor = System.Drawing.Color.White;
            this.btn_search.Location = new System.Drawing.Point(99, 52);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(111, 23);
            this.btn_search.TabIndex = 72;
            this.btn_search.Text = "찾기";
            this.btn_search.UseVisualStyleBackColor = false;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // Form_Disposal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_Prod);
            this.Controls.Add(this.btn_Cancle);
            this.Controls.Add(this.lbl_DisTtl);
            this.Controls.Add(label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(label3);
            this.Controls.Add(this.endDate);
            this.Controls.Add(this.startDate);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_StUpdate);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Disposal";
            this.Text = "Disposal";
            this.Load += new System.EventHandler(this.Disposal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label lbl_User;
        private System.Windows.Forms.Label lbl_Timer;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DateTimePicker startDate;
        private System.Windows.Forms.DateTimePicker endDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_DisTtl;
        private System.Windows.Forms.Button btn_Cancle;
        private System.Windows.Forms.Button btn_Prod;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox tb_StBar;
        private System.Windows.Forms.TextBox tb_StPrice;
        private System.Windows.Forms.TextBox tb_StQunt;
        private System.Windows.Forms.TextBox tb_StName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_StCate;
        private System.Windows.Forms.Button btn_StUpdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox tb_Expire;
    }
}