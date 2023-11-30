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
using ExcelDataReader;
using Z.Dapper.Plus;
using Dapper;

namespace Nguyen_CRM
{
    public partial class lead : Form
    {
        Dictionary<string, string> columnMapping = new Dictionary<string, string>();

       // Ketnoi kn = new Ketnoi();
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        public lead()
        {
            InitializeComponent();
            columnMapping.Add("Mã khách hàng", "lead_id");
            columnMapping.Add("Tên khách hàng", "name");
            columnMapping.Add("Nhóm khách hàng", "group_id");
            columnMapping.Add("Trạng thái", "status");
            columnMapping.Add("Ngành", "sector");
            columnMapping.Add("Quy mô kinh doanh", "scale");
            columnMapping.Add("Nguồn", "source");
            columnMapping.Add("Mức độ ưu tiên", "priority");

        }

        void loaddata()
        {
            if (connection == null)
            {
                connection = new SqlConnection(str);
                connection.Open();
            }
            command = connection.CreateCommand();
            command.CommandText = "select * from leads";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvLead.DataSource = table;
        }

        private void lead_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.leads' table. You can move, or remove it, as needed.
            this.leadsTableAdapter1.Fill(this.dataSet1.leads);
            // TODO: This line of code loads data into the 'dataSet1.platforms' table. You can move, or remove it, as needed.
            this.platformsTableAdapter.Fill(this.dataSet1.platforms);
            // TODO: This line of code loads data into the 'cRM1.leads' table. You can move, or remove it, as needed.
            this.leadsTableAdapter.Fill(this.cRM1.leads);
            // TODO: This line of code loads data into the 'cRM.leads' table. You can move, or remove it, as needed.
            this.leadsTableAdapter.Fill(this.cRM.leads);
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
            cbNguon.SelectedIndex = -1;
        }

