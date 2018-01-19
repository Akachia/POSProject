namespace POSproject
{
    partial class Form_UserManagement
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserWorkTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "직원 관리(관리자용) 페이지";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.UserPhone,
            this.UserPay,
            this.UserWorkTime,
            this.UserPic});
            this.dataGridView1.Location = new System.Drawing.Point(15, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(636, 329);
            this.dataGridView1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "직원 목록";
            // 
            // UserName
            // 
            this.UserName.Frozen = true;
            this.UserName.HeaderText = "직원 명";
            this.UserName.Name = "UserName";
            // 
            // UserPhone
            // 
            this.UserPhone.Frozen = true;
            this.UserPhone.HeaderText = "연락처";
            this.UserPhone.Name = "UserPhone";
            // 
            // UserPay
            // 
            this.UserPay.Frozen = true;
            this.UserPay.HeaderText = "시급";
            this.UserPay.Name = "UserPay";
            // 
            // UserWorkTime
            // 
            this.UserWorkTime.Frozen = true;
            this.UserWorkTime.HeaderText = "누적 근무시간";
            this.UserWorkTime.Name = "UserWorkTime";
            this.UserWorkTime.Width = 120;
            // 
            // UserPic
            // 
            this.UserPic.HeaderText = "사진";
            this.UserPic.Name = "UserPic";
            this.UserPic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.UserPic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(671, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "직원 추가";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form_UserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_UserManagement";
            this.Text = "Form_UserManagement";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserWorkTime;
        private System.Windows.Forms.DataGridViewImageColumn UserPic;
        private System.Windows.Forms.Button button1;
    }
}