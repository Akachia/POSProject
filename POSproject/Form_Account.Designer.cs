﻿namespace TF
{
    partial class Form_Account
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnPrevYear = new System.Windows.Forms.Button();
            this.btnNextYear = new System.Windows.Forms.Button();
            this.btnGoMain3 = new System.Windows.Forms.Button();
            this.btnChart = new System.Windows.Forms.Button();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnGoMain2 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCashD = new System.Windows.Forms.TextBox();
            this.txtCardD = new System.Windows.Forms.TextBox();
            this.txtTotalD = new System.Windows.Forms.TextBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGoMain1 = new System.Windows.Forms.Button();
            this.btnPrevDate = new System.Windows.Forms.Button();
            this.btnNextDate = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("굴림", 28F);
            this.lblTime.Location = new System.Drawing.Point(12, 12);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(0, 38);
            this.lblTime.TabIndex = 6;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage3.Controls.Add(this.chart);
            this.tabPage3.Controls.Add(this.btnChart);
            this.tabPage3.Controls.Add(this.btnGoMain3);
            this.tabPage3.Controls.Add(this.btnNextYear);
            this.tabPage3.Controls.Add(this.btnPrevYear);
            this.tabPage3.ForeColor = System.Drawing.Color.White;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(795, 520);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "그래프";
            // 
            // btnPrevYear
            // 
            this.btnPrevYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btnPrevYear.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.btnPrevYear.Location = new System.Drawing.Point(673, 54);
            this.btnPrevYear.Name = "btnPrevYear";
            this.btnPrevYear.Size = new System.Drawing.Size(47, 75);
            this.btnPrevYear.TabIndex = 103;
            this.btnPrevYear.Text = "이전 년도\r\n (◀)";
            this.btnPrevYear.UseVisualStyleBackColor = false;
            this.btnPrevYear.Click += new System.EventHandler(this.btnPrevYear_Click_1);
            // 
            // btnNextYear
            // 
            this.btnNextYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btnNextYear.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.btnNextYear.Location = new System.Drawing.Point(735, 54);
            this.btnNextYear.Name = "btnNextYear";
            this.btnNextYear.Size = new System.Drawing.Size(47, 75);
            this.btnNextYear.TabIndex = 104;
            this.btnNextYear.Text = "다음 년도\r\n(▶)";
            this.btnNextYear.UseVisualStyleBackColor = false;
            this.btnNextYear.Click += new System.EventHandler(this.btnNextYear_Click_1);
            // 
            // btnGoMain3
            // 
            this.btnGoMain3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btnGoMain3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.btnGoMain3.Location = new System.Drawing.Point(692, 438);
            this.btnGoMain3.Name = "btnGoMain3";
            this.btnGoMain3.Size = new System.Drawing.Size(73, 75);
            this.btnGoMain3.TabIndex = 105;
            this.btnGoMain3.Text = "메인 화면";
            this.btnGoMain3.UseVisualStyleBackColor = false;
            this.btnGoMain3.Click += new System.EventHandler(this.btnGoMain3_Click);
            // 
            // btnChart
            // 
            this.btnChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btnChart.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold);
            this.btnChart.Location = new System.Drawing.Point(673, 3);
            this.btnChart.Name = "btnChart";
            this.btnChart.Size = new System.Drawing.Size(109, 45);
            this.btnChart.TabIndex = 107;
            this.btnChart.Text = "매출 차트 보기";
            this.btnChart.UseVisualStyleBackColor = false;
            this.btnChart.Click += new System.EventHandler(this.btnChart_Click);
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(13, 3);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "총매출";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "순이익";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(654, 510);
            this.chart.TabIndex = 108;
            this.chart.Text = "chart1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.btnGoMain2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(795, 520);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "단위 기간 정산";
            // 
            // btnGoMain2
            // 
            this.btnGoMain2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btnGoMain2.Font = new System.Drawing.Font("굴림", 14F, System.Drawing.FontStyle.Bold);
            this.btnGoMain2.ForeColor = System.Drawing.Color.White;
            this.btnGoMain2.Location = new System.Drawing.Point(673, 388);
            this.btnGoMain2.Name = "btnGoMain2";
            this.btnGoMain2.Size = new System.Drawing.Size(116, 121);
            this.btnGoMain2.TabIndex = 102;
            this.btnGoMain2.Text = "메인 화면";
            this.btnGoMain2.UseVisualStyleBackColor = false;
            this.btnGoMain2.Click += new System.EventHandler(this.btnGoMain2_Click_1);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column2,
            this.Column6,
            this.Column8});
            this.dataGridView2.Location = new System.Drawing.Point(6, 6);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(783, 376);
            this.dataGridView2.TabIndex = 91;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "순이익";
            this.Column8.Name = "Column8";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "알바비";
            this.Column6.Name = "Column6";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "총 입고가";
            this.Column2.Name = "Column2";
            this.Column2.Width = 110;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "총 매출";
            this.Column5.Name = "Column5";
            this.Column5.Width = 120;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "카드 매출";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "현금 매출";
            this.Column3.Name = "Column3";
            this.Column3.Width = 110;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "조회 년 월";
            this.Column1.Name = "Column1";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(235)))), ((int)(((byte)(247)))));
            this.tabPage1.Controls.Add(this.btnNextDate);
            this.tabPage1.Controls.Add(this.btnPrevDate);
            this.tabPage1.Controls.Add(this.btnGoMain1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(795, 520);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "일일 정산";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(219)))), ((int)(((byte)(239)))));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.txtTotalD);
            this.groupBox1.Controls.Add(this.txtCardD);
            this.groupBox1.Controls.Add(this.txtCashD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(403, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(382, 346);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 20F);
            this.label4.Location = new System.Drawing.Point(6, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "카드 매출";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 20F);
            this.label5.Location = new System.Drawing.Point(6, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 27);
            this.label5.TabIndex = 8;
            this.label5.Text = "총 매출";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 20F);
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "현금 매출";
            // 
            // txtCashD
            // 
            this.txtCashD.Font = new System.Drawing.Font("굴림", 18F);
            this.txtCashD.Location = new System.Drawing.Point(141, 87);
            this.txtCashD.Multiline = true;
            this.txtCashD.Name = "txtCashD";
            this.txtCashD.Size = new System.Drawing.Size(223, 27);
            this.txtCashD.TabIndex = 42;
            // 
            // txtCardD
            // 
            this.txtCardD.Font = new System.Drawing.Font("굴림", 18F);
            this.txtCardD.Location = new System.Drawing.Point(141, 169);
            this.txtCardD.Multiline = true;
            this.txtCardD.Name = "txtCardD";
            this.txtCardD.Size = new System.Drawing.Size(223, 27);
            this.txtCardD.TabIndex = 43;
            // 
            // txtTotalD
            // 
            this.txtTotalD.Font = new System.Drawing.Font("굴림", 18F);
            this.txtTotalD.Location = new System.Drawing.Point(141, 250);
            this.txtTotalD.Multiline = true;
            this.txtTotalD.Name = "txtTotalD";
            this.txtTotalD.Size = new System.Drawing.Size(223, 27);
            this.txtTotalD.TabIndex = 44;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("굴림", 20F);
            this.lblDate.Location = new System.Drawing.Point(27, 22);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(0, 27);
            this.lblDate.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 20F);
            this.label1.Location = new System.Drawing.Point(277, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 27);
            this.label1.TabIndex = 50;
            this.label1.Text = "매출";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column9,
            this.Column10});
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(391, 501);
            this.dataGridView1.TabIndex = 66;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "수량";
            this.Column10.Name = "Column10";
            this.Column10.Width = 77;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "총 가격";
            this.Column9.Name = "Column9";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "상품명";
            this.Column7.Name = "Column7";
            this.Column7.Width = 170;
            // 
            // btnGoMain1
            // 
            this.btnGoMain1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btnGoMain1.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.btnGoMain1.ForeColor = System.Drawing.Color.White;
            this.btnGoMain1.Location = new System.Drawing.Point(685, 351);
            this.btnGoMain1.Name = "btnGoMain1";
            this.btnGoMain1.Size = new System.Drawing.Size(101, 156);
            this.btnGoMain1.TabIndex = 67;
            this.btnGoMain1.Text = "메인 화면";
            this.btnGoMain1.UseVisualStyleBackColor = false;
            this.btnGoMain1.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnPrevDate
            // 
            this.btnPrevDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btnPrevDate.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.btnPrevDate.ForeColor = System.Drawing.Color.White;
            this.btnPrevDate.Location = new System.Drawing.Point(403, 351);
            this.btnPrevDate.Name = "btnPrevDate";
            this.btnPrevDate.Size = new System.Drawing.Size(135, 156);
            this.btnPrevDate.TabIndex = 71;
            this.btnPrevDate.Text = "이전 날짜";
            this.btnPrevDate.UseVisualStyleBackColor = false;
            this.btnPrevDate.Click += new System.EventHandler(this.btnPrevDate_Click);
            // 
            // btnNextDate
            // 
            this.btnNextDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(113)))), ((int)(((byte)(181)))));
            this.btnNextDate.Font = new System.Drawing.Font("굴림", 13F, System.Drawing.FontStyle.Bold);
            this.btnNextDate.ForeColor = System.Drawing.Color.White;
            this.btnNextDate.Location = new System.Drawing.Point(544, 351);
            this.btnNextDate.Name = "btnNextDate";
            this.btnNextDate.Size = new System.Drawing.Size(135, 156);
            this.btnNextDate.TabIndex = 72;
            this.btnNextDate.Text = "다음 날짜";
            this.btnNextDate.UseVisualStyleBackColor = false;
            this.btnNextDate.Click += new System.EventHandler(this.btnNextDate_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(803, 546);
            this.tabControl1.TabIndex = 8;
            // 
            // Form_Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lblTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Account";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form_Account_Load);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.Button btnChart;
        private System.Windows.Forms.Button btnGoMain3;
        private System.Windows.Forms.Button btnNextYear;
        private System.Windows.Forms.Button btnPrevYear;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button btnGoMain2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnNextDate;
        private System.Windows.Forms.Button btnPrevDate;
        private System.Windows.Forms.Button btnGoMain1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.TextBox txtTotalD;
        private System.Windows.Forms.TextBox txtCardD;
        private System.Windows.Forms.TextBox txtCashD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
    }
}