
namespace Nguyen_CRM
{
    partial class New_Feedback
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtNgayGQ = new System.Windows.Forms.DateTimePicker();
            this.txtNoidung = new System.Windows.Forms.TextBox();
            this.cbDanhgia = new System.Windows.Forms.ComboBox();
            this.cbTrangthai = new System.Windows.Forms.ComboBox();
            this.cbDouutien = new System.Windows.Forms.ComboBox();
            this.cbMaNV = new System.Windows.Forms.ComboBox();
            this.cbMaKH = new System.Windows.Forms.ComboBox();
            this.cbMaSP = new System.Windows.Forms.ComboBox();
            this.txtGiaiphap = new System.Windows.Forms.TextBox();
            this.txtTieude = new System.Windows.Forms.TextBox();
            this.txtMaFeedB = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.dataSet1 = new Nguyen_CRM.DataSet1();
            this.staffsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.staffsTableAdapter = new Nguyen_CRM.DataSet1TableAdapters.staffsTableAdapter();
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customersTableAdapter = new Nguyen_CRM.DataSet1TableAdapters.customersTableAdapter();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productsTableAdapter = new Nguyen_CRM.DataSet1TableAdapters.productsTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtNgayGQ);
            this.groupBox1.Controls.Add(this.txtTieude);
            this.groupBox1.Controls.Add(this.txtNoidung);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cbDanhgia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbTrangthai);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbDouutien);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbMaNV);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cbMaKH);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbMaSP);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtGiaiphap);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtMaFeedB);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1178, 493);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÊM MỚI KHIẾU NẠI - YÊU CẦU";
            // 
            // dtNgayGQ
            // 
            this.dtNgayGQ.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayGQ.Location = new System.Drawing.Point(263, 194);
            this.dtNgayGQ.Name = "dtNgayGQ";
            this.dtNgayGQ.Size = new System.Drawing.Size(293, 26);
            this.dtNgayGQ.TabIndex = 44;
            // 
            // txtNoidung
            // 
            this.txtNoidung.Location = new System.Drawing.Point(266, 390);
            this.txtNoidung.Multiline = true;
            this.txtNoidung.Name = "txtNoidung";
            this.txtNoidung.Size = new System.Drawing.Size(795, 73);
            this.txtNoidung.TabIndex = 43;
            // 
            // cbDanhgia
            // 
            this.cbDanhgia.FormattingEnabled = true;
            this.cbDanhgia.Items.AddRange(new object[] {
            "Hài lòng",
            "Chưa hài lòng",
            "Khá hài lòng"});
            this.cbDanhgia.Location = new System.Drawing.Point(799, 322);
            this.cbDanhgia.Name = "cbDanhgia";
            this.cbDanhgia.Size = new System.Drawing.Size(262, 28);
            this.cbDanhgia.TabIndex = 42;
            // 
            // cbTrangthai
            // 
            this.cbTrangthai.FormattingEnabled = true;
            this.cbTrangthai.Items.AddRange(new object[] {
            "Tiếp nhận",
            "Hoàn thành",
            "Đóng hủy"});
            this.cbTrangthai.Location = new System.Drawing.Point(799, 196);
            this.cbTrangthai.Name = "cbTrangthai";
            this.cbTrangthai.Size = new System.Drawing.Size(262, 28);
            this.cbTrangthai.TabIndex = 41;
            // 
            // cbDouutien
            // 
            this.cbDouutien.FormattingEnabled = true;
            this.cbDouutien.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cbDouutien.Location = new System.Drawing.Point(799, 133);
            this.cbDouutien.Name = "cbDouutien";
            this.cbDouutien.Size = new System.Drawing.Size(262, 28);
            this.cbDouutien.TabIndex = 40;
            // 
            // cbMaNV
            // 
            this.cbMaNV.DataSource = this.staffsBindingSource;
            this.cbMaNV.DisplayMember = "staff_id";
            this.cbMaNV.FormattingEnabled = true;
            this.cbMaNV.Location = new System.Drawing.Point(799, 70);
            this.cbMaNV.Name = "cbMaNV";
            this.cbMaNV.Size = new System.Drawing.Size(262, 28);
            this.cbMaNV.TabIndex = 39;
            // 
            // cbMaKH
            // 
            this.cbMaKH.DataSource = this.customersBindingSource;
            this.cbMaKH.DisplayMember = "customer_id";
            this.cbMaKH.FormattingEnabled = true;
            this.cbMaKH.Location = new System.Drawing.Point(266, 322);
            this.cbMaKH.Name = "cbMaKH";
            this.cbMaKH.Size = new System.Drawing.Size(290, 28);
            this.cbMaKH.TabIndex = 38;
            // 
            // cbMaSP
            // 
            this.cbMaSP.DataSource = this.productsBindingSource;
            this.cbMaSP.DisplayMember = "product_id";
            this.cbMaSP.FormattingEnabled = true;
            this.cbMaSP.Location = new System.Drawing.Point(266, 257);
            this.cbMaSP.Name = "cbMaSP";
            this.cbMaSP.Size = new System.Drawing.Size(290, 28);
            this.cbMaSP.TabIndex = 37;
            // 
            // txtGiaiphap
            // 
            this.txtGiaiphap.Location = new System.Drawing.Point(799, 259);
            this.txtGiaiphap.Name = "txtGiaiphap";
            this.txtGiaiphap.Size = new System.Drawing.Size(262, 26);
            this.txtGiaiphap.TabIndex = 36;
            // 
            // txtTieude
            // 
            this.txtTieude.Location = new System.Drawing.Point(266, 133);
            this.txtTieude.Name = "txtTieude";
            this.txtTieude.Size = new System.Drawing.Size(290, 26);
            this.txtTieude.TabIndex = 35;
            // 
            // txtMaFeedB
            // 
            this.txtMaFeedB.Location = new System.Drawing.Point(266, 70);
            this.txtMaFeedB.Name = "txtMaFeedB";
            this.txtMaFeedB.Size = new System.Drawing.Size(290, 26);
            this.txtMaFeedB.TabIndex = 34;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(130, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 20);
            this.label12.TabIndex = 33;
            this.label12.Text = "Mã sản phẩm";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(648, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 20);
            this.label11.TabIndex = 32;
            this.label11.Text = "Mã nhân viên";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(648, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(113, 20);
            this.label10.TabIndex = 31;
            this.label10.Text = "Mức độ ưu tiên";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(117, 325);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Mã khách hàng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(163, 417);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Nội dung";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "Tiêu đề";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(119, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Ngày giải quyết";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(648, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Trạng thái";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(648, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "Đánh giá";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(648, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Giải pháp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Mã khiếu nại/yêu cầu";
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(842, 514);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(99, 38);
            this.btnLuu.TabIndex = 2;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(962, 514);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(99, 38);
            this.btnThoat.TabIndex = 3;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // staffsBindingSource
            // 
            this.staffsBindingSource.DataMember = "staffs";
            this.staffsBindingSource.DataSource = this.dataSet1;
            // 
            // staffsTableAdapter
            // 
            this.staffsTableAdapter.ClearBeforeFill = true;
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataMember = "customers";
            this.customersBindingSource.DataSource = this.dataSet1;
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataMember = "products";
            this.productsBindingSource.DataSource = this.dataSet1;
            // 
            // productsTableAdapter
            // 
            this.productsTableAdapter.ClearBeforeFill = true;
            // 
            // New_Feedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 589);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.groupBox1);
            this.Name = "New_Feedback";
            this.Text = "New_Feedback";
            this.Load += new System.EventHandler(this.New_Feedback_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtNgayGQ;
        private System.Windows.Forms.TextBox txtTieude;
        private System.Windows.Forms.TextBox txtNoidung;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDanhgia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTrangthai;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDouutien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMaNV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbMaKH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbMaSP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtGiaiphap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMaFeedB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource staffsBindingSource;
        private DataSet1TableAdapters.staffsTableAdapter staffsTableAdapter;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private DataSet1TableAdapters.customersTableAdapter customersTableAdapter;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private DataSet1TableAdapters.productsTableAdapter productsTableAdapter;
    }
}