﻿namespace POSproject_KSM
{
    partial class Form_NewStock
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label1;
            this.lbl_Timer = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_user = new System.Windows.Forms.Label();
            this.btn_NCh = new System.Windows.Forms.Button();
            this.btn_CC = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.cb_quantiy = new System.Windows.Forms.ComboBox();
            this.tb_category = new System.Windows.Forms.TextBox();
            this.tb_barcode = new System.Windows.Forms.TextBox();
            this.tb_price = new System.Windows.Forms.TextBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_primePrice = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label2.Location = new System.Drawing.Point(180, 16);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(97, 15);
            label2.TabIndex = 100;
            label2.Text = "현재 접속자 :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label7.Location = new System.Drawing.Point(13, 189);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(71, 13);
            label7.TabIndex = 100;
            label7.Text = "제품 수량 :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label6.Location = new System.Drawing.Point(206, 188);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(71, 13);
            label6.TabIndex = 100;
            label6.Text = "제품 종류 :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label5.Location = new System.Drawing.Point(206, 152);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(41, 13);
            label5.TabIndex = 100;
            label5.Text = "원가 :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label4.Location = new System.Drawing.Point(13, 151);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(71, 13);
            label4.TabIndex = 100;
            label4.Text = "판매 금액 :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label3.Location = new System.Drawing.Point(13, 113);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(71, 13);
            label3.TabIndex = 100;
            label3.Text = "제품 이름 :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label1.Location = new System.Drawing.Point(13, 75);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(80, 13);
            label1.TabIndex = 100;
            label1.Text = "상품바코드 :";
            // 
            // lbl_Timer
            // 
            this.lbl_Timer.AutoSize = true;
            this.lbl_Timer.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_Timer.Location = new System.Drawing.Point(12, 17);
            this.lbl_Timer.Name = "lbl_Timer";
            this.lbl_Timer.Size = new System.Drawing.Size(45, 15);
            this.lbl_Timer.TabIndex = 100;
            this.lbl_Timer.Text = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(this.lbl_user);
            this.groupBox1.Controls.Add(this.lbl_Timer);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 41);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_user.Location = new System.Drawing.Point(283, 16);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(45, 15);
            this.lbl_user.TabIndex = 100;
            this.lbl_user.Text = "label4";
            // 
            // btn_NCh
            // 
            this.btn_NCh.Location = new System.Drawing.Point(121, 465);
            this.btn_NCh.Name = "btn_NCh";
            this.btn_NCh.Size = new System.Drawing.Size(75, 23);
            this.btn_NCh.TabIndex = 7;
            this.btn_NCh.Text = "저장";
            this.btn_NCh.UseVisualStyleBackColor = true;
            this.btn_NCh.Click += new System.EventHandler(this.btn_NCh_Click);
            // 
            // btn_CC
            // 
            this.btn_CC.Location = new System.Drawing.Point(202, 465);
            this.btn_CC.Name = "btn_CC";
            this.btn_CC.Size = new System.Drawing.Size(75, 23);
            this.btn_CC.TabIndex = 8;
            this.btn_CC.Text = "취소";
            this.btn_CC.UseVisualStyleBackColor = true;
            this.btn_CC.Click += new System.EventHandler(this.btn_CC_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.ErrorImage = global::POSproject.Properties.Resources.noImage;
            this.pictureBox1.Location = new System.Drawing.Point(15, 244);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(371, 154);
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(156, 418);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(85, 23);
            this.btn_search.TabIndex = 6;
            this.btn_search.Text = "이미지 찾기";
            this.btn_search.UseVisualStyleBackColor = true;
            // 
            // cb_quantiy
            // 
            this.cb_quantiy.FormattingEnabled = true;
            this.cb_quantiy.Location = new System.Drawing.Point(90, 186);
            this.cb_quantiy.Name = "cb_quantiy";
            this.cb_quantiy.Size = new System.Drawing.Size(100, 20);
            this.cb_quantiy.TabIndex = 5;
            // 
            // tb_category
            // 
            this.tb_category.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_category.Location = new System.Drawing.Point(286, 184);
            this.tb_category.Name = "tb_category";
            this.tb_category.Size = new System.Drawing.Size(100, 22);
            this.tb_category.TabIndex = 4;
            // 
            // tb_barcode
            // 
            this.tb_barcode.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_barcode.Location = new System.Drawing.Point(99, 71);
            this.tb_barcode.Name = "tb_barcode";
            this.tb_barcode.Size = new System.Drawing.Size(178, 22);
            this.tb_barcode.TabIndex = 0;
            this.tb_barcode.TextChanged += new System.EventHandler(this.tb_barcode_TextChanged);
            this.tb_barcode.Leave += new System.EventHandler(this.tb_barcode_Leave);
            // 
            // tb_price
            // 
            this.tb_price.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_price.Location = new System.Drawing.Point(90, 147);
            this.tb_price.Name = "tb_price";
            this.tb_price.Size = new System.Drawing.Size(100, 22);
            this.tb_price.TabIndex = 3;
            // 
            // tb_name
            // 
            this.tb_name.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_name.Location = new System.Drawing.Point(99, 109);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(178, 22);
            this.tb_name.TabIndex = 1;
            // 
            // tb_primePrice
            // 
            this.tb_primePrice.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_primePrice.Location = new System.Drawing.Point(286, 146);
            this.tb_primePrice.Name = "tb_primePrice";
            this.tb_primePrice.Size = new System.Drawing.Size(100, 22);
            this.tb_primePrice.TabIndex = 2;
            // 
            // Form_NewStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 500);
            this.Controls.Add(this.cb_quantiy);
            this.Controls.Add(label7);
            this.Controls.Add(label6);
            this.Controls.Add(this.tb_category);
            this.Controls.Add(label5);
            this.Controls.Add(this.tb_barcode);
            this.Controls.Add(this.tb_price);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(label4);
            this.Controls.Add(label3);
            this.Controls.Add(label1);
            this.Controls.Add(this.tb_primePrice);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_CC);
            this.Controls.Add(this.btn_NCh);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_NewStock";
            this.Text = "Form_NewStock";
            this.Load += new System.EventHandler(this.Form_NewStock_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Timer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.Button btn_NCh;
        private System.Windows.Forms.Button btn_CC;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.ComboBox cb_quantiy;
        private System.Windows.Forms.TextBox tb_category;
        private System.Windows.Forms.TextBox tb_barcode;
        private System.Windows.Forms.TextBox tb_price;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_primePrice;
    }
}