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
    public partial class Post : Form
    {
        Dictionary<string, string> columnMapping = new Dictionary<string, string>();

        Ketnoi kn = new Ketnoi();
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        public Post()
        {
            InitializeComponent();
            columnMapping.Add("Mã bài đăng", "post_id");
            columnMapping.Add("Tên bài đăng", "title");
            columnMapping.Add("Người viết", "staff_id");
            columnMapping.Add("Nội dung", "content");
            columnMapping.Add("Trạng thái", "status");
            columnMapping.Add("Từ khóa", "keyword");
        }

        private void Post_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet11.staffs' table. You can move, or remove it, as needed.
            this.staffsTableAdapter1.Fill(this.dataSet11.staffs);
            // TODO: This line of code loads data into the 'dataSet1.posts' table. You can move, or remove it, as needed.
            this.postsTableAdapter.Fill(this.dataSet1.posts);
            // TODO: This line of code loads data into the 'cRM.posts' table. You can move, or remove it, as needed.
            this.postsTableAdapter1.Fill(this.cRM.posts);
            // TODO: This line of code loads data into the 'dataSet1.posts' table. You can move, or remove it, as needed.
            this.postsTableAdapter.Fill(this.dataSet1.posts);
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
            cbNguoiviet.SelectedIndex = -1;
            cbTrangthai.SelectedIndex = -1;
        }

        void loaddata()
        {
            if (connection == null)
            {
                connection = new SqlConnection(str);
                connection.Open();
            }
            command = connection.CreateCommand();
            command.CommandText = "select * from posts";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvPost.DataSource = table;
        }

        private void dgvPost_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvPost.CurrentRow.Index;
            txtMabaidang.Text = dgvPost.Rows[i].Cells[0].Value.ToString();
            txtTenbaidang.Text = dgvPost.Rows[i].Cells[1].Value.ToString();
            txtNoidung.Text = dgvPost.Rows[i].Cells[2].Value.ToString();
            cbNguoiviet.Text = dgvPost.Rows[i].Cells[3].Value.ToString();
            dtNgaydang.Text = dgvPost.Rows[i].Cells[4].Value.ToString();
            cbTrangthai.Text = dgvPost.Rows[i].Cells[5].Value.ToString();
            txtTukhoa.Text = dgvPost.Rows[i].Cells[6].Value.ToString();
            txtMota.Text = dgvPost.Rows[i].Cells[7].Value.ToString();
        }

        private bool checktextbox()
        {
            if (txtMabaidang.Text == "")
            {
                errorProvider.SetError(txtMabaidang, "Không được để trống dữ liệu!");
                txtMabaidang.Focus();
                return false;
            }
            if (txtTenbaidang.Text == "")
            {
                errorProvider.SetError(txtTenbaidang, "Không được để trống dữ liệu!");
                txtTenbaidang.Focus();
                return false;
            }

            if (cbNguoiviet.SelectedIndex == -1)
            {
                errorProvider.SetError(cbNguoiviet, "Không được để trống dữ liệu!");
                cbNguoiviet.Focus();
                return false;
            }

            if (cbTrangthai.SelectedIndex == -1)
            {
                errorProvider.SetError(cbTrangthai, "Không được để trống dữ liệu!");
                cbTrangthai.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checktextbox())
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into posts values ('" + txtMabaidang.Text + "'," +
                    " N'" + txtTenbaidang.Text + "', N'" + txtNoidung.Text + "'," +
                    " '" + cbNguoiviet.Text + "', '" + dtNgaydang.Text + "'," +
                    " N'" + cbTrangthai.Text + "', N'" + txtTukhoa.Text + "'," +
                    " '" + txtMota.Text + "')";
                try
                {
                    command.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Đã thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Đã tồn tại mã bài đăng này!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn sửa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "update posts set title = N'" + txtTenbaidang.Text + "'," +
                    " post_id = '" + txtMabaidang.Text + "'," +
                    " status = N'" + cbTrangthai.Text + "'," +
                    " content = N'" + txtNoidung.Text + "'," +
                    " staff_id = '" + cbNguoiviet.Text + "'," +
                    " submitted_day = '" + dtNgaydang.Text + "'," +
                    " keyword = '" + txtTukhoa.Text + "'," +
                    " description = '" + txtMota.Text +  "' where post_id = '" + txtMabaidang.Text + "' ";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Đã sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ret == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from posts where post_id = '" + txtMabaidang.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaomoi_Click(object sender, EventArgs e)
        {
            txtMabaidang.Text = "";
            txtTenbaidang.Text = "";
            cbTrangthai.Text = "";
            cbNguoiviet.Text = "";
            txtNoidung.Text = "";
            txtTukhoa.Text = "";
            txtMota.Text = "";
            dtNgaydang.Text = "01/01/2010";
        }

        private void txtMabaidang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtTenbaidang.Focus();
                    }
                }
        }

        private void txtTenbaidang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        cbNguoiviet.Focus();
                    }
                }
        }

        private void cbNguoiviet_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                    {
                        txtNoidung.Focus();
                    }
        }

        private void txtNoidung_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                cbTrangthai.Focus();
            }
        }

        private void cbTrangthai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtTukhoa.Focus();
                    }
                }
        }

        private void txtTukhoa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtNgaydang.Focus();
            }
        }

        private void dtNgaydang_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtMota.Focus();
            }
        }

        private void txtMabaidang_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtTenbaidang_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbNguoiviet_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbTrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
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
                string sql = $"SELECT * FROM posts WHERE {selectedColumn} LIKE @searchtext";

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
                        dgvPost.DataSource = table;
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

        private void dgvPost_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Bản ghi này đã tồn tại!");
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvPost.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                excelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvPost.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = dgvPost.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgvPost.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvPost.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvPost.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dgvPost.Rows.Count > 0)
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
                            PdfPTable pTable = new PdfPTable(dgvPost.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgvPost.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewrow in dgvPost.Rows)
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
