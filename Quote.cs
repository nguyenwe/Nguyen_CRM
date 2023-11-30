﻿using System;
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
    public partial class Quote : Form
    {

        Dictionary<string, string> columnMapping = new Dictionary<string, string>();

        SqlConnection connection;//ketnoi
        SqlCommand command;//thuchien
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();//docdulieu
        DataTable table = new DataTable();

        public string maQuote;
        public string ngayBG;
        public string tieude;
        public string noidung;
        public string makhach;
        public string nguoiBG;
        public string ngayhieuluc;
        public string Mota;

        public Quote()
        {
            InitializeComponent();
            columnMapping.Add("Mã báo giá", "quote_id");
            columnMapping.Add("Tiêu đề", "title");
            columnMapping.Add("Mã khách", "lead_id");
            columnMapping.Add("Người báo giá", "contact_id");
            columnMapping.Add("Ngày báo giá", "quote_day");
        }

        private void Quote_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.quotes' table. You can move, or remove it, as needed.
            this.quotesTableAdapter.Fill(this.dataSet1.quotes);
            connection = new SqlConnection(str);
            connection.Open();
        }

        void loaddata()
        {
            if (connection == null)
            {
                connection = new SqlConnection(str);
                connection.Open();
            }
            command = connection.CreateCommand();
            command.CommandText = "select * from quotes";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvQuote.DataSource = table;

        }

        private void cbTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
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
                string sql = $"SELECT * FROM quotes WHERE {selectedColumn} LIKE @searchtext";

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
                        dgvQuote.DataSource = table;
                    }
                }
            }
        }

        private void dgvQuote_Click(object sender, EventArgs e)
        {
            int i;
            i = dgvQuote.CurrentRow.Index;
            maQuote = dgvQuote.Rows[i].Cells[0].Value.ToString();
            ngayBG = dgvQuote.Rows[i].Cells[1].Value.ToString();
            tieude = dgvQuote.Rows[i].Cells[2].Value.ToString();
            noidung = dgvQuote.Rows[i].Cells[3].Value.ToString();
            makhach = dgvQuote.Rows[i].Cells[4].Value.ToString();
            nguoiBG = dgvQuote.Rows[i].Cells[5].Value.ToString();
            ngayhieuluc = dgvQuote.Rows[i].Cells[6].Value.ToString();
            Mota = dgvQuote.Rows[i].Cells[7].Value.ToString();
        }

        private void dgvQuote_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Quote_Detail f = new Quote_Detail();
            f.maQuote = maQuote;
            f.tieude = tieude;
            f.makhach = makhach;
            f.nguoiBG = nguoiBG;
            f.ngayBG = ngayBG;
            f.ngayhieuluc = ngayhieuluc;
            f.Mota = Mota;
            f.noidung = noidung;
            f.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            New_Quote f = new New_Quote();
            f.maQuote = maQuote;
            f.tieude = tieude;
            f.makhach = makhach;
            f.nguoiBG = nguoiBG;
            f.ngayBG = ngayBG;
            f.ngayhieuluc = ngayhieuluc;
            f.Mota = Mota;
            f.noidung = noidung;
            f.Show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvQuote.CurrentCell.RowIndex;
                string quoteID = dgvQuote.Rows[index].Cells["quoteidDataGridViewTextBoxColumn"].Value.ToString();

                SqlCommand command = new SqlCommand("DELETE FROM quotes WHERE quote_id = @MaBG", connection);
                command.Parameters.AddWithValue("@MaBG", quoteID);
                command.ExecuteNonQuery();
                dgvQuote.Rows.RemoveAt(index);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu khỏi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dgvQuote.Rows.Count > 0)
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
                            PdfPTable pTable = new PdfPTable(dgvQuote.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgvQuote.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewrow in dgvQuote.Rows)
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
            if (dgvQuote.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                excelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvQuote.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = dgvQuote.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgvQuote.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvQuote.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvQuote.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }
    }
}
