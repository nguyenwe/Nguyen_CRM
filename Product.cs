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
    public partial class Product : Form
    {
        Dictionary<string, string> columnMapping = new Dictionary<string, string>();

        Ketnoi kn = new Ketnoi();
        SqlConnection connection;//ketnoi
        SqlCommand command;//thuchien
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();//docdulieu
        DataTable table = new DataTable();

        public string MaSP;
        public string TenSP;
        public string Phienban;
        public string Dongia;
        public string DVT;
        public string Giayphep;
        public string Dacdiem;
        public string Trangthai;
        public string Mota;

        public Product()
        {
            InitializeComponent();
            columnMapping.Add("Mã sản phẩm", "product_id");
            columnMapping.Add("Tên sản phẩm", "name");
            columnMapping.Add("Phiên bản", "version");
            columnMapping.Add("Đơn vị tính", "unit_price");
            columnMapping.Add("Trạng thái", "status");
            columnMapping.Add("Đặc điểm", "feature");
        }

        private void Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.dataSet1.products);
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
            command.CommandText = "select * from products";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvProduct.DataSource = table;

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            New_Product f = new New_Product();
            f.MaSP = MaSP;
            f.TenSP = TenSP;
            f.Phienban = Phienban;
            f.DVT = DVT;
            f.Dongia = Dongia;
            f.Giayphep = Giayphep;
            f.Dacdiem = Dacdiem;
            f.Trangthai = Trangthai;
            f.Mota = Mota;
            f.Show();
        }

        private void dgvProduct_Click(object sender, EventArgs e)
        {
            int i;
            i = dgvProduct.CurrentRow.Index;
            MaSP = dgvProduct.Rows[i].Cells[0].Value.ToString();
            TenSP = dgvProduct.Rows[i].Cells[1].Value.ToString();
            Phienban = dgvProduct.Rows[i].Cells[2].Value.ToString();
            Dongia = dgvProduct.Rows[i].Cells[3].Value.ToString();
            DVT = dgvProduct.Rows[i].Cells[4].Value.ToString();
            Giayphep = dgvProduct.Rows[i].Cells[5].Value.ToString();
            Dacdiem = dgvProduct.Rows[i].Cells[6].Value.ToString();
            Trangthai = dgvProduct.Rows[i].Cells[7].Value.ToString();
            Mota = dgvProduct.Rows[i].Cells[8].Value.ToString();
        }

        private void hiểnThịChiTiếtSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_Detail f = new Product_Detail();
            f.Show();
        }

        private void dgvProduct_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Product_Detail f = new Product_Detail();
            f.MaSP = MaSP;
            f.TenSP = TenSP;
            f.Giayphep = Giayphep;
            f.Dongia = Dongia;
            f.DVT = DVT;
            f.Dacdiem = Dacdiem;
            f.Trangthai = Trangthai;
            f.Mota = Mota;
            f.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dgvProduct.CurrentCell.RowIndex;
                string productID = dgvProduct.Rows[index].Cells["productidDataGridViewTextBoxColumn"].Value.ToString();

                SqlCommand command = new SqlCommand("DELETE FROM products WHERE product_id = @MaSP", connection);
                command.Parameters.AddWithValue("@MaSP", productID);
                command.ExecuteNonQuery();
                dgvProduct.Rows.RemoveAt(index);

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
                string sql = $"SELECT * FROM products WHERE {selectedColumn} LIKE @searchtext";

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
                        dgvProduct.DataSource = table;
                    }
                }
            }
        }

        private void cbTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTimkiem.Focus();
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dgvProduct.Rows.Count > 0)
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
                            PdfPTable pTable = new PdfPTable(dgvProduct.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgvProduct.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewrow in dgvProduct.Rows)
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
            if (dgvProduct.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                excelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvProduct.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = dgvProduct.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgvProduct.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvProduct.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvProduct.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }
    }
}
