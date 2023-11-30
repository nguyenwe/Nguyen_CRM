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

namespace Nguyen_CRM
{
    public partial class Contract_Detail : Form
    {
        

        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public Contract_Detail()
        {
            InitializeComponent();
        }

        public string MaHD;
        public string TenHD;
        public string Noidung;
        public string MaKH;
        public string MaNV;
        public string Ngayky;
        public string Ngayhieuluc;
        public string Thoihan;
        public string Trangthai;
        public string Mota;

        private void Contract_Detail_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'chitietHopDong.contract_detail' table. You can move, or remove it, as needed.
            this.contract_detailTableAdapter.Fill(this.chitietHopDong.contract_detail);
            // TODO: This line of code loads data into the 'dataSet1.staffs' table. You can move, or remove it, as needed.
            this.staffsTableAdapter.Fill(this.dataSet1.staffs);
            // TODO: This line of code loads data into the 'dataSet1.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.dataSet1.customers);
            txtMaHD.Text = MaHD;
            txtTenHD.Text = TenHD;
            txtNoidung.Text = Noidung;
            cbMaKH.Text = MaKH;
            cbMaNV.Text = MaNV;
            dtNgayky.Text = Ngayky;
            dtNgayhieuluc.Text = Ngayhieuluc;
            dtThoihan.Text = Thoihan;
            cbTrangthai.Text = Trangthai;
            txtMota.Text = Mota;
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
            command.CommandText = "SELECT contract_id, product_id, product_name, quantity " +
                                  "FROM contract_detail WHERE contract_id = @contractID";

            command.Parameters.AddWithValue("@contractID", txtMaHD.Text);

            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            dgvchitietHD.DataSource = table;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn sửa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                using (connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (command = connection.CreateCommand())
                    {
                        command.CommandText = "update contracts set title = N'" + txtTenHD.Text + "'," +
                            " contract_id = '" + txtMaHD.Text + "'," +
                            " status = N'" + cbTrangthai.Text + "'," +
                            " content = N'" + txtNoidung.Text + "'," +
                            " staff_id = '" + cbMaNV.Text + "'," +
                            " customer_id = '" + cbMaKH.Text + "'," +
                            " signed_at = @SignedAt," +
                            " started_day = @StartedDay," +
                            " contract_term = @ContractTerm," +
                            " description = '" + txtMota.Text + "' where contract_id = '" + txtMaHD.Text + "' ";

                        // Gán giá trị ngày tháng vào các tham số
                        command.Parameters.AddWithValue("@SignedAt", DateTime.Parse(dtNgayky.Text));
                        command.Parameters.AddWithValue("@StartedDay", DateTime.Parse(dtNgayhieuluc.Text));
                        command.Parameters.AddWithValue("@ContractTerm", DateTime.Parse(dtThoihan.Text));

                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã sửa!");
                        this.Close();
                    }
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < dgvchitietHD.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvchitietHD.Rows[rowIndex];

                // Kiểm tra giá trị null trước khi truy cập vào các ô dữ liệu
                if (selectedRow.Cells[1].Value != null)
                    txtMaSP.Text = selectedRow.Cells[1].Value.ToString();
                else
                    txtMaSP.Text = string.Empty;

                if (selectedRow.Cells[2].Value != null)
                    txtTenSp.Text = selectedRow.Cells[2].Value.ToString();
                else
                    txtTenSp.Text = string.Empty;

                if (selectedRow.Cells[3].Value != null)
                    txtSoluong.Text = selectedRow.Cells[3].Value.ToString();
                else
                    txtSoluong.Text = string.Empty;
            }
        }

        private void txtMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                string maSP = txtMaSP.Text;
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    string query = "SELECT NAME FROM products WHERE product_ID = @MaSP";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaSP", maSP);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTenSp.Text = reader.GetString(0);
                            }
                            else
                            {
                                // Không tìm thấy sản phẩm
                                txtTenSp.Text = "";
                            }
                        }
                    }
                }
                txtSoluong.Select();
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            string contractID = txtMaHD.Text;
            string productID = txtMaSP.Text;
            string productName = txtTenSp.Text;
            int quantity = Convert.ToInt32(txtSoluong.Text);

            // Thêm dữ liệu mới vào DataTable
            DataRow newRow = table.NewRow();
            newRow["contract_id"] = contractID;
            newRow["product_id"] = productID;
            newRow["product_name"] = productName;
            newRow["quantity"] = quantity;
            table.Rows.Add(newRow);

            // Thực hiện câu truy vấn INSERT để thêm dữ liệu vào CSDL
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();
                string query = "INSERT INTO contract_detail (contract_id, Product_ID, Product_Name, Quantity) " +
                               "VALUES (@contractID, @ProductID, @ProductName, @Quantity)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@contractID", contractID);
                command.Parameters.AddWithValue("@ProductID", productID);
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@Quantity", quantity);

                command.ExecuteNonQuery();
            }

            // Xóa nội dung trong các TextBox sau khi thêm dữ liệu
            txtMaSP.Text = "";
            txtTenSp.Text = "";
            txtSoluong.Text = "";

            MessageBox.Show("Đã thêm sản phẩm vào hợp đồng '" + txtMaHD.Text + "'");
            txtMaSP.Select();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvchitietHD.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvchitietHD.SelectedRows[0];
                string mahd = selectedRow.Cells["contractidDataGridViewTextBoxColumn"].Value.ToString();
                string masp = selectedRow.Cells["productidDataGridViewTextBoxColumn"].Value.ToString();

                // Thực hiện câu truy vấn DELETE để xóa bản ghi khỏi CSDL
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    string query = "DELETE FROM contract_detail WHERE contract_id = @mahd AND product_id = @masp";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@mahd", mahd);
                    command.Parameters.AddWithValue("@masp", masp);

                    command.ExecuteNonQuery();
                }

                // Xóa dòng khỏi DataGridView
                dgvchitietHD.Rows.Remove(selectedRow);

                MessageBox.Show("Đã xóa sản phẩm '" + txtTenSp.Text + "' khỏi hợp đồng '" + txtMaHD.Text + "'");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa.");
            }
        }

        private void btnSuaSP_Click(object sender, EventArgs e)
        {
            string mahd = txtMaHD.Text;
            string masp = txtMaSP.Text;
            string tensp = txtTenSp.Text;
            int soluong = Convert.ToInt32(txtSoluong.Text);

            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();
                string query = "UPDATE contract_detail SET contract_id = @contractid, product_id = @masp, product_name = @tensp, " +
                    " quantity = @soluong " +
                    "WHERE contract_id = @contractid and product_id = @masp";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@masp", masp);
                command.Parameters.AddWithValue("@tensp", tensp);
                command.Parameters.AddWithValue("@soluong", soluong);
                command.Parameters.AddWithValue("@contractid", mahd); // Sửa đổi tham số WHERE

                command.ExecuteNonQuery();
            }

            if (dgvchitietHD.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvchitietHD.SelectedRows[0];
                selectedRow.Cells["contractidDataGridViewTextBoxColumn"].Value = mahd;
                selectedRow.Cells["productidDataGridViewTextBoxColumn"].Value = masp;
                selectedRow.Cells["productnameDataGridViewTextBoxColumn"].Value = tensp;
                selectedRow.Cells["quantityDataGridViewTextBoxColumn"].Value = soluong;
            }
        }
    }
  
}
