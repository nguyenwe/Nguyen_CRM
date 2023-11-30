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
    public partial class service_history : Form
    {
        Dictionary<string, string> columnMapping = new Dictionary<string, string>();

        SqlConnection connection;//ketnoi
        SqlCommand command;//thuchien
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();//docdulieu
        DataTable table = new DataTable();

        public string MaCS;
        public string MaKH;
        public string Noidung;
        public string NgayCS;
        public string MaNV;
        public string KyCS;
        public string Douutien;
        public string Giaiphap;
        public string Trangthai;
        public string Mota;

        public service_history()
        {
            InitializeComponent();
            columnMapping.Add("Mã chăm sóc", "service_id");
            columnMapping.Add("Mã khách hàng", "customer_id");
            columnMapping.Add("Ngày chăm sóc", "submitted_day");
            columnMapping.Add("Mã nhân viên", "staff_id");
            columnMapping.Add("Mức độ ưu tiên", "priority");
            columnMapping.Add("Trạng thái", "status");
        }

        void loaddata()
        {
            if (connection == null)
            {
                connection = new SqlConnection(str);
                connection.Open();
            }
            command = connection.CreateCommand();
            command.CommandText = "select * from services";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvCSKH.DataSource = table;
        }

        private void service_history_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.services' table. You can move, or remove it, as needed.
            this.servicesTableAdapter.Fill(this.dataSet1.services);
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void dgvCSKH_Click(object sender, EventArgs e)
        {
            int i;
            i = dgvCSKH.CurrentRow.Index;
            MaCS = dgvCSKH.Rows[i].Cells[0].Value.ToString();
            MaKH = dgvCSKH.Rows[i].Cells[1].Value.ToString();
            Noidung = dgvCSKH.Rows[i].Cells[2].Value.ToString();
            NgayCS = dgvCSKH.Rows[i].Cells[3].Value.ToString();
            MaNV = dgvCSKH.Rows[i].Cells[4].Value.ToString();
            KyCS = dgvCSKH.Rows[i].Cells[5].Value.ToString();
            Douutien = dgvCSKH.Rows[i].Cells[6].Value.ToString();
            Giaiphap = dgvCSKH.Rows[i].Cells[7].Value.ToString();
            Trangthai = dgvCSKH.Rows[i].Cells[8].Value.ToString();
            Mota = dgvCSKH.Rows[i].Cells[9].Value.ToString();
        }

        private void dgvCSKH_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Service_Detail f = new Service_Detail();
            f.MaCS = MaCS;
            f.MaKH = MaKH;
            f.MaNV = MaNV;
            f.NgayCS = NgayCS;
            f.KyCS = KyCS;
            f.Douutien = Douutien;
            f.Noidung = Noidung;
            f.Mota = Mota;
            f.Trangthai = Trangthai;
            f.Giaiphap = Giaiphap;
            f.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvCSKH.CurrentCell.RowIndex;
                string serviceID = dgvCSKH.Rows[index].Cells["serviceidDataGridViewTextBoxColumn"].Value.ToString();

                SqlCommand command = new SqlCommand("DELETE FROM services WHERE service_id = @MaCS", connection);
                command.Parameters.AddWithValue("@MaCS", serviceID);
                command.ExecuteNonQuery();
                dgvCSKH.Rows.RemoveAt(index);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu khỏi CSDL: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            New_Service f = new New_Service();
            f.MaCS = MaCS;
            f.MaKH = MaKH;
            f.MaNV = MaNV;
            f.NgayCS = NgayCS;
            f.KyCS = KyCS;
            f.Douutien = Douutien;
            f.Noidung = Noidung;
            f.Mota = Mota;
            f.Trangthai = Trangthai;
            f.Giaiphap = Giaiphap;
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
                string sql = $"SELECT * FROM services WHERE {selectedColumn} LIKE @searchtext";

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
                        dgvCSKH.DataSource = table;
                    }
                }
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvCSKH.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                excelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvCSKH.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = dgvCSKH.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgvCSKH.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvCSKH.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvCSKH.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dgvCSKH.Rows.Count > 0)
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF (*.pdf) |*.pdf";
                save.FileName = "KetQua.pdf";
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
                            MessageBox.Show("Không thể lưu! " + ex.Message);
                        }
                    }
                    if (!ErrorMessage)
                    {
                        try
                        {
                            PdfPTable pTable = new PdfPTable(dgvCSKH.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgvCSKH.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewrow in dgvCSKH.Rows)
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
                            MessageBox.Show("Xuất dữ liệu thành file PDF thành công!", "Thông báo");

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xuất dữ liệu " + ex.Message);
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
