
namespace Nguyen_CRM
{
    partial class New_Product
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
            this.cbTrangthai = new System.Windows.Forms.ComboBox();
            this.cbDVT = new System.Windows.Forms.ComboBox();
            this.txtMota = new System.Windows.Forms.TextBox();
            this.txtDacdiem = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtVer = new System.Windows.Forms.TextBox();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtMaSP = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.txtGiayphep = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // cbTrangthai
            // 
            this.cbTrangthai.FormattingEnabled = true;
            this.cbTrangthai.Items.AddRange(new object[] {
            "Kinh doanh",
            "Ngừng kinh doanh"});
            this.cbTrangthai.Location = new System.Drawing.Point(413, 457);
            this.cbTrangthai.Name = "cbTrangthai";
            this.cbTrangthai.Size = new System.Drawing.Size(366, 28);
            this.cbTrangthai.TabIndex = 33;
            this.cbTrangthai.SelectedIndexChanged += new System.EventHandler(this.cbTrangthai_SelectedIndexChanged);
            this.cbTrangthai.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTrangthai_KeyDown);
            // 
            // cbDVT
            // 
            this.cbDVT.FormattingEnabled = true;
            this.cbDVT.Items.AddRange(new object[] {
            "Cái",
            "Bộ"});
            this.cbDVT.Location = new System.Drawing.Point(413, 357);
            this.cbDVT.Name = "cbDVT";
            this.cbDVT.Size = new System.Drawing.Size(366, 28);
            this.cbDVT.TabIndex = 32;
            this.cbDVT.SelectedIndexChanged += new System.EventHandler(this.cbDVT_SelectedIndexChanged);
            this.cbDVT.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbDVT_KeyDown);
            // 
            // txtMota
            // 
            this.txtMota.Location = new System.Drawing.Point(413, 511);
            this.txtMota.Name = "txtMota";
            this.txtMota.Size = new System.Drawing.Size(366, 26);
            this.txtMota.TabIndex = 31;
            this.txtMota.TextChanged += new System.EventHandler(this.txtMota_TextChanged);
            // 
            // txtDacdiem
            // 
            this.txtDacdiem.Location = new System.Drawing.Point(413, 407);
            this.txtDacdiem.Name = "txtDacdiem";
            this.txtDacdiem.Size = new System.Drawing.Size(366, 26);
            this.txtDacdiem.TabIndex = 30;
            this.txtDacdiem.TextChanged += new System.EventHandler(this.txtDacdiem_TextChanged);
            this.txtDacdiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDacdiem_KeyDown);
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(413, 255);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(366, 26);
            this.txtGia.TabIndex = 29;
            this.txtGia.TextChanged += new System.EventHandler(this.txtGia_TextChanged);
            this.txtGia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGia_KeyDown);
            // 
            // txtVer
            // 
            this.txtVer.Location = new System.Drawing.Point(413, 202);
            this.txtVer.Name = "txtVer";
            this.txtVer.Size = new System.Drawing.Size(366, 26);
            this.txtVer.TabIndex = 28;
            this.txtVer.TextChanged += new System.EventHandler(this.txtVer_TextChanged);
            this.txtVer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVer_KeyDown);
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(413, 155);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(366, 26);
            this.txtTen.TabIndex = 27;
            this.txtTen.TextChanged += new System.EventHandler(this.txtTen_TextChanged);
            this.txtTen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTen_KeyDown);
            // 
            // txtMaSP
            // 
            this.txtMaSP.Location = new System.Drawing.Point(413, 108);
            this.txtMaSP.Name = "txtMaSP";
            this.txtMaSP.Size = new System.Drawing.Size(253, 26);
            this.txtMaSP.TabIndex = 26;
            this.txtMaSP.TextChanged += new System.EventHandler(this.txtMaSP_TextChanged);
            this.txtMaSP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaSP_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(237, 514);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Mô tả";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(234, 460);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 24;
            this.label8.Text = "Trạng thái";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(234, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 20);
            this.label7.TabIndex = 23;
            this.label7.Text = "Đặc điểm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(234, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Đơn vị tính";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(234, 258);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 21;
            this.label5.Text = "Đơn giá";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Phiên bản";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Tên sản phẩm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Mã sản phẩm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(408, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(347, 25);
            this.label1.TabIndex = 17;
            this.label1.Text = "THÊM MỚI SẢN PHẨM - DỊCH VỤ";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(413, 574);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(89, 40);
            this.btnLuu.TabIndex = 34;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(690, 574);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(89, 40);
            this.btnHuy.TabIndex = 35;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtGiayphep
            // 
            this.txtGiayphep.Location = new System.Drawing.Point(413, 306);
            this.txtGiayphep.Name = "txtGiayphep";
            this.txtGiayphep.Size = new System.Drawing.Size(366, 26);
            this.txtGiayphep.TabIndex = 37;
            this.txtGiayphep.TextChanged += new System.EventHandler(this.txtGiayphep_TextChanged);
            this.txtGiayphep.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGiayphep_KeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(237, 312);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 20);
            this.label10.TabIndex = 36;
            this.label10.Text = "Giấy phép";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // New_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 648);
            this.Controls.Add(this.txtGiayphep);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.cbTrangthai);
            this.Controls.Add(this.cbDVT);
            this.Controls.Add(this.txtMota);
            this.Controls.Add(this.txtDacdiem);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.txtVer);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.txtMaSP);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "New_Product";
            this.Text = "New_Product";
            this.Load += new System.EventHandler(this.New_Product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTrangthai;
        private System.Windows.Forms.ComboBox cbDVT;
        private System.Windows.Forms.TextBox txtMota;
        private System.Windows.Forms.TextBox txtDacdiem;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.TextBox txtVer;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtMaSP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.TextBox txtGiayphep;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}