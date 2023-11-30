
namespace Nguyen_CRM
{
    partial class Report
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
            this.btnBaocaoMar = new System.Windows.Forms.Button();
            this.btnBaocaoKD = new System.Windows.Forms.Button();
            this.btnBaocaoCSKH = new System.Windows.Forms.Button();
            this.btnBaocaoKQLV = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtNgayKT = new System.Windows.Forms.DateTimePicker();
            this.dtNgayBD = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBaocaoDT = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBaocaoMar
            // 
            this.btnBaocaoMar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnBaocaoMar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBaocaoMar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaocaoMar.Location = new System.Drawing.Point(0, 754);
            this.btnBaocaoMar.Name = "btnBaocaoMar";
            this.btnBaocaoMar.Size = new System.Drawing.Size(1069, 127);
            this.btnBaocaoMar.TabIndex = 4;
            this.btnBaocaoMar.Text = "Báo cáo chiến dịch Marketing";
            this.btnBaocaoMar.UseVisualStyleBackColor = false;
            this.btnBaocaoMar.Click += new System.EventHandler(this.btnBaocaoMar_Click);
            // 
            // btnBaocaoKD
            // 
            this.btnBaocaoKD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnBaocaoKD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBaocaoKD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaocaoKD.Location = new System.Drawing.Point(0, 627);
            this.btnBaocaoKD.Name = "btnBaocaoKD";
            this.btnBaocaoKD.Size = new System.Drawing.Size(1069, 127);
            this.btnBaocaoKD.TabIndex = 5;
            this.btnBaocaoKD.Text = "Báo cáo kinh doanh";
            this.btnBaocaoKD.UseVisualStyleBackColor = false;
            this.btnBaocaoKD.Click += new System.EventHandler(this.btnBaocaoKD_Click);
            // 
            // btnBaocaoCSKH
            // 
            this.btnBaocaoCSKH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnBaocaoCSKH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBaocaoCSKH.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaocaoCSKH.Location = new System.Drawing.Point(0, 500);
            this.btnBaocaoCSKH.Name = "btnBaocaoCSKH";
            this.btnBaocaoCSKH.Size = new System.Drawing.Size(1069, 127);
            this.btnBaocaoCSKH.TabIndex = 6;
            this.btnBaocaoCSKH.Text = "Báo cáo chăm sóc khách hàng";
            this.btnBaocaoCSKH.UseVisualStyleBackColor = false;
            this.btnBaocaoCSKH.Click += new System.EventHandler(this.btnBaocaoCSKH_Click);
            // 
            // btnBaocaoKQLV
            // 
            this.btnBaocaoKQLV.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnBaocaoKQLV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBaocaoKQLV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaocaoKQLV.Location = new System.Drawing.Point(0, 238);
            this.btnBaocaoKQLV.Name = "btnBaocaoKQLV";
            this.btnBaocaoKQLV.Size = new System.Drawing.Size(1069, 141);
            this.btnBaocaoKQLV.TabIndex = 8;
            this.btnBaocaoKQLV.Text = "Báo cáo kết quả làm việc";
            this.btnBaocaoKQLV.UseVisualStyleBackColor = false;
            this.btnBaocaoKQLV.Click += new System.EventHandler(this.btnBaocaoKQLV_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Pink;
            this.groupBox1.Controls.Add(this.dtNgayKT);
            this.groupBox1.Controls.Add(this.dtNgayBD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1069, 238);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // dtNgayKT
            // 
            this.dtNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayKT.Location = new System.Drawing.Point(39, 124);
            this.dtNgayKT.Name = "dtNgayKT";
            this.dtNgayKT.Size = new System.Drawing.Size(221, 26);
            this.dtNgayKT.TabIndex = 4;
            // 
            // dtNgayBD
            // 
            this.dtNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayBD.Location = new System.Drawing.Point(39, 53);
            this.dtNgayBD.Name = "dtNgayBD";
            this.dtNgayBD.Size = new System.Drawing.Size(221, 26);
            this.dtNgayBD.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Đến ngày";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Từ ngày";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(552, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "DANH SÁCH BÁO CÁO";
            // 
            // btnBaocaoDT
            // 
            this.btnBaocaoDT.BackColor = System.Drawing.Color.Yellow;
            this.btnBaocaoDT.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnBaocaoDT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaocaoDT.Location = new System.Drawing.Point(0, 379);
            this.btnBaocaoDT.Name = "btnBaocaoDT";
            this.btnBaocaoDT.Size = new System.Drawing.Size(1069, 121);
            this.btnBaocaoDT.TabIndex = 7;
            this.btnBaocaoDT.Text = "Báo cáo doanh thu";
            this.btnBaocaoDT.UseVisualStyleBackColor = false;
            this.btnBaocaoDT.Click += new System.EventHandler(this.btnBaocaoDT_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 881);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBaocaoKQLV);
            this.Controls.Add(this.btnBaocaoDT);
            this.Controls.Add(this.btnBaocaoCSKH);
            this.Controls.Add(this.btnBaocaoKD);
            this.Controls.Add(this.btnBaocaoMar);
            this.Name = "Report";
            this.Text = "Report";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBaocaoMar;
        private System.Windows.Forms.Button btnBaocaoKD;
        private System.Windows.Forms.Button btnBaocaoCSKH;
        private System.Windows.Forms.Button btnBaocaoKQLV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtNgayKT;
        private System.Windows.Forms.DateTimePicker dtNgayBD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBaocaoDT;
    }
}