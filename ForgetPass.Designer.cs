
namespace Nguyen_CRM
{
    partial class ForgetPass
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLaylaiMK = new System.Windows.Forms.Button();
            this.txtTenDN = new System.Windows.Forms.TextBox();
            this.labelKetqua = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtKetqua = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.txtKetqua);
            this.panel1.Controls.Add(this.btnLaylaiMK);
            this.panel1.Controls.Add(this.txtTenDN);
            this.panel1.Controls.Add(this.labelKetqua);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(274, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 510);
            this.panel1.TabIndex = 2;
            // 
            // btnLaylaiMK
            // 
            this.btnLaylaiMK.FlatAppearance.BorderSize = 2;
            this.btnLaylaiMK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLaylaiMK.ForeColor = System.Drawing.Color.White;
            this.btnLaylaiMK.Location = new System.Drawing.Point(175, 340);
            this.btnLaylaiMK.Name = "btnLaylaiMK";
            this.btnLaylaiMK.Size = new System.Drawing.Size(184, 53);
            this.btnLaylaiMK.TabIndex = 7;
            this.btnLaylaiMK.Text = "LẤY LẠI MẬT KHẨU";
            this.btnLaylaiMK.UseVisualStyleBackColor = true;
            this.btnLaylaiMK.Click += new System.EventHandler(this.btnLaylaiMK_Click);
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(172, 159);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(267, 26);
            this.txtTenDN.TabIndex = 4;
            // 
            // labelKetqua
            // 
            this.labelKetqua.AutoSize = true;
            this.labelKetqua.ForeColor = System.Drawing.Color.White;
            this.labelKetqua.Location = new System.Drawing.Point(73, 228);
            this.labelKetqua.Name = "labelKetqua";
            this.labelKetqua.Size = new System.Drawing.Size(64, 20);
            this.labelKetqua.TabIndex = 3;
            this.labelKetqua.Text = "Kết quả";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(32, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên đăng nhập";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(178, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(178, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hãy điền tên đăng nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(137, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "QUÊN MẬT KHẨU";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtKetqua
            // 
            this.txtKetqua.Location = new System.Drawing.Point(172, 222);
            this.txtKetqua.Name = "txtKetqua";
            this.txtKetqua.Size = new System.Drawing.Size(267, 26);
            this.txtKetqua.TabIndex = 8;
            // 
            // ForgetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(72)))), ((int)(((byte)(137)))), ((int)(((byte)(170)))));
            this.ClientSize = new System.Drawing.Size(1060, 652);
            this.Controls.Add(this.panel1);
            this.Name = "ForgetPass";
            this.Text = "ForgetPass";
            this.Load += new System.EventHandler(this.ForgetPass_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLaylaiMK;
        private System.Windows.Forms.TextBox txtTenDN;
        private System.Windows.Forms.Label labelKetqua;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKetqua;
    }
}