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
    public partial class feedback : Form
    {
        Dictionary<string, string> columnMapping = new Dictionary<string, string>();

        SqlConnection connection;//ketnoi
        SqlCommand command;//thuchien
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();//docdulieu
        DataTable table = new DataTable();

        public string MaFeedback;
        public string Tieude;
        public string Noidung;
        public string NgayGQ;
        public string MaSP;
        public string MaKH;
        public string MaNV;
        public string Douutien;
        public string Trangthai;
        public string Giaiphap;
        public string Danhgia;

        public feedback()
        {
            InitializeComponent();
            columnMapping.Add("Mã phản hồi/Khiếu nại", "feedback_id");
            columnMapping.Add("Mã khách hàng", "customer_id");
            columnMapping.Add("Ngày giải quyết", "submitted_day");
            columnMapping.Add("Mã nhân viên", "staff_id");
            columnMapping.Add("Mức độ ưu tiên", "priority");
            columnMapping.Add("Trạng thái", "status");
            columnMapping.Add("Tiêu đề", "title");
            columnMapping.Add("Mã sản phẩm", "product_id");
            columnMapping.Add("Đánh giá", "rate");
        }

        private void feedback_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.feedbacks' table. You can move, or remove it, as needed.
            this.feedbacksTableAdapter.Fill(this.dataSet1.feedbacks);
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
            command.CommandText = "select * from feedbacks";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvKhieunai.DataSource = table;
        }

        private void dgvKhieunai_Click(object sender, EventArgs e)
        {
            int i;
            i = dgvKhieunai.CurrentRow.Index;
            MaFeedback = dgvKhieunai.Rows[i].Cells[0].Value.ToString();
            Tieude = dgvKhieunai.Rows[i].Cells[1].Value.ToString();
            Noidung = dgvKhieunai.Rows[i].Cells[2].Value.ToString();
            NgayGQ = dgvKhieunai.Rows[i].Cells[3].Value.ToString();
            MaSP = dgvKhieunai.Rows[i].Cells[4].Value.ToString();
            MaKH = dgvKhieunai.Rows[i].Cells[5].Value.ToString();
            MaNV = dgvKhieunai.Rows[i].Cells[6].Value.ToString();
            Douutien = dgvKhieunai.Rows[i].Cells[7].Value.ToString();
            Trangthai = dgvKhieunai.Rows[i].Cells[8].Value.ToString();
            Giaiphap = dgvKhieunai.Rows[i].Cells[9].Value.ToString();
            Danhgia = dgvKhieunai.Rows[i].Cells[10].Value.ToString();
        }

        private void dgvKhieunai_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Feedback_Detail f = new Feedback_Detail();
            f.MaFeedback = MaFeedback;
            f.MaKH = MaKH;
            f.MaNV = MaNV;
            f.MaSP = MaSP;
            f.Tieude = Tieude;
            f.Giaiphap = Giaiphap;
            f.Danhgia = Danhgia;
            f.NgayGQ = NgayGQ;
            f.Noidung = Noidung;
            f.Trangthai = Trangthai;
            f.Douutien = Douutien;
            f.Show();
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
                string sql = $"SELECT * FROM feedbacks WHERE {selectedColumn} LIKE @searchtext";

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
                        dgvKhieunai.DataSource = table;
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvKhieunai.CurrentCell.RowIndex;
                string feedbackID = dgvKhieunai.Rows[index].Cells["feedbackidDataGridViewTextBoxColumn"].Value.ToString();

                SqlCommand command = new SqlCommand("DELETE FROM feedbacks WHERE feedback_id = @MaCS", connection);
                command.Parameters.AddWithValue("@MaCS", feedbackID);
                command.ExecuteNonQuery();
                dgvKhieunai.Rows.RemoveAt(index);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu khỏi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            New_Feedback f = new New_Feedback();
            f.MaFeedback = MaFeedback;
            f.MaKH = MaKH;
            f.MaNV = MaNV;
            f.MaSP = MaSP;
            f.Tieude = Tieude;
            f.Giaiphap = Giaiphap;
            f.Danhgia = Danhgia;
            f.NgayGQ = NgayGQ;
            f.Noidung = Noidung;
            f.Trangthai = Trangthai;
            f.Douutien = Douutien;
            f.Show();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvKhieunai.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                excelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvKhieunai.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = dgvKhieunai.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgvKhieunai.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvKhieunai.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvKhieunai.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dgvKhieunai.Rows.Count > 0)
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
                            PdfPTable pTable = new PdfPTable(dgvKhieunai.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgvKhieunai.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewrow in dgvKhieunai.Rows)
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
    }
}
