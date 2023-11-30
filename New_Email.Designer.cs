
namespace Nguyen_CRM
{
    partial class New_Email
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
            this.txtCC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Setting = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.cbNguoigui = new System.Windows.Forms.ComboBox();
            this.staffsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.emailandUser = new Nguyen_CRM.EmailandUser();
            this.label12 = new System.Windows.Forms.Label();
            this.chkSSL = new System.Windows.Forms.CheckBox();
            this.txtSmtp = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbNhomKH = new System.Windows.Forms.ComboBox();
            this.groupsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label10 = new System.Windows.Forms.Label();
            this.dtNgaygui = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMaEmail = new System.Windows.Forms.TextBox();
            this.staffsTableAdapter = new Nguyen_CRM.EmailandUserTableAdapters.staffsTableAdapter();
            this.groupsTableAdapter = new Nguyen_CRM.EmailandUserTableAdapters.groupsTableAdapter();
            this.txtTennhomKH = new System.Windows.Forms.TextBox();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.txtEmailNV = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.Setting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.staffsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailandUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(231, 138);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(309, 26);
            this.txtCC.TabIndex = 4;
            this.txtCC.TextChanged += new System.EventHandler(this.txtCC_TextChanged);
            this.txtCC.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCC_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(154, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "CC:";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(231, 180);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(823, 26);
            this.txtSubject.TabIndex = 8;
            this.txtSubject.TextChanged += new System.EventHandler(this.txtSubject_TextChanged);
            this.txtSubject.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubject_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(119, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tiêu đề:";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(231, 86);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(309, 26);
            this.txtTo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Địa chỉ Email nhận:";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(231, 237);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(823, 139);
            this.txtMessage.TabIndex = 10;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(107, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Nội dung:";
            // 
            // Setting
            // 
            this.Setting.Controls.Add(this.btnThoat);
            this.Setting.Controls.Add(this.btnLuu);
            this.Setting.Controls.Add(this.btnSend);
            this.Setting.Location = new System.Drawing.Point(231, 427);
            this.Setting.Name = "Setting";
            this.Setting.Size = new System.Drawing.Size(823, 83);
            this.Setting.TabIndex = 11;
            this.Setting.TabStop = false;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(670, 25);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(133, 33);
            this.btnThoat.TabIndex = 7;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(531, 25);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(133, 33);
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Text = "Lưu Email";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(392, 25);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(133, 33);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "Gửi Email";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // cbNguoigui
            // 
            this.cbNguoigui.DataSource = this.staffsBindingSource;
            this.cbNguoigui.DisplayMember = "staff_id";
            this.cbNguoigui.FormattingEnabled = true;
            this.cbNguoigui.Location = new System.Drawing.Point(764, 136);
            this.cbNguoigui.Name = "cbNguoigui";
            this.cbNguoigui.Size = new System.Drawing.Size(290, 28);
            this.cbNguoigui.TabIndex = 19;
            this.cbNguoigui.SelectedIndexChanged += new System.EventHandler(this.cbNguoigui_SelectedIndexChanged);
            this.cbNguoigui.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbNguoigui_KeyDown);
            // 
            // staffsBindingSource
            // 
            this.staffsBindingSource.DataMember = "staffs";
            this.staffsBindingSource.DataSource = this.emailandUser;
            // 
            // emailandUser
            // 
            this.emailandUser.DataSetName = "EmailandUser";
            this.emailandUser.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(656, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "Người gửi:";
            // 
            // chkSSL
            // 
            this.chkSSL.AutoSize = true;
            this.chkSSL.Location = new System.Drawing.Point(988, 397);
            this.chkSSL.Name = "chkSSL";
            this.chkSSL.Size = new System.Drawing.Size(66, 24);
            this.chkSSL.TabIndex = 1;
            this.chkSSL.Text = "SSL";
            this.chkSSL.UseVisualStyleBackColor = true;
            this.chkSSL.CheckedChanged += new System.EventHandler(this.chkSSL_CheckedChanged);
            // 
            // txtSmtp
            // 
            this.txtSmtp.Location = new System.Drawing.Point(1105, 311);
            this.txtSmtp.Name = "txtSmtp";
            this.txtSmtp.Size = new System.Drawing.Size(40, 26);
            this.txtSmtp.TabIndex = 4;
            this.txtSmtp.Text = "smtp.gmail.com";
            this.txtSmtp.Visible = false;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(1105, 265);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(43, 26);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "587";
            this.txtPort.Visible = false;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(1105, 213);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(43, 26);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.Visible = false;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(1105, 163);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(43, 26);
            this.txtUsername.TabIndex = 0;
            this.txtUsername.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(587, 89);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(158, 20);
            this.label9.TabIndex = 12;
            this.label9.Text = "Nhóm khách hàng:";
            // 
            // cbNhomKH
            // 
            this.cbNhomKH.DataSource = this.groupsBindingSource;
            this.cbNhomKH.DisplayMember = "group_id";
            this.cbNhomKH.FormattingEnabled = true;
            this.cbNhomKH.Location = new System.Drawing.Point(764, 86);
            this.cbNhomKH.Name = "cbNhomKH";
            this.cbNhomKH.Size = new System.Drawing.Size(290, 28);
            this.cbNhomKH.TabIndex = 13;
            this.cbNhomKH.SelectedIndexChanged += new System.EventHandler(this.cbNhomKH_SelectedIndexChanged);
            this.cbNhomKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbNhomKH_KeyDown);
            // 
            // groupsBindingSource
            // 
            this.groupsBindingSource.DataMember = "groups";
            this.groupsBindingSource.DataSource = this.emailandUser;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(662, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Ngày gửi:";
            // 
            // dtNgaygui
            // 
            this.dtNgaygui.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgaygui.Location = new System.Drawing.Point(764, 34);
            this.dtNgaygui.Name = "dtNgaygui";
            this.dtNgaygui.Size = new System.Drawing.Size(290, 26);
            this.dtNgaygui.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(105, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "Mã Email:";
            // 
            // txtMaEmail
            // 
            this.txtMaEmail.Location = new System.Drawing.Point(231, 33);
            this.txtMaEmail.Name = "txtMaEmail";
            this.txtMaEmail.Size = new System.Drawing.Size(309, 26);
            this.txtMaEmail.TabIndex = 17;
            this.txtMaEmail.TextChanged += new System.EventHandler(this.txtMaEmail_TextChanged);
            this.txtMaEmail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaEmail_KeyDown);
            // 
            // staffsTableAdapter
            // 
            this.staffsTableAdapter.ClearBeforeFill = true;
            // 
            // groupsTableAdapter
            // 
            this.groupsTableAdapter.ClearBeforeFill = true;
            // 
            // txtTennhomKH
            // 
            this.txtTennhomKH.Location = new System.Drawing.Point(1105, 36);
            this.txtTennhomKH.Name = "txtTennhomKH";
            this.txtTennhomKH.Size = new System.Drawing.Size(43, 26);
            this.txtTennhomKH.TabIndex = 20;
            this.txtTennhomKH.Visible = false;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(1105, 78);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(43, 26);
            this.txtTenNV.TabIndex = 21;
            this.txtTenNV.Visible = false;
            // 
            // txtEmailNV
            // 
            this.txtEmailNV.Location = new System.Drawing.Point(1105, 120);
            this.txtEmailNV.Name = "txtEmailNV";
            this.txtEmailNV.Size = new System.Drawing.Size(43, 26);
            this.txtEmailNV.TabIndex = 22;
            this.txtEmailNV.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // New_Email
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 546);
            this.Controls.Add(this.cbNguoigui);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtEmailNV);
            this.Controls.Add(this.chkSSL);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.txtTennhomKH);
            this.Controls.Add(this.txtMaEmail);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.dtNgaygui);
            this.Controls.Add(this.txtSmtp);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.cbNhomKH);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Setting);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label1);
            this.Name = "New_Email";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New_Email";
            this.Load += new System.EventHandler(this.New_Email_Load);
            this.Setting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.staffsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailandUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox Setting;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.CheckBox chkSSL;
        private System.Windows.Forms.TextBox txtSmtp;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbNhomKH;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtNgaygui;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMaEmail;
        private System.Windows.Forms.ComboBox cbNguoigui;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
        private EmailandUser emailandUser;
        private System.Windows.Forms.BindingSource staffsBindingSource;
        private EmailandUserTableAdapters.staffsTableAdapter staffsTableAdapter;
        private System.Windows.Forms.BindingSource groupsBindingSource;
        private EmailandUserTableAdapters.groupsTableAdapter groupsTableAdapter;
        private System.Windows.Forms.TextBox txtTennhomKH;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.TextBox txtEmailNV;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}