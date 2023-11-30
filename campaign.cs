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
    public partial class campaign : Form
    {

        Dictionary<string, string> columnMapping = new Dictionary<string, string>();

        //Ketnoi kn = new Ketnoi();
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public campaign()
        {
            InitializeComponent();
            columnMapping.Add("Mã chiến dịch", "campaign_id");
            columnMapping.Add("Tên chiến dịch", "name");
            columnMapping.Add("Nhóm khách hàng", "group_id");
            columnMapping.Add("Trạng thái", "status");
            columnMapping.Add("Người tạo", "create_staff_id");
            columnMapping.Add("Ngày tạo", "created_day");
        }

        void loaddata()
        {
            if (connection == null)
            {
                connection = new SqlConnection(str);
                connection.Open();
            }
            command = connection.CreateCommand();
            command.CommandText = "select * from campaigns";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvCampaign.DataSource = table;
        }
        private void campaign_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.staffs' table. You can move, or remove it, as needed.
            this.staffsTableAdapter1.Fill(this.dataSet1.staffs);
            // TODO: This line of code loads data into the 'dataSet1.groups' table. You can move, or remove it, as needed.
            this.groupsTableAdapter1.Fill(this.dataSet1.groups);
            //// TODO: This line of code loads data into the 'cRM.groups' table. You can move, or remove it, as needed.
            //this.groupsTableAdapter.Fill(this.cRM.groups);
            //// TODO: This line of code loads data into the 'cRM.staffs' table. You can move, or remove it, as needed.
            //this.staffsTableAdapter.Fill(this.cRM.staffs);
            // TODO: This line of code loads data into the 'cRM.campaigns' table. You can move, or remove it, as needed.
            this.campaignsTableAdapter.Fill(this.cRM.campaigns);
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
            cbNguoitao.SelectedIndex = -1;
            cbNhomKh.SelectedIndex = -1;
        }

        private void dgvCampaign_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvCampaign.CurrentRow.Index;
            txtMachiendich.Text = dgvCampaign.Rows[i].Cells[0].Value.ToString();
            txtTenCD.Text = dgvCampaign.Rows[i].Cells[1].Value.ToString();
            cbTrangthai.Text = dgvCampaign.Rows[i].Cells[2].Value.ToString();
            txtMuctieu.Text = dgvCampaign.Rows[i].Cells[3].Value.ToString();
            cbNguoitao.Text = dgvCampaign.Rows[i].Cells[4].Value.ToString();
            dtNgaybatdau.Text = dgvCampaign.Rows[i].Cells[5].Value.ToString();
            dtNgayketthuc.Text = dgvCampaign.Rows[i].Cells[6].Value.ToString();
            cbNhomKh.Text = dgvCampaign.Rows[i].Cells[7].Value.ToString();
            dtNgaytao.Text = dgvCampaign.Rows[i].Cells[8].Value.ToString();
            dtNgaycapnhat.Text = dgvCampaign.Rows[i].Cells[9].Value.ToString();
            txtMota.Text = dgvCampaign.Rows[i].Cells[10].Value.ToString();
        }

        private bool checktextbox()
        {
            if (txtMachiendich.Text == "")
            {
                errorProvider.SetError(txtMachiendich, "Không được để trống dữ liệu!");
                txtMachiendich.Focus();
                return false;
            }
            if (txtTenCD.Text == "")
            {
                errorProvider.SetError(txtTenCD, "Không được để trống dữ liệu!");
                txtTenCD.Focus();
                return false;
            }

            if (cbNhomKh.SelectedIndex == -1)
            {
                errorProvider.SetError(cbNhomKh, "Không được để trống dữ liệu!");
                cbNhomKh.Focus();
                return false;
            }

            if (cbNguoitao.SelectedIndex == -1)
            {
                errorProvider.SetError(cbNguoitao, "Không được để trống dữ liệu!");
                cbNguoitao.Focus();
                return false;
            }

            if (txtMuctieu.Text == "")
            {
                errorProvider.SetError(txtMuctieu, "Không được để trống dữ liệu!");
                txtMuctieu.Focus();
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
                command.CommandText = "insert into campaigns values ('" + txtMachiendich.Text + "'," +
                    " N'" + txtTenCD.Text + "', N'" + cbTrangthai.Text + "'," +
                    " N'" + txtMuctieu.Text + "', '" + cbNguoitao.Text + "'," +
                    " '" + dtNgaybatdau.Text + "', '" + dtNgayketthuc.Text + "'," +
                    " '" + cbNhomKh.Text + "', '" + dtNgaytao.Text + "'," +
                    " '" + dtNgaycapnhat.Text + "', N'" + txtMota.Text + "')"; 
                try
                {
                    command.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Đã thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Đã tồn tại mã chiến dịch này!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn sửa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "update campaigns set name = N'" + txtTenCD.Text + "', campaign_id = '"+ txtMachiendich.Text+"', status = N'"+cbTrangthai.Text+"', target = N'"+txtMuctieu.Text+"', create_staff_id = '"+cbNguoitao.Text+"', started_day = '"+dtNgaybatdau.Text+"', ended_day = '"+dtNgayketthuc.Text+"', group_id = '"+cbNhomKh.Text+"', created_day = '"+dtNgaytao.Text+"', updated_day = '"+dtNgaycapnhat.Text+"', description = N'"+txtMota.Text+"' where campaign_id = '" + txtMachiendich.Text+"' ";
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
                command.CommandText = "delete from campaigns where campaign_id = '" + txtMachiendich.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaomoi_Click(object sender, EventArgs e)
        {
            txtMachiendich.Text = "";
            txtTenCD.Text = "";
            cbTrangthai.Text = "";
            cbNhomKh.Text = "";
            cbNguoitao.Text = "";
            txtMuctieu.Text = "";
            dtNgaybatdau.Text = "01/01/1900";
            dtNgayketthuc.Text = "01 / 01 / 1900";
            dtNgaytao.Text = "01 / 01 / 1900";
            dtNgaycapnhat.Text = "01 / 01 / 1900";
            txtMota.Text = "";
        }

        private void txtMachiendich_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtTenCD.Focus();
                    }
                }
        }

        private void txtTenCD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        cbNhomKh.Focus();
                    }
                }
        }

        private void cbNguoitao_Click(object sender, EventArgs e)
        {
            if (cbNhomKh.SelectedIndex == -1)
            {
                if (checktextbox())
                { cbNhomKh.Focus(); }
            }
        }

        private void cbNguoitao_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(checktextbox())
                {
                    cbNguoitao.Focus();
                }
            }
        }

        private void txtMuctieu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if(checktextbox())
                {
                    cbTrangthai.Focus();
                }
            }
        }

        private void txtMachiendich_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtTenCD_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbNhomKh_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbNguoitao_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtMuctieu_TextChanged(object sender, EventArgs e)
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
                string sql = $"SELECT * FROM campaigns WHERE {selectedColumn} LIKE @searchtext";

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
                        dgvCampaign.DataSource = table;
                    }
                }
            }
        }

        private void cbTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtTimkiem.Focus();
            }
        }

        private void dgvCampaign_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Bản ghi này đã tồn tại!");
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (dgvCampaign.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                excelApp.Application.Workbooks.Add(Type.Missing);
                for (int i = 1; i < dgvCampaign.Columns.Count + 1; i++)
                {
                    excelApp.Cells[1, i] = dgvCampaign.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < dgvCampaign.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvCampaign.Columns.Count; j++)
                    {
                        excelApp.Cells[i + 2, j + 1] = dgvCampaign.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                excelApp.Columns.AutoFit();
                excelApp.Visible = true;
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (dgvCampaign.Rows.Count > 0)
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
                            PdfPTable pTable = new PdfPTable(dgvCampaign.Columns.Count);
                            pTable.DefaultCell.Padding = 2;
                            pTable.WidthPercentage = 100;
                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in dgvCampaign.Columns)
                            {
                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));
                                pTable.AddCell(pCell);
                            }
                            foreach (DataGridViewRow viewrow in dgvCampaign.Rows)
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
