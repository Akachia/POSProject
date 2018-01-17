namespace formSales
{
    partial class Form_Main
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
            this.btnLock = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCalc = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnUserSet = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MethodsOfPayment = new System.Windows.Forms.GroupBox();
            this.rbtCard = new System.Windows.Forms.RadioButton();
            this.rbtCash = new System.Windows.Forms.RadioButton();
            this.btnCntMod = new System.Windows.Forms.Button();
            this.txtProdCount = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtChange = new System.Windows.Forms.TextBox();
            this.txtPay = new System.Windows.Forms.TextBox();
            this.txtFinalPrice = new System.Windows.Forms.TextBox();
            this.txtTotalDis = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnNum7 = new System.Windows.Forms.Button();
            this.btnNum8 = new System.Windows.Forms.Button();
            this.btnNum9 = new System.Windows.Forms.Button();
            this.btnNumRemove = new System.Windows.Forms.Button();
            this.btnNumOK = new System.Windows.Forms.Button();
            this.btnNum6 = new System.Windows.Forms.Button();
            this.btnNum5 = new System.Windows.Forms.Button();
            this.btnNum4 = new System.Windows.Forms.Button();
            this.btnNum3 = new System.Windows.Forms.Button();
            this.btnNum2 = new System.Windows.Forms.Button();
            this.btnNum1 = new System.Windows.Forms.Button();
            this.numThreeZero = new System.Windows.Forms.Button();
            this.numTwoZero = new System.Windows.Forms.Button();
            this.numZero = new System.Windows.Forms.Button();
            this.lbl_time = new System.Windows.Forms.Label();
            this.lbl_user = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.MethodsOfPayment.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(627, 63);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(75, 57);
            this.btnLock.TabIndex = 1;
            this.btnLock.Text = "화면잠금";
            this.btnLock.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(627, 129);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 57);
            this.button1.TabIndex = 2;
            this.button1.Text = "재고관리";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Location = new System.Drawing.Point(627, 195);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(75, 57);
            this.btnCalc.TabIndex = 3;
            this.btnCalc.Text = "정산";
            this.btnCalc.UseVisualStyleBackColor = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(627, 261);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 57);
            this.btnPrint.TabIndex = 4;
            this.btnPrint.Text = "영수증출력";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(710, 261);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 57);
            this.button4.TabIndex = 8;
            this.button4.Text = "환불";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnUserSet
            // 
            this.btnUserSet.Location = new System.Drawing.Point(710, 195);
            this.btnUserSet.Name = "btnUserSet";
            this.btnUserSet.Size = new System.Drawing.Size(75, 57);
            this.btnUserSet.TabIndex = 7;
            this.btnUserSet.Text = "직원관리";
            this.btnUserSet.UseVisualStyleBackColor = true;
            this.btnUserSet.Click += new System.EventHandler(this.btnUserSet_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(710, 129);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 57);
            this.button6.TabIndex = 6;
            this.button6.Text = "매출관리";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // btnSetting
            // 
            this.btnSetting.Location = new System.Drawing.Point(710, 63);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(75, 57);
            this.btnSetting.TabIndex = 5;
            this.btnSetting.Text = "환경설정";
            this.btnSetting.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.MethodsOfPayment);
            this.groupBox1.Controls.Add(this.btnCntMod);
            this.groupBox1.Controls.Add(this.txtProdCount);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnPay);
            this.groupBox1.Controls.Add(this.btnCancle);
            this.groupBox1.Controls.Add(this.btnRegister);
            this.groupBox1.Controls.Add(this.txtBarcode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 260);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // MethodsOfPayment
            // 
            this.MethodsOfPayment.Controls.Add(this.rbtCard);
            this.MethodsOfPayment.Controls.Add(this.rbtCash);
            this.MethodsOfPayment.Location = new System.Drawing.Point(18, 124);
            this.MethodsOfPayment.Name = "MethodsOfPayment";
            this.MethodsOfPayment.Size = new System.Drawing.Size(243, 44);
            this.MethodsOfPayment.TabIndex = 36;
            this.MethodsOfPayment.TabStop = false;
            this.MethodsOfPayment.Text = "결제수단";
            // 
            // rbtCard
            // 
            this.rbtCard.AutoSize = true;
            this.rbtCard.Location = new System.Drawing.Point(141, 20);
            this.rbtCard.Name = "rbtCard";
            this.rbtCard.Size = new System.Drawing.Size(47, 16);
            this.rbtCard.TabIndex = 1;
            this.rbtCard.Text = "카드";
            this.rbtCard.UseVisualStyleBackColor = true;
            // 
            // rbtCash
            // 
            this.rbtCash.AutoSize = true;
            this.rbtCash.Checked = true;
            this.rbtCash.Location = new System.Drawing.Point(54, 20);
            this.rbtCash.Name = "rbtCash";
            this.rbtCash.Size = new System.Drawing.Size(47, 16);
            this.rbtCash.TabIndex = 0;
            this.rbtCash.TabStop = true;
            this.rbtCash.Text = "현금";
            this.rbtCash.UseVisualStyleBackColor = true;
            // 
            // btnCntMod
            // 
            this.btnCntMod.Location = new System.Drawing.Point(186, 78);
            this.btnCntMod.Name = "btnCntMod";
            this.btnCntMod.Size = new System.Drawing.Size(75, 29);
            this.btnCntMod.TabIndex = 35;
            this.btnCntMod.Text = "수량 정정";
            this.btnCntMod.UseVisualStyleBackColor = true;
            this.btnCntMod.Click += new System.EventHandler(this.btnCntMod_Click);
            // 
            // txtProdCount
            // 
            this.txtProdCount.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtProdCount.Location = new System.Drawing.Point(88, 78);
            this.txtProdCount.Name = "txtProdCount";
            this.txtProdCount.Size = new System.Drawing.Size(89, 29);
            this.txtProdCount.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(13, 83);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 19);
            this.label10.TabIndex = 33;
            this.label10.Text = "수량";
            // 
            // btnPay
            // 
            this.btnPay.Location = new System.Drawing.Point(186, 182);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(75, 57);
            this.btnPay.TabIndex = 32;
            this.btnPay.Text = "결제";
            this.btnPay.UseVisualStyleBackColor = true;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(102, 182);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 57);
            this.btnCancle.TabIndex = 31;
            this.btnCancle.Text = "취소";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(18, 182);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 57);
            this.btnRegister.TabIndex = 29;
            this.btnRegister.Text = "등록";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBarcode.Location = new System.Drawing.Point(88, 24);
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(175, 29);
            this.txtBarcode.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(13, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 19);
            this.label4.TabIndex = 29;
            this.label4.Text = "바코드";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtChange);
            this.groupBox2.Controls.Add(this.txtPay);
            this.groupBox2.Controls.Add(this.txtFinalPrice);
            this.groupBox2.Controls.Add(this.txtTotalDis);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTotalPrice);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(297, 328);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 260);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // txtChange
            // 
            this.txtChange.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtChange.Location = new System.Drawing.Point(113, 206);
            this.txtChange.Name = "txtChange";
            this.txtChange.Size = new System.Drawing.Size(175, 29);
            this.txtChange.TabIndex = 43;
            this.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPay
            // 
            this.txtPay.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPay.Location = new System.Drawing.Point(113, 161);
            this.txtPay.Name = "txtPay";
            this.txtPay.Size = new System.Drawing.Size(175, 29);
            this.txtPay.TabIndex = 42;
            this.txtPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFinalPrice
            // 
            this.txtFinalPrice.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtFinalPrice.Location = new System.Drawing.Point(113, 116);
            this.txtFinalPrice.Name = "txtFinalPrice";
            this.txtFinalPrice.Size = new System.Drawing.Size(175, 29);
            this.txtFinalPrice.TabIndex = 41;
            this.txtFinalPrice.Text = "0";
            this.txtFinalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotalDis
            // 
            this.txtTotalDis.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTotalDis.Location = new System.Drawing.Point(113, 71);
            this.txtTotalDis.Name = "txtTotalDis";
            this.txtTotalDis.Size = new System.Drawing.Size(175, 29);
            this.txtTotalDis.TabIndex = 40;
            this.txtTotalDis.Text = "0";
            this.txtTotalDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(20, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 19);
            this.label9.TabIndex = 39;
            this.label9.Text = "잔 돈 : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(20, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 19);
            this.label8.TabIndex = 38;
            this.label8.Text = "받은 돈 : ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(20, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 19);
            this.label7.TabIndex = 37;
            this.label7.Text = "합계 : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(20, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 19);
            this.label6.TabIndex = 35;
            this.label6.Text = "할인 : ";
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTotalPrice.Location = new System.Drawing.Point(113, 24);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.Size = new System.Drawing.Size(175, 29);
            this.txtTotalPrice.TabIndex = 34;
            this.txtTotalPrice.Text = "0";
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(20, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 19);
            this.label5.TabIndex = 33;
            this.label5.Text = "소계 : ";
            // 
            // btnNum7
            // 
            this.btnNum7.Location = new System.Drawing.Point(627, 353);
            this.btnNum7.Name = "btnNum7";
            this.btnNum7.Size = new System.Drawing.Size(40, 49);
            this.btnNum7.TabIndex = 11;
            this.btnNum7.Text = "7";
            this.btnNum7.UseVisualStyleBackColor = true;
            // 
            // btnNum8
            // 
            this.btnNum8.Location = new System.Drawing.Point(667, 353);
            this.btnNum8.Name = "btnNum8";
            this.btnNum8.Size = new System.Drawing.Size(40, 49);
            this.btnNum8.TabIndex = 12;
            this.btnNum8.Text = "8";
            this.btnNum8.UseVisualStyleBackColor = true;
            // 
            // btnNum9
            // 
            this.btnNum9.Location = new System.Drawing.Point(707, 353);
            this.btnNum9.Name = "btnNum9";
            this.btnNum9.Size = new System.Drawing.Size(40, 49);
            this.btnNum9.TabIndex = 13;
            this.btnNum9.Text = "9";
            this.btnNum9.UseVisualStyleBackColor = true;
            // 
            // btnNumRemove
            // 
            this.btnNumRemove.Location = new System.Drawing.Point(747, 353);
            this.btnNumRemove.Name = "btnNumRemove";
            this.btnNumRemove.Size = new System.Drawing.Size(40, 49);
            this.btnNumRemove.TabIndex = 14;
            this.btnNumRemove.Text = "←";
            this.btnNumRemove.UseVisualStyleBackColor = true;
            // 
            // btnNumOK
            // 
            this.btnNumOK.Location = new System.Drawing.Point(747, 408);
            this.btnNumOK.Name = "btnNumOK";
            this.btnNumOK.Size = new System.Drawing.Size(40, 159);
            this.btnNumOK.TabIndex = 18;
            this.btnNumOK.Text = "확인";
            this.btnNumOK.UseVisualStyleBackColor = true;
            // 
            // btnNum6
            // 
            this.btnNum6.Location = new System.Drawing.Point(707, 408);
            this.btnNum6.Name = "btnNum6";
            this.btnNum6.Size = new System.Drawing.Size(40, 49);
            this.btnNum6.TabIndex = 17;
            this.btnNum6.Text = "6";
            this.btnNum6.UseVisualStyleBackColor = true;
            // 
            // btnNum5
            // 
            this.btnNum5.Location = new System.Drawing.Point(667, 408);
            this.btnNum5.Name = "btnNum5";
            this.btnNum5.Size = new System.Drawing.Size(40, 49);
            this.btnNum5.TabIndex = 16;
            this.btnNum5.Text = "5";
            this.btnNum5.UseVisualStyleBackColor = true;
            // 
            // btnNum4
            // 
            this.btnNum4.Location = new System.Drawing.Point(627, 408);
            this.btnNum4.Name = "btnNum4";
            this.btnNum4.Size = new System.Drawing.Size(40, 49);
            this.btnNum4.TabIndex = 15;
            this.btnNum4.Text = "4";
            this.btnNum4.UseVisualStyleBackColor = true;
            // 
            // btnNum3
            // 
            this.btnNum3.Location = new System.Drawing.Point(707, 463);
            this.btnNum3.Name = "btnNum3";
            this.btnNum3.Size = new System.Drawing.Size(40, 49);
            this.btnNum3.TabIndex = 21;
            this.btnNum3.Text = "3";
            this.btnNum3.UseVisualStyleBackColor = true;
            // 
            // btnNum2
            // 
            this.btnNum2.Location = new System.Drawing.Point(667, 463);
            this.btnNum2.Name = "btnNum2";
            this.btnNum2.Size = new System.Drawing.Size(40, 49);
            this.btnNum2.TabIndex = 20;
            this.btnNum2.Text = "2";
            this.btnNum2.UseVisualStyleBackColor = true;
            // 
            // btnNum1
            // 
            this.btnNum1.Location = new System.Drawing.Point(627, 463);
            this.btnNum1.Name = "btnNum1";
            this.btnNum1.Size = new System.Drawing.Size(40, 49);
            this.btnNum1.TabIndex = 19;
            this.btnNum1.Text = "1";
            this.btnNum1.UseVisualStyleBackColor = true;
            // 
            // numThreeZero
            // 
            this.numThreeZero.Location = new System.Drawing.Point(707, 518);
            this.numThreeZero.Name = "numThreeZero";
            this.numThreeZero.Size = new System.Drawing.Size(40, 49);
            this.numThreeZero.TabIndex = 25;
            this.numThreeZero.Text = "000";
            this.numThreeZero.UseVisualStyleBackColor = true;
            // 
            // numTwoZero
            // 
            this.numTwoZero.Location = new System.Drawing.Point(667, 518);
            this.numTwoZero.Name = "numTwoZero";
            this.numTwoZero.Size = new System.Drawing.Size(40, 49);
            this.numTwoZero.TabIndex = 24;
            this.numTwoZero.Text = "00";
            this.numTwoZero.UseVisualStyleBackColor = true;
            // 
            // numZero
            // 
            this.numZero.Location = new System.Drawing.Point(627, 518);
            this.numZero.Name = "numZero";
            this.numZero.Size = new System.Drawing.Size(40, 49);
            this.numZero.TabIndex = 23;
            this.numZero.Text = "0";
            this.numZero.UseVisualStyleBackColor = true;
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_time.Location = new System.Drawing.Point(585, 20);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(61, 19);
            this.lbl_time.TabIndex = 26;
            this.lbl_time.Text = "label1";
            // 
            // lbl_user
            // 
            this.lbl_user.AutoSize = true;
            this.lbl_user.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbl_user.Location = new System.Drawing.Point(12, 20);
            this.lbl_user.Name = "lbl_user";
            this.lbl_user.Size = new System.Drawing.Size(90, 19);
            this.lbl_user.TabIndex = 27;
            this.lbl_user.Text = "담당자 : ";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 62);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(603, 256);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(762, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(39, 39);
            this.button2.TabIndex = 28;
            this.button2.Text = "종료";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbl_user);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.numThreeZero);
            this.Controls.Add(this.numTwoZero);
            this.Controls.Add(this.numZero);
            this.Controls.Add(this.btnNum3);
            this.Controls.Add(this.btnNum2);
            this.Controls.Add(this.btnNum1);
            this.Controls.Add(this.btnNumOK);
            this.Controls.Add(this.btnNum6);
            this.Controls.Add(this.btnNum5);
            this.Controls.Add(this.btnNum4);
            this.Controls.Add(this.btnNumRemove);
            this.Controls.Add(this.btnNum9);
            this.Controls.Add(this.btnNum8);
            this.Controls.Add(this.btnNum7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnUserSet);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnCalc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLock);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MethodsOfPayment.ResumeLayout(false);
            this.MethodsOfPayment.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCalc;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnUserSet;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnNum7;
        private System.Windows.Forms.Button btnNum8;
        private System.Windows.Forms.Button btnNum9;
        private System.Windows.Forms.Button btnNumRemove;
        private System.Windows.Forms.Button btnNumOK;
        private System.Windows.Forms.Button btnNum6;
        private System.Windows.Forms.Button btnNum5;
        private System.Windows.Forms.Button btnNum4;
        private System.Windows.Forms.Button btnNum3;
        private System.Windows.Forms.Button btnNum2;
        private System.Windows.Forms.Button btnNum1;
        private System.Windows.Forms.Button numThreeZero;
        private System.Windows.Forms.Button numTwoZero;
        private System.Windows.Forms.Button numZero;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label lbl_user;
        private System.Windows.Forms.TextBox txtChange;
        private System.Windows.Forms.TextBox txtPay;
        private System.Windows.Forms.TextBox txtFinalPrice;
        private System.Windows.Forms.TextBox txtTotalDis;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtProdCount;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnCntMod;
        private System.Windows.Forms.GroupBox MethodsOfPayment;
        private System.Windows.Forms.RadioButton rbtCard;
        private System.Windows.Forms.RadioButton rbtCash;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
    }
}