        private void dgvLead_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvLead.CurrentRow.Index;
            txtMakhachTN.Text = dgvLead.Rows[i].Cells[0].Value.ToString();
            txtTenkhachTN.Text = dgvLead.Rows[i].Cells[1].Value.ToString();
            txtNhomkhachTN.Text = dgvLead.Rows[i].Cells[2].Value.ToString();
            txtDiachiEmail.Text = dgvLead.Rows[i].Cells[3].Value.ToString();
            txtDiachi.Text = dgvLead.Rows[i].Cells[4].Value.ToString();
            txtSDT.Text = dgvLead.Rows[i].Cells[5].Value.ToString();
            txtNoidungyeucau.Text = dgvLead.Rows[i].Cells[6].Value.ToString();
            txtNguoilienhe.Text = dgvLead.Rows[i].Cells[7].Value.ToString();
            cbTrangthai.Text = dgvLead.Rows[i].Cells[8].Value.ToString();
            cbMucdouutien.Text = dgvLead.Rows[i].Cells[9].Value.ToString();
            cbNganh.Text = dgvLead.Rows[i].Cells[10].Value.ToString();
            cbQuymo.Text = dgvLead.Rows[i].Cells[11].Value.ToString();
            cbNguon.Text = dgvLead.Rows[i].Cells[12].Value.ToString();
        }

        private bool checktextbox()
        {
            if (txtMakhachTN.Text == "")
            {
                    errorProvider.SetError(txtMakhachTN, "Không được để trống dữ liệu!");
                    txtMakhachTN.Focus();
                    return false;
            }
            if (txtTenkhachTN.Text == "")
            {
                errorProvider.SetError(txtTenkhachTN, "Không được để trống dữ liệu!");
                txtTenkhachTN.Focus();
                return false;
            }
            if(txtNhomkhachTN.Text == "")
            {
                errorProvider.SetError(txtNhomkhachTN, "Không được để trống dữ liệu!");
                txtNhomkhachTN.Focus();
                return false;
            }
            if(txtDiachiEmail.Text == "")
            {
                errorProvider.SetError(txtDiachiEmail, "Không được để trống dữ liệu!");
                txtDiachiEmail.Focus();
                return false;
            }
            if (txtNguoilienhe.Text == "")
            {
                errorProvider.SetError(txtNguoilienhe, "Không được để trống dữ liệu!");
                txtNguoilienhe.Focus();
                return false;
            }
            if (txtSDT.Text == "")
            {
                errorProvider.SetError(txtSDT, "Không được để trống dữ liệu!");
                txtSDT.Focus();
                return false;
            }
            if (txtDiachi.Text == "")
            {
                errorProvider.SetError(txtDiachi, "Không được để trống dữ liệu!");
                txtDiachi.Focus();
                return false;
            }
            if (cbTrangthai.SelectedIndex == -1)
            {
                errorProvider.SetError(cbTrangthai, "Không được để trống dữ liệu!");
                cbTrangthai.Focus();
                return false;
            }
            if (cbMucdouutien.SelectedIndex == -1)
            {
                errorProvider.SetError(cbMucdouutien, "Không được để trống dữ liệu!");
                cbMucdouutien.Focus();
                return false;
            }
            if (cbNganh.SelectedIndex == -1)
            {
                errorProvider.SetError(cbNganh, "Không được để trống dữ liệu!");
                cbNganh.Focus();
                return false;
            }
            if (cbQuymo.SelectedIndex == -1)
            {
                errorProvider.SetError(cbQuymo, "Không được để trống dữ liệu!");
                cbQuymo.Focus();
                return false;
            }
            if (cbNguon.SelectedIndex == -1)
            {
                errorProvider.SetError(cbNguon, "Không được để trống dữ liệu!");
                cbNguon.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if(checktextbox())
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into leads values ('" + txtMakhachTN.Text + "', N'" + txtTenkhachTN.Text + "', '" + txtNhomkhachTN.Text + "', '" + txtDiachiEmail.Text + "', N'" + txtDiachi.Text + "', '" + txtSDT.Text + "', N'" + txtNoidungyeucau.Text + "', '" + txtNguoilienhe.Text + "', N'" + cbTrangthai.Text + "', '" + cbMucdouutien.Text + "', N'" + cbNganh.Text + "', N'" + cbQuymo.Text + "', '" + cbNguon.Text + "')";

                try
                {
                    command.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Đã thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Đã tồn tại mã khách hàng tiềm năng này!");
                }
            }

        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn sửa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "update leads set name = N'" + txtTenkhachTN.Text + "', group_id = '" + txtNhomkhachTN.Text + "', email = '" + txtDiachiEmail.Text + "', address=N'" + txtDiachi.Text + "', phone_number = '" + txtSDT.Text + "', request_detail = N'" + txtNoidungyeucau.Text + "', contact_id = '" + txtNguoilienhe.Text + "', status = N'" + cbTrangthai.Text + "', priority = '" + cbMucdouutien.Text + "', sector = N'" + cbNganh
                    .Text + "', scale = N'" + cbQuymo.Text + "', source = '" + cbNguon.Text + "' where lead_id = '" + txtMakhachTN.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Đã sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ret == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from leads where lead_id = '" + txtMakhachTN.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnTaomoi_Click_1(object sender, EventArgs e)
        {
            txtMakhachTN.Text = "";
            txtTenkhachTN.Text = "";
            txtNhomkhachTN.Text = "";
            txtDiachiEmail.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
            txtNoidungyeucau.Text = "";
            txtNguoilienhe.Text = "";
            cbTrangthai.Text = "";
            cbMucdouutien.Text = "";
            cbNganh.Text = "";
            cbQuymo.Text = "";
            cbNguon.Text = "";
        }

        private void txtMakhachTN_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                if(checktextbox())
                {
                    {
                        txtTenkhachTN.Focus();
                    }
                }

        }

        private void txtTenkhachTN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(checktextbox())
                {
                    txtNhomkhachTN.Focus();
                }
            }
        }

        private void txtNhomkhachTN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checktextbox())
                {
                    txtDiachiEmail.Focus();
                }
            }
        }

        private void txtDiachiEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checktextbox())
                { txtNguoilienhe.Focus(); }
            }
        }

        private void txtNguoilienhe_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checktextbox())
                { txtSDT.Focus(); }
            }
        }

        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checktextbox())
                { txtDiachi.Focus(); }
            }
        }

        private void txtDiachi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checktextbox())
                { cbTrangthai.Focus(); }
            }
        }

        private void cbMucdouutien_Click(object sender, EventArgs e)
        {
            if (cbTrangthai.SelectedIndex == -1)
            {
                if (checktextbox())
                { cbTrangthai.Focus(); }
            }
        }

        private void cbNganh_Click(object sender, EventArgs e)
        {
            if (cbMucdouutien.SelectedIndex == -1)
            {
                if (checktextbox())
                { cbMucdouutien.Focus(); }
            }
        }

        private void cbQuymo_Click(object sender, EventArgs e)
        {
            if (cbNganh.SelectedIndex == -1)
            {
                if (checktextbox())
                { cbNganh.Focus(); }
            }
        }

        private void cbNguon_Click(object sender, EventArgs e)
        {
            if (cbQuymo.SelectedIndex == -1)
            {
                if (checktextbox())
                { cbQuymo.Focus(); }
            }
        }


        private void cbNguon_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (cbNguon.SelectedIndex == -1)
                {
                    if (checktextbox()) { cbNguon.Focus(); }
                }
                else
                {
                    txtNoidungyeucau.Focus();
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

        private void txtMakhachTN_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtTenkhachTN_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtNhomkhachTN_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtDiachiEmail_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtNguoilienhe_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtDiachi_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbTrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbMucdouutien_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbQuymo_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbNguon_SelectedIndexChanged(object sender, EventArgs e)
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
                string sql = $"SELECT * FROM leads WHERE {selectedColumn} LIKE @searchtext";

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
                        dgvLead.DataSource = table;
                    }
                }
            }
        }

        DataTableCollection tableCollection;

        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            //dgvLead.DataSource = dt;
            if (dt != null)
            {
                List<ImportLead> leads = new List<ImportLead>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ImportLead lead = new ImportLead();
                    lead.lead_id = dt.Rows[i]["lead_id"].ToString();
                    lead.name = dt.Rows[i]["name"].ToString();
                    lead.group_id = dt.Rows[i]["group_id"].ToString();
                    lead.email = dt.Rows[i]["email"].ToString();
                    lead.address = dt.Rows[i]["address"].ToString();
                    lead.phone_number = dt.Rows[i]["phone_number"].ToString();
                    lead.request_detail = dt.Rows[i]["request_detail"].ToString();
                    lead.contact_id = dt.Rows[i]["contact_id"].ToString();
                    lead.status = dt.Rows[i]["status"].ToString();
                    lead.priority = dt.Rows[i]["priority"].ToString();
                    lead.sector = dt.Rows[i]["sector"].ToString();
                    lead.scale = dt.Rows[i]["scale"].ToString();
                    lead.source = dt.Rows[i]["source"].ToString();
                    leads.Add(lead);
                }
                dgvLead.DataSource = leads;
            }
        }



        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel 97-2003 Workbook|*.xls|Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cboSheet.Items.Add(table.TableName);
                        }
                    }
                }
            }

            labelSheet.Visible = true;
            cboSheet.Visible = true;
            btnImport.Visible = true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
                DapperPlusManager.Entity<ImportLead>().Table("leads");
                List<ImportLead> user = dgvLead.DataSource as List<ImportLead>;
                if (user != null)
                {
                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        db.BulkInsert(user);
                    }

                    using (IDbConnection db = new SqlConnection(connectionString))
                    {
                        string selectQuery = "SELECT * FROM leads";
                        var newData = db.Query<ImportLead>(selectQuery);
                        dgvLead.DataSource = newData.ToList();
                    }
                }
                labelSheet.Visible = false;
                cboSheet.Visible = false;
                btnImport.Visible = false;

                MessageBox.Show("Đã thêm dữ liệu mới !");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
