
namespace Nguyen_CRM
{
    partial class Quote_Detail
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaBG = new System.Windows.Forms.TextBox();
            this.txtTieude = new System.Windows.Forms.TextBox();
            this.txtMota = new System.Windows.Forms.TextBox();
            this.txtNoidung = new System.Windows.Forms.TextBox();
            this.dtNgayBG = new System.Windows.Forms.DateTimePicker();
            this.dtNgayhluc = new System.Windows.Forms.DateTimePicker();
            this.cbMaKH = new System.Windows.Forms.ComboBox();
            this.leadsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Nguyen_CRM.DataSet1();
            this.cbNguoiBG = new System.Windows.Forms.ComboBox();
            this.staffsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnThoat = new System.Windows.Forms.Button();
            this.leadsTableAdapter = new Nguyen_CRM.DataSet1TableAdapters.leadsTableAdapter();
            this.staffsTableAdapter = new Nguyen_CRM.DataSet1TableAdapters.staffsTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvQuoteDetail = new System.Windows.Forms.DataGridView();
            this.quoteidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quotedetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chitietBaoGia = new Nguyen_CRM.ChitietBaoGia();
            this.quote_detailTableAdapter = new Nguyen_CRM.ChitietBaoGiaTableAdapters.quote_detailTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.leadsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffsBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuoteDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotedetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chitietBaoGia)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã báo giá";
            // 
            // label3
            // 
            this.label3.AccessibleRole = System.Windows.Forms.AccessibleRole.ScrollBar;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tiêu đề";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã khách";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(546, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Người báo giá";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(546, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày báo giá";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(546, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ngày hiệu lực";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(45, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Nội dung";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(546, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Mô tả";
            // 
            // txtMaBG
            // 
            this.txtMaBG.Location = new System.Drawing.Point(170, 47);
            this.txtMaBG.Name = "txtMaBG";
            this.txtMaBG.ReadOnly = true;
            this.txtMaBG.Size = new System.Drawing.Size(139, 26);
            this.txtMaBG.TabIndex = 9;
            // 
            // txtTieude
            // 
            this.txtTieude.Location = new System.Drawing.Point(170, 84);
            this.txtTieude.Name = "txtTieude";
            this.txtTieude.ReadOnly = true;
            this.txtTieude.Size = new System.Drawing.Size(246, 26);
            this.txtTieude.TabIndex = 10;
            // 
            // txtMota
            // 
            this.txtMota.Location = new System.Drawing.Point(686, 163);
            this.txtMota.Name = "txtMota";
            this.txtMota.ReadOnly = true;
            this.txtMota.Size = new System.Drawing.Size(303, 26);
            this.txtMota.TabIndex = 11;
            // 
            // txtNoidung
            // 
            this.txtNoidung.Location = new System.Drawing.Point(49, 186);
            this.txtNoidung.Multiline = true;
            this.txtNoidung.Name = "txtNoidung";
            this.txtNoidung.ReadOnly = true;
            this.txtNoidung.Size = new System.Drawing.Size(472, 77);
            this.txtNoidung.TabIndex = 12;
            // 
            // dtNgayBG
            // 
            this.dtNgayBG.Enabled = false;
            this.dtNgayBG.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayBG.Location = new System.Drawing.Point(686, 50);
            this.dtNgayBG.Name = "dtNgayBG";
            this.dtNgayBG.Size = new System.Drawing.Size(303, 26);
            this.dtNgayBG.TabIndex = 13;
            // 
            // dtNgayhluc
            // 
            this.dtNgayhluc.Enabled = false;
            this.dtNgayhluc.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayhluc.Location = new System.Drawing.Point(686, 87);
            this.dtNgayhluc.Name = "dtNgayhluc";
            this.dtNgayhluc.Size = new System.Drawing.Size(303, 26);
            this.dtNgayhluc.TabIndex = 14;
            // 
            // cbMaKH
            // 
            this.cbMaKH.DataSource = this.leadsBindingSource;
            this.cbMaKH.DisplayMember = "lead_id";
            this.cbMaKH.Enabled = false;
            this.cbMaKH.FormattingEnabled = true;
            this.cbMaKH.Location = new System.Drawing.Point(170, 122);
            this.cbMaKH.Name = "cbMaKH";
            this.cbMaKH.Size = new System.Drawing.Size(246, 28);
            this.cbMaKH.TabIndex = 15;
            // 
            // leadsBindingSource
            // 
            this.leadsBindingSource.DataMember = "leads";
            this.leadsBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cbNguoiBG
            // 
            this.cbNguoiBG.DataSource = this.staffsBindingSource;
            this.cbNguoiBG.DisplayMember = "staff_id";
            this.cbNguoiBG.Enabled = false;
            this.cbNguoiBG.FormattingEnabled = true;
            this.cbNguoiBG.Location = new System.Drawing.Point(686, 124);
            this.cbNguoiBG.Name = "cbNguoiBG";
            this.cbNguoiBG.Size = new System.Drawing.Size(303, 28);
            this.cbNguoiBG.TabIndex = 16;
            // 
            // staffsBindingSource
            // 
            this.staffsBindingSource.DataMember = "staffs";
            this.staffsBindingSource.DataSource = this.dataSet1;
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(909, 556);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(80, 36);
            this.btnThoat.TabIndex = 18;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // leadsTableAdapter
            // 
            this.leadsTableAdapter.ClearBeforeFill = true;
            // 
            // staffsTableAdapter
            // 
            this.staffsTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNoidung);
            this.groupBox1.Controls.Add(this.cbNguoiBG);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbMaKH);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtNgayhluc);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtNgayBG);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtMota);
            this.groupBox1.Controls.Add(this.txtMaBG);
            this.groupBox1.Controls.Add(this.txtTieude);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 282);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CHI TIẾT BÁO GIÁ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvQuoteDetail);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 282);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1008, 256);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SẢN PHẨM BÁO GIÁ";
            // 
            // dgvQuoteDetail
            // 
            this.dgvQuoteDetail.AutoGenerateColumns = false;
            this.dgvQuoteDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuoteDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuoteDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuoteDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.quoteidDataGridViewTextBoxColumn,
            this.productidDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.dgvQuoteDetail.DataSource = this.quotedetailBindingSource;
            this.dgvQuoteDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuoteDetail.Location = new System.Drawing.Point(3, 22);
            this.dgvQuoteDetail.Name = "dgvQuoteDetail";
            this.dgvQuoteDetail.RowHeadersWidth = 62;
            this.dgvQuoteDetail.RowTemplate.Height = 28;
            this.dgvQuoteDetail.Size = new System.Drawing.Size(1002, 231);
            this.dgvQuoteDetail.TabIndex = 1;
            // 
            // quoteidDataGridViewTextBoxColumn
            // 
            this.quoteidDataGridViewTextBoxColumn.DataPropertyName = "quote_id";
            this.quoteidDataGridViewTextBoxColumn.HeaderText = "quote_id";
            this.quoteidDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.quoteidDataGridViewTextBoxColumn.Name = "quoteidDataGridViewTextBoxColumn";
            // 
            // productidDataGridViewTextBoxColumn
            // 
            this.productidDataGridViewTextBoxColumn.DataPropertyName = "product_id";
            this.productidDataGridViewTextBoxColumn.HeaderText = "product_id";
            this.productidDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.productidDataGridViewTextBoxColumn.Name = "productidDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "quantity";
            this.quantityDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // quotedetailBindingSource
            // 
            this.quotedetailBindingSource.DataMember = "quote_detail";
            this.quotedetailBindingSource.DataSource = this.chitietBaoGia;
            // 
            // chitietBaoGia
            // 
            this.chitietBaoGia.DataSetName = "ChitietBaoGia";
            this.chitietBaoGia.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // quote_detailTableAdapter
            // 
            this.quote_detailTableAdapter.ClearBeforeFill = true;
            // 
            // Quote_Detail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 604);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnThoat);
            this.Font = new System.Drawing.Font("Times New Roman", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Quote_Detail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quote_Detail";
            this.Load += new System.EventHandler(this.Quote_Detail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.leadsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staffsBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuoteDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotedetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chitietBaoGia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaBG;
        private System.Windows.Forms.TextBox txtTieude;
        private System.Windows.Forms.TextBox txtMota;
        private System.Windows.Forms.TextBox txtNoidung;
        private System.Windows.Forms.DateTimePicker dtNgayBG;
        private System.Windows.Forms.DateTimePicker dtNgayhluc;
        private System.Windows.Forms.ComboBox cbMaKH;
        private System.Windows.Forms.ComboBox cbNguoiBG;
        private System.Windows.Forms.Button btnThoat;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource leadsBindingSource;
        private DataSet1TableAdapters.leadsTableAdapter leadsTableAdapter;
        private System.Windows.Forms.BindingSource staffsBindingSource;
        private DataSet1TableAdapters.staffsTableAdapter staffsTableAdapter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvQuoteDetail;
        private ChitietBaoGia chitietBaoGia;
        private System.Windows.Forms.BindingSource quotedetailBindingSource;
        private ChitietBaoGiaTableAdapters.quote_detailTableAdapter quote_detailTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn quoteidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
    }
}