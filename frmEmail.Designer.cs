﻿
namespace Nguyen_CRM
{
    partial class frmEmail
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTimkiem = new System.Windows.Forms.ComboBox();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvEmail = new System.Windows.Forms.DataGridView();
            this.emailidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.despatchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailsBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new Nguyen_CRM.DataSet1();
            this.emailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.emailandUser = new Nguyen_CRM.EmailandUser();
            this.emailsTableAdapter = new Nguyen_CRM.EmailandUserTableAdapters.emailsTableAdapter();
            this.emailandUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.emailsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.emailsTableAdapter1 = new Nguyen_CRM.DataSet1TableAdapters.emailsTableAdapter();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailsBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailandUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailandUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.cbTimkiem);
            this.flowLayoutPanel1.Controls.Add(this.txtTimkiem);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1306, 71);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tìm theo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbTimkiem
            // 
            this.cbTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTimkiem.FormattingEnabled = true;
            this.cbTimkiem.Items.AddRange(new object[] {
            "Mã Email",
            "Tiêu đề",
            "Ngày gửi",
            "Người gửi",
            "Nhóm khách hàng"});
            this.cbTimkiem.Location = new System.Drawing.Point(103, 3);
            this.cbTimkiem.Name = "cbTimkiem";
            this.cbTimkiem.Size = new System.Drawing.Size(192, 33);
            this.cbTimkiem.TabIndex = 5;
            this.cbTimkiem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbTimkiem_KeyDown);
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimkiem.Location = new System.Drawing.Point(301, 3);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(298, 30);
            this.txtTimkiem.TabIndex = 6;
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.btnThem);
            this.flowLayoutPanel2.Controls.Add(this.btnXoa);
            this.flowLayoutPanel2.Controls.Add(this.btnLoad);
            this.flowLayoutPanel2.Controls.Add(this.btnExcel);
            this.flowLayoutPanel2.Controls.Add(this.btnPDF);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 71);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1306, 74);
            this.flowLayoutPanel2.TabIndex = 5;
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.Location = new System.Drawing.Point(3, 3);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(111, 37);
            this.btnThem.TabIndex = 8;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.Location = new System.Drawing.Point(120, 3);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(111, 37);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(237, 3);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(135, 37);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Làm mới";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcel.Location = new System.Drawing.Point(378, 3);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(135, 37);
            this.btnExcel.TabIndex = 6;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPDF.Location = new System.Drawing.Point(519, 3);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(122, 37);
            this.btnPDF.TabIndex = 5;
            this.btnPDF.Text = "Xuất PDF";
            this.btnPDF.UseVisualStyleBackColor = true;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvEmail);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 145);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1306, 511);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách Email";
            // 
            // dgvEmail
            // 
            this.dgvEmail.AutoGenerateColumns = false;
            this.dgvEmail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmail.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.emailidDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.contentDataGridViewTextBoxColumn,
            this.despatchDataGridViewTextBoxColumn,
            this.staffidDataGridViewTextBoxColumn,
            this.groupidDataGridViewTextBoxColumn});
            this.dgvEmail.DataSource = this.emailsBindingSource2;
            this.dgvEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmail.Location = new System.Drawing.Point(3, 22);
            this.dgvEmail.Name = "dgvEmail";
            this.dgvEmail.RowHeadersWidth = 62;
            this.dgvEmail.RowTemplate.Height = 28;
            this.dgvEmail.Size = new System.Drawing.Size(1300, 486);
            this.dgvEmail.TabIndex = 0;
            this.dgvEmail.Click += new System.EventHandler(this.dgvEmail_Click);
            // 
            // emailidDataGridViewTextBoxColumn
            // 
            this.emailidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.emailidDataGridViewTextBoxColumn.DataPropertyName = "email_id";
            this.emailidDataGridViewTextBoxColumn.FillWeight = 463.6364F;
            this.emailidDataGridViewTextBoxColumn.HeaderText = "Mã Email";
            this.emailidDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.emailidDataGridViewTextBoxColumn.Name = "emailidDataGridViewTextBoxColumn";
            this.emailidDataGridViewTextBoxColumn.Width = 150;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "title";
            this.titleDataGridViewTextBoxColumn.FillWeight = 27.27273F;
            this.titleDataGridViewTextBoxColumn.HeaderText = "Tiêu đề";
            this.titleDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            // 
            // contentDataGridViewTextBoxColumn
            // 
            this.contentDataGridViewTextBoxColumn.DataPropertyName = "content";
            this.contentDataGridViewTextBoxColumn.FillWeight = 27.27273F;
            this.contentDataGridViewTextBoxColumn.HeaderText = "Nội dung";
            this.contentDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.contentDataGridViewTextBoxColumn.Name = "contentDataGridViewTextBoxColumn";
            // 
            // despatchDataGridViewTextBoxColumn
            // 
            this.despatchDataGridViewTextBoxColumn.DataPropertyName = "despatch";
            this.despatchDataGridViewTextBoxColumn.FillWeight = 27.27273F;
            this.despatchDataGridViewTextBoxColumn.HeaderText = "Ngày gửi";
            this.despatchDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.despatchDataGridViewTextBoxColumn.Name = "despatchDataGridViewTextBoxColumn";
            // 
            // staffidDataGridViewTextBoxColumn
            // 
            this.staffidDataGridViewTextBoxColumn.DataPropertyName = "staff_id";
            this.staffidDataGridViewTextBoxColumn.FillWeight = 27.27273F;
            this.staffidDataGridViewTextBoxColumn.HeaderText = "Người gửi";
            this.staffidDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.staffidDataGridViewTextBoxColumn.Name = "staffidDataGridViewTextBoxColumn";
            // 
            // groupidDataGridViewTextBoxColumn
            // 
            this.groupidDataGridViewTextBoxColumn.DataPropertyName = "group_id";
            this.groupidDataGridViewTextBoxColumn.FillWeight = 27.27273F;
            this.groupidDataGridViewTextBoxColumn.HeaderText = "Nhóm khách hàng";
            this.groupidDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.groupidDataGridViewTextBoxColumn.Name = "groupidDataGridViewTextBoxColumn";
            // 
            // emailsBindingSource2
            // 
            this.emailsBindingSource2.DataMember = "emails";
            this.emailsBindingSource2.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // emailsBindingSource
            // 
            this.emailsBindingSource.DataMember = "emails";
            this.emailsBindingSource.DataSource = this.emailandUser;
            // 
            // emailandUser
            // 
            this.emailandUser.DataSetName = "EmailandUser";
            this.emailandUser.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // emailsTableAdapter
            // 
            this.emailsTableAdapter.ClearBeforeFill = true;
            // 
            // emailandUserBindingSource
            // 
            this.emailandUserBindingSource.DataSource = this.emailandUser;
            this.emailandUserBindingSource.Position = 0;
            // 
            // emailsBindingSource1
            // 
            this.emailsBindingSource1.DataMember = "emails";
            this.emailsBindingSource1.DataSource = this.emailandUser;
            // 
            // emailsTableAdapter1
            // 
            this.emailsTableAdapter1.ClearBeforeFill = true;
            // 
            // frmEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 656);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "frmEmail";
            this.Text = "frmEmail";
            this.Load += new System.EventHandler(this.frmEmail_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailsBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailandUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailandUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailsBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTimkiem;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvEmail;
        private EmailandUser emailandUser;
        private System.Windows.Forms.BindingSource emailsBindingSource;
        private EmailandUserTableAdapters.emailsTableAdapter emailsTableAdapter;
        private System.Windows.Forms.BindingSource emailsBindingSource1;
        private System.Windows.Forms.BindingSource emailandUserBindingSource;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource emailsBindingSource2;
        private DataSet1TableAdapters.emailsTableAdapter emailsTableAdapter1;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn despatchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn staffidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupidDataGridViewTextBoxColumn;
    }
}