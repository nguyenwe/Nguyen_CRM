using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Nguyen_CRM
{
    public partial class frmEmail : Form
    {
        Dictionary<string, string> columnMapping = new Dictionary<string, string>();

        SqlConnection connection;//ketnoi
        SqlCommand command;//thuchien
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();//docdulieu
        DataTable table = new DataTable();

        public string MaEmail;
        public string Tieude;
        public string Noidung;
        public string Ngaygui;
        public string Nguoigui;
        public string NhomKh;

        public frmEmail()
        {
            InitializeComponent();
            columnMapping.Add("Mã Email", "email_id");
            columnMapping.Add("Tiêu đề", "title");
            columnMapping.Add("Ngày gửi", "despatch");
            columnMapping.Add("Người gửi", "staff_id");
            columnMapping.Add("Nhóm khách hàng", "group_id");
        }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        void loaddata()
        {
            if (connection == null)
            {
                connection = new SqlConnection(str);
                connection.Open();
            }
            command = connection.CreateCommand();
            command.CommandText = "select * from emails";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvEmail.DataSource = table;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvEmail.CurrentCell.RowIndex;
                string serviceID = dgvEmail.Rows[index].Cells["emailidDataGridViewTextBoxColumn"].Value.ToString();

                SqlCommand command = new SqlCommand("DELETE FROM emails WHERE email_id = @MaEmail", connection);
                command.Parameters.AddWithValue("@MaEmail", serviceID);
                command.ExecuteNonQuery();
                dgvEmail.Rows.RemoveAt(index);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu khỏi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEmail_Click(object sender, EventArgs e)
        {
            int i;
            i = dgvEmail.CurrentRow.Index;
            MaEmail = dgvEmail.Rows[i].Cells[0].Value.ToString();
            Tieude = dgvEmail.Rows[i].Cells[1].Value.ToString();
            Noidung = dgvEmail.Rows[i].Cells[2].Value.ToString();
            Ngaygui = dgvEmail.Rows[i].Cells[3].Value.ToString();
            Nguoigui = dgvEmail.Rows[i].Cells[4].Value.ToString();
            NhomKh = dgvEmail.Rows[i].Cells[5].Value.ToString();
        }

        //private void dgvEmail_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    New_Email f = new New_Email();
        //    f.Show();
        //}

        private void btnThem_Click(object sender, EventArgs e)
        {
            New_Email f = new New_Email();
            f.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void cbTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTimkiem.Focus();
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string searchtext = txtTimkiem.Text.Trim();
            if (searchtext != "")
            {
                SearchandFilterData(searchtext);
            }
            else
            {
                loaddata();
            }
        }

        private void SearchandFilterData(string searchtext)
        {
            if (cbTimkiem.SelectedItem != null && columnMapping.ContainsKey(cbTimkiem.SelectedItem.ToString()))
            {
                string selectedColumn = columnMapping[cbTimkiem.SelectedItem.ToString()];
                string sql = $"SELECT * FROM emails WHERE {selectedColumn} LIKE @searchtext";

                if (connection != null)
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@searchtext", "%" + searchtext + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvEmail.DataSource = table;
                    }
                }
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dgvEmail.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf) |*.pdf";
                save.FileName = "Result.pdf";
                bool ErrorMessage = false;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(save.FileName))
                    {
                        try
                        {
                            File.Delete(save.FileName);
                        }
                        catch (Exception ex)
                        {
                            ErrorMessage = true;
                            MessageBox.Show("unable to write data in disk " + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(dgvEmail.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgvEmail.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewrow in dgvEmail.Rows)
                            {
                                foreach (DataGridViewCell dcell in viewrow.Cells)
                                {
                                    if (dcell.Value != null)
                                    {
                                        pTable.AddCell(dcell.Value.ToString());
                                    }
                                    else
                                    {
                                        pTable.AddCell("");
                                    }
                                }
                            }

                            using (FileStream filestream = new FileStream(save.FileName, FileMode.Create))
                            {
                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);
                                PdfWriter.GetInstance(document, filestream);
                                document.Open();
                                document.Add(pTable);
                                document.Close();
                                filestream.Close();
                            }
                            MessageBox.Show("Data export successfully", "info");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while exporting Data " + ex.Message);
                        }
                    }

                }

            }
            else
            {
                MessageBox.Show("No Record Found", "Info");
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvEmail.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                excelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvEmail.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = dgvEmail.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgvEmail.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvEmail.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvEmail.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }
    }
}
