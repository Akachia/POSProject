namespace POSproject
{
    partial class Form_UserModify
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
            this.txt_chkPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_CheckPwd = new System.Windows.Forms.Panel();
            this.btn_Chk = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_Modify = new System.Windows.Forms.Panel();
            this.txt_Phone = new System.Windows.Forms.MaskedTextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_Pwd = new System.Windows.Forms.Label();
            this.lbl_Id = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.txt_Pwd = new System.Windows.Forms.TextBox();
            this.txt_Id = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.openPic = new System.Windows.Forms.OpenFileDialog();
            this.pnl_CheckPwd.SuspendLayout();
            this.pnl_Modify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_chkPwd
            // 
            this.txt_chkPwd.Location = new System.Drawing.Point(124, 187);
            this.txt_chkPwd.Name = "txt_chkPwd";
            this.txt_chkPwd.Size = new System.Drawing.Size(127, 21);
            this.txt_chkPwd.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼모음T", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(47, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "비밀번호를 한번 더 입력해주세요!";
            // 
            // pnl_CheckPwd
            // 
            this.pnl_CheckPwd.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.pnl_CheckPwd.Controls.Add(this.btn_Chk);
            this.pnl_CheckPwd.Controls.Add(this.label2);
            this.pnl_CheckPwd.Controls.Add(this.label1);
            this.pnl_CheckPwd.Controls.Add(this.txt_chkPwd);
            this.pnl_CheckPwd.Location = new System.Drawing.Point(2, 3);
            this.pnl_CheckPwd.Name = "pnl_CheckPwd";
            this.pnl_CheckPwd.Size = new System.Drawing.Size(386, 389);
            this.pnl_CheckPwd.TabIndex = 2;
            // 
            // btn_Chk
            // 
            this.btn_Chk.Image = global::POSproject.Properties.Resources.if_Enter_7289341;
            this.btn_Chk.Location = new System.Drawing.Point(257, 185);
            this.btn_Chk.Name = "btn_Chk";
            this.btn_Chk.Size = new System.Drawing.Size(35, 35);
            this.btn_Chk.TabIndex = 3;
            this.btn_Chk.UseVisualStyleBackColor = true;
            this.btn_Chk.Click += new System.EventHandler(this.btn_Chk_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼모음T", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(47, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "비밀번호 ▶";
            // 
            // pnl_Modify
            // 
            this.pnl_Modify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(107)))), ((int)(((byte)(174)))), ((int)(((byte)(214)))));
            this.pnl_Modify.Controls.Add(this.txt_Phone);
            this.pnl_Modify.Controls.Add(this.lblTitle);
            this.pnl_Modify.Controls.Add(this.label3);
            this.pnl_Modify.Controls.Add(this.lbl_Pwd);
            this.pnl_Modify.Controls.Add(this.lbl_Id);
            this.pnl_Modify.Controls.Add(this.lbl_Phone);
            this.pnl_Modify.Controls.Add(this.lbl_Name);
            this.pnl_Modify.Controls.Add(this.btnCancel);
            this.pnl_Modify.Controls.Add(this.btnConfirm);
            this.pnl_Modify.Controls.Add(this.btnLoad);
            this.pnl_Modify.Controls.Add(this.picUser);
            this.pnl_Modify.Controls.Add(this.txt_Pwd);
            this.pnl_Modify.Controls.Add(this.txt_Id);
            this.pnl_Modify.Controls.Add(this.txt_Name);
            this.pnl_Modify.Location = new System.Drawing.Point(5, 6);
            this.pnl_Modify.Name = "pnl_Modify";
            this.pnl_Modify.Size = new System.Drawing.Size(404, 403);
            this.pnl_Modify.TabIndex = 3;
            // 
            // txt_Phone
            // 
            this.txt_Phone.Location = new System.Drawing.Point(237, 242);
            this.txt_Phone.Mask = "000-9000-0000";
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Size = new System.Drawing.Size(100, 21);
            this.txt_Phone.TabIndex = 30;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("휴먼모음T", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Location = new System.Drawing.Point(121, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(134, 21);
            this.lblTitle.TabIndex = 29;
            this.lblTitle.Text = "직원 정보 수정";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 309);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(287, 12);
            this.label3.TabIndex = 28;
            this.label3.Text = "* 비밀번호를 바꾸지 않을때에는 비워두시면 됩니다.";
            // 
            // lbl_Pwd
            // 
            this.lbl_Pwd.AutoSize = true;
            this.lbl_Pwd.Location = new System.Drawing.Point(176, 288);
            this.lbl_Pwd.Name = "lbl_Pwd";
            this.lbl_Pwd.Size = new System.Drawing.Size(53, 12);
            this.lbl_Pwd.TabIndex = 27;
            this.lbl_Pwd.Text = "비밀번호";
            // 
            // lbl_Id
            // 
            this.lbl_Id.AutoSize = true;
            this.lbl_Id.Location = new System.Drawing.Point(27, 245);
            this.lbl_Id.Name = "lbl_Id";
            this.lbl_Id.Size = new System.Drawing.Size(29, 12);
            this.lbl_Id.TabIndex = 26;
            this.lbl_Id.Text = "이름";
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.AutoSize = true;
            this.lbl_Phone.Location = new System.Drawing.Point(177, 245);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(53, 12);
            this.lbl_Phone.TabIndex = 25;
            this.lbl_Phone.Text = "전화번호";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(33, 288);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(16, 12);
            this.lbl_Name.TabIndex = 24;
            this.lbl_Name.Text = "ID";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(275, 349);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(194, 349);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 22;
            this.btnConfirm.Text = "수정";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(153, 189);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 21;
            this.btnLoad.Text = "불러오기";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // picUser
            // 
            this.picUser.Image = global::POSproject.Properties.Resources.nouserpic;
            this.picUser.Location = new System.Drawing.Point(128, 57);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(127, 126);
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUser.TabIndex = 20;
            this.picUser.TabStop = false;
            // 
            // txt_Pwd
            // 
            this.txt_Pwd.Location = new System.Drawing.Point(237, 285);
            this.txt_Pwd.Name = "txt_Pwd";
            this.txt_Pwd.Size = new System.Drawing.Size(100, 21);
            this.txt_Pwd.TabIndex = 19;
            this.txt_Pwd.Leave += new System.EventHandler(this.txt_Pwd_Leave);
            // 
            // txt_Id
            // 
            this.txt_Id.Location = new System.Drawing.Point(70, 285);
            this.txt_Id.Name = "txt_Id";
            this.txt_Id.ReadOnly = true;
            this.txt_Id.Size = new System.Drawing.Size(100, 21);
            this.txt_Id.TabIndex = 17;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(71, 242);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Size = new System.Drawing.Size(100, 21);
            this.txt_Name.TabIndex = 16;
            // 
            // openPic
            // 
            this.openPic.FileName = "openFileDialog1";
            // 
            // Form_UserModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.pnl_Modify);
            this.Controls.Add(this.pnl_CheckPwd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_UserModify";
            this.Text = "Form_UserModify";
            this.Load += new System.EventHandler(this.Form_UserModify_Load);
            this.pnl_CheckPwd.ResumeLayout(false);
            this.pnl_CheckPwd.PerformLayout();
            this.pnl_Modify.ResumeLayout(false);
            this.pnl_Modify.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_chkPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_CheckPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Chk;
        private System.Windows.Forms.OpenFileDialog openPic;
        private System.Windows.Forms.Panel pnl_Modify;
        private System.Windows.Forms.Label lbl_Pwd;
        private System.Windows.Forms.Label lbl_Id;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.TextBox txt_Pwd;
        private System.Windows.Forms.TextBox txt_Id;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox txt_Phone;
    }
}