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
    public partial class Customer : Form
    {
        Dictionary<string, string> columnMapping = new Dictionary<string, string>();

        //Ketnoi kn = new Ketnoi();
        SqlConnection connection;//ketnoi
        SqlCommand command;//thuchien
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();//docdulieu
        DataTable table = new DataTable();

        public string MaKH;
        public string NhomKH;
        public string TenKH;
        public string email;
        public string Sdt;
        public string Diachi;
        public string Mota;

        public Customer()
        {
            InitializeComponent();

            columnMapping.Add("Mã khách hàng", "customer_id");
            columnMapping.Add("Nhóm khách hàng", "GROUP_ID");
            columnMapping.Add("Tên Khách hàng", "name");
            columnMapping.Add("Email", "email");
            columnMapping.Add("Số điện thoại", "phone-number");
            columnMapping.Add("Địa chỉ", "address");

        }


        void loaddata()
        {
            if(connection == null)
            {
                connection = new SqlConnection(str);
                connection.Open();
            }
            command = connection.CreateCommand();
            command.CommandText = "select * from customers";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvCustomer.DataSource = table;

        }
        private void Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter1.Fill(this.dataSet1.customers);
            // TODO: This line of code loads data into the 'cRM.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.cRM.customers);
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            New_Customer f = new New_Customer();
            f.MaKH = MaKH;
            f.NhomKH = NhomKH;
            f.TenKH = TenKH;
            f.email = email;
            f.Sdt = Sdt;
            f.Diachi = Diachi;
            f.Mota = Mota;
            f.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvCustomer.CurrentCell.RowIndex;
                string contractId = dgvCustomer.Rows[index].Cells["customeridDataGridViewTextBoxColumn1"].Value.ToString();

                SqlCommand command = new SqlCommand("DELETE FROM customers WHERE customer_id = @MaKH", connection);
                command.Parameters.AddWithValue("@MaKH", contractId);
                command.ExecuteNonQuery();
                dgvCustomer.Rows.RemoveAt(index);

            }
            catch
            {
                MessageBox.Show("Tồn tại hợp đồng của khách hàng này nên không thể xóa! ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLoad_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            int i = customersTableAdapter.Update(cRM.customers);
        }


        private void hiểnThịChiTiếtKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Detail_Customer f = new Detail_Customer();
            f.MaKH = MaKH;
            f.NhomKH = NhomKH;
            f.TenKH = TenKH;
            f.email = email;
            f.Sdt = Sdt;
            f.Diachi = Diachi;
            f.Mota = Mota;
            f.Show();

        }

        private void dgvCustomer_Click(object sender, EventArgs e)
        {
            int i;
            i = dgvCustomer.CurrentRow.Index;
            MaKH = dgvCustomer.Rows[i].Cells[0].Value.ToString();
            NhomKH = dgvCustomer.Rows[i].Cells[1].Value.ToString();
            TenKH = dgvCustomer.Rows[i].Cells[2].Value.ToString();
            email = dgvCustomer.Rows[i].Cells[3].Value.ToString();
            Sdt = dgvCustomer.Rows[i].Cells[4].Value.ToString();
            Diachi = dgvCustomer.Rows[i].Cells[5].Value.ToString();
            Mota = dgvCustomer.Rows[i].Cells[6].Value.ToString();
        }

        private void cbTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtTimkiem.Focus();
            }
        }

        private void dgvCustomer_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Bản ghi này đã tồn tại!");
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
                string sql = $"SELECT * FROM customers WHERE {selectedColumn} LIKE @searchtext";

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
                        dgvCustomer.DataSource = table;
                    }
                }
            }
        }

        private void dgvCustomer_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Detail_Customer f = new Detail_Customer();
            f.MaKH = MaKH;
            f.NhomKH = NhomKH;
            f.TenKH = TenKH;
            f.email = email;
            f.Sdt = Sdt;
            f.Diachi = Diachi;
            f.Mota = Mota;
            f.Show();
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.Rows.Count > 0)
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
                            PdfPTable pTable = new PdfPTable(dgvCustomer.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgvCustomer.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewrow in dgvCustomer.Rows)
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
            if (dgvCustomer.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                excelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvCustomer.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = dgvCustomer.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgvCustomer.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvCustomer.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvCustomer.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }
    }
}
