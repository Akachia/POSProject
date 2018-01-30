namespace POSproject_KSM
{
    partial class Form_InStock
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label4;
            this.btn_check = new System.Windows.Forms.Button();
            this.tb_Barcode = new System.Windows.Forms.TextBox();
            this.lv_OrderCh = new System.Windows.Forms.ListView();
            this.btn_BarCh = new System.Windows.Forms.Button();
            this.lbl_TtlOrder = new System.Windows.Forms.Label();
            this.lbl_OrderCus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Exit = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            label1.Location = new System.Drawing.Point(12, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(49, 12);
            label1.TabIndex = 3;
            label1.Text = "바코드 :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(13, 63);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(65, 12);
            label2.TabIndex = 5;
            label2.Text = "발주 총액 :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(284, 63);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(49, 12);
            label4.TabIndex = 7;
            label4.Text = "발주자 :";
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(207, 458);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(75, 35);
            this.btn_check.TabIndex = 0;
            this.btn_check.Text = "확인";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // tb_Barcode
            // 
            this.tb_Barcode.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_Barcode.Location = new System.Drawing.Point(85, 12);
            this.tb_Barcode.Name = "tb_Barcode";
            this.tb_Barcode.Size = new System.Drawing.Size(185, 22);
            this.tb_Barcode.TabIndex = 1;
            this.tb_Barcode.TextChanged += new System.EventHandler(this.tb_Barcode_TextChanged);
            // 
            // lv_OrderCh
            // 
            this.lv_OrderCh.Location = new System.Drawing.Point(0, 99);
            this.lv_OrderCh.Name = "lv_OrderCh";
            this.lv_OrderCh.Size = new System.Drawing.Size(601, 351);
            this.lv_OrderCh.TabIndex = 2;
            this.lv_OrderCh.UseCompatibleStateImageBehavior = false;
            this.lv_OrderCh.View = System.Windows.Forms.View.Details;
            // 
            // btn_BarCh
            // 
            this.btn_BarCh.Location = new System.Drawing.Point(513, 10);
            this.btn_BarCh.Name = "btn_BarCh";
            this.btn_BarCh.Size = new System.Drawing.Size(75, 25);
            this.btn_BarCh.TabIndex = 4;
            this.btn_BarCh.Text = "바코드확인";
            this.btn_BarCh.UseVisualStyleBackColor = true;
            this.btn_BarCh.Click += new System.EventHandler(this.btn_BarCh_Click);
            // 
            // lbl_TtlOrder
            // 
            this.lbl_TtlOrder.AutoSize = true;
            this.lbl_TtlOrder.Location = new System.Drawing.Point(84, 63);
            this.lbl_TtlOrder.Name = "lbl_TtlOrder";
            this.lbl_TtlOrder.Size = new System.Drawing.Size(0, 12);
            this.lbl_TtlOrder.TabIndex = 6;
            // 
            // lbl_OrderCus
            // 
            this.lbl_OrderCus.AutoSize = true;
            this.lbl_OrderCus.Location = new System.Drawing.Point(339, 63);
            this.lbl_OrderCus.Name = "lbl_OrderCus";
            this.lbl_OrderCus.Size = new System.Drawing.Size(38, 12);
            this.lbl_OrderCus.TabIndex = 8;
            this.lbl_OrderCus.Text = "label5";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(0, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(601, 53);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(314, 458);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(75, 35);
            this.btn_Exit.TabIndex = 12;
            this.btn_Exit.Text = "취소";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // Form_InStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.lbl_OrderCus);
            this.Controls.Add(label4);
            this.Controls.Add(this.lbl_TtlOrder);
            this.Controls.Add(label2);
            this.Controls.Add(this.btn_BarCh);
            this.Controls.Add(label1);
            this.Controls.Add(this.lv_OrderCh);
            this.Controls.Add(this.tb_Barcode);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_InStock";
            this.Text = "Form_InStock";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form_InStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.TextBox tb_Barcode;
        private System.Windows.Forms.ListView lv_OrderCh;
        private System.Windows.Forms.Button btn_BarCh;
        private System.Windows.Forms.Label lbl_TtlOrder;
        private System.Windows.Forms.Label lbl_OrderCus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Exit;
    }
}