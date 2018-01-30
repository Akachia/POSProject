namespace POSproject
{
    partial class UserAccount
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_curWorkTime = new System.Windows.Forms.Label();
            this.lblStoreAddr = new System.Windows.Forms.Label();
            this.lblStoreCall = new System.Windows.Forms.Label();
            this.lblStoreName = new System.Windows.Forms.Label();
            this.lbl_checkin = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.pic_User = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_mgr = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_CheckOut = new System.Windows.Forms.Button();
            this.btn_InfoModify = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnMail = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_User)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(700, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 82);
            this.button1.TabIndex = 2;
            this.button1.Text = "뒤로가기";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(534, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "금일 출근 현황";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lbl_curWorkTime);
            this.panel1.Controls.Add(this.lblStoreAddr);
            this.panel1.Controls.Add(this.lblStoreCall);
            this.panel1.Controls.Add(this.lblStoreName);
            this.panel1.Controls.Add(this.lbl_checkin);
            this.panel1.Controls.Add(this.lbl_Phone);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.pic_User);
            this.panel1.Location = new System.Drawing.Point(38, 81);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 464);
            this.panel1.TabIndex = 3;
            // 
            // lbl_curWorkTime
            // 
            this.lbl_curWorkTime.AutoSize = true;
            this.lbl_curWorkTime.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_curWorkTime.Location = new System.Drawing.Point(6, 323);
            this.lbl_curWorkTime.Name = "lbl_curWorkTime";
            this.lbl_curWorkTime.Size = new System.Drawing.Size(110, 17);
            this.lbl_curWorkTime.TabIndex = 8;
            this.lbl_curWorkTime.Text = "근무 시간 : ";
            // 
            // lblStoreAddr
            // 
            this.lblStoreAddr.AutoSize = true;
            this.lblStoreAddr.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStoreAddr.Location = new System.Drawing.Point(6, 155);
            this.lblStoreAddr.Name = "lblStoreAddr";
            this.lblStoreAddr.Size = new System.Drawing.Size(110, 17);
            this.lblStoreAddr.TabIndex = 6;
            this.lblStoreAddr.Text = "가게 주소 : ";
            // 
            // lblStoreCall
            // 
            this.lblStoreCall.AutoSize = true;
            this.lblStoreCall.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStoreCall.Location = new System.Drawing.Point(6, 123);
            this.lblStoreCall.Name = "lblStoreCall";
            this.lblStoreCall.Size = new System.Drawing.Size(110, 17);
            this.lblStoreCall.TabIndex = 5;
            this.lblStoreCall.Text = "가게 번호 : ";
            // 
            // lblStoreName
            // 
            this.lblStoreName.AutoSize = true;
            this.lblStoreName.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStoreName.Location = new System.Drawing.Point(6, 91);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(93, 17);
            this.lblStoreName.TabIndex = 4;
            this.lblStoreName.Text = "가게 명 : ";
            // 
            // lbl_checkin
            // 
            this.lbl_checkin.AutoSize = true;
            this.lbl_checkin.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_checkin.Location = new System.Drawing.Point(4, 297);
            this.lbl_checkin.Name = "lbl_checkin";
            this.lbl_checkin.Size = new System.Drawing.Size(144, 17);
            this.lbl_checkin.TabIndex = 3;
            this.lbl_checkin.Text = "근무 시작시간 : ";
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.AutoSize = true;
            this.lbl_Phone.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Phone.Location = new System.Drawing.Point(6, 59);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(84, 17);
            this.lbl_Phone.TabIndex = 2;
            this.lbl_Phone.Text = "연락처 : ";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("휴먼둥근헤드라인", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_name.Location = new System.Drawing.Point(6, 27);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(67, 17);
            this.lbl_name.TabIndex = 1;
            this.lbl_name.Text = "이름 : ";
            // 
            // pic_User
            // 
            this.pic_User.Image = global::POSproject.Properties.Resources.nouserpic;
            this.pic_User.Location = new System.Drawing.Point(307, 4);
            this.pic_User.Name = "pic_User";
            this.pic_User.Size = new System.Drawing.Size(140, 136);
            this.pic_User.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_User.TabIndex = 0;
            this.pic_User.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("휴먼모음T", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(38, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "직원 정보";
            // 
            // btn_mgr
            // 
            this.btn_mgr.Location = new System.Drawing.Point(530, 12);
            this.btn_mgr.Name = "btn_mgr";
            this.btn_mgr.Size = new System.Drawing.Size(75, 82);
            this.btn_mgr.TabIndex = 5;
            this.btn_mgr.Text = "직원 관리";
            this.btn_mgr.UseVisualStyleBackColor = true;
            this.btn_mgr.Click += new System.EventHandler(this.btn_mgr_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btn_CheckOut
            // 
            this.btn_CheckOut.Location = new System.Drawing.Point(611, 12);
            this.btn_CheckOut.Name = "btn_CheckOut";
            this.btn_CheckOut.Size = new System.Drawing.Size(75, 82);
            this.btn_CheckOut.TabIndex = 6;
            this.btn_CheckOut.Text = "퇴근";
            this.btn_CheckOut.UseVisualStyleBackColor = true;
            this.btn_CheckOut.Click += new System.EventHandler(this.btn_CheckOut_Click);
            // 
            // btn_InfoModify
            // 
            this.btn_InfoModify.Location = new System.Drawing.Point(700, 107);
            this.btn_InfoModify.Name = "btn_InfoModify";
            this.btn_InfoModify.Size = new System.Drawing.Size(75, 82);
            this.btn_InfoModify.TabIndex = 7;
            this.btn_InfoModify.Text = "정보 수정";
            this.btn_InfoModify.UseVisualStyleBackColor = true;
            this.btn_InfoModify.Click += new System.EventHandler(this.btn_InfoModify_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(536, 319);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 249);
            this.textBox1.TabIndex = 8;
            // 
            // btnMail
            // 
            this.btnMail.Location = new System.Drawing.Point(611, 109);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(75, 82);
            this.btnMail.TabIndex = 9;
            this.btnMail.Text = "사장에게 메일발송";
            this.btnMail.UseVisualStyleBackColor = true;
            // 
            // UserAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.btnMail);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_InfoModify);
            this.Controls.Add(this.btn_CheckOut);
            this.Controls.Add(this.btn_mgr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserAccount";
            this.Text = "UserAccount";
            this.Load += new System.EventHandler(this.UserAccount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_User)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_mgr;
        private System.Windows.Forms.Label lblStoreAddr;
        private System.Windows.Forms.Label lblStoreCall;
        private System.Windows.Forms.Label lblStoreName;
        private System.Windows.Forms.Label lbl_checkin;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.PictureBox pic_User;
        private System.Windows.Forms.Label lbl_curWorkTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_CheckOut;
        private System.Windows.Forms.Button btn_InfoModify;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnMail;
    }
}