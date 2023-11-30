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
using System.Net;
using System.Net.Mail;

namespace Nguyen_CRM
{
    public partial class New_Contract : Form
    {

        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

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


        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public New_Contract()
        {
            InitializeComponent();
        }

        private void New_Contract_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'emailandUser.groups' table. You can move, or remove it, as needed.
            this.groupsTableAdapter.Fill(this.emailandUser.groups);
            // TODO: This line of code loads data into the 'chitietHopDong.contract_detail' table. You can move, or remove it, as needed.
            this.contract_detailTableAdapter.Fill(this.chitietHopDong.contract_detail);

            // TODO: This line of code loads data into the 'dataSet1.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.dataSet1.products);

            this.staffsTableAdapter.Fill(this.dataSet1.staffs);
            // TODO: This line of code loads data into the 'dataSet1.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.dataSet1.customers);
            txtMaHD.Text = "";
            txtTenHD.Text = "";
            txtNoidung.Text = "";
            txtMaKH.Text = "";
            cbMaNV.Text = "";
            dtNgayky.Text = "01/01/2010";
            dtNgayhieuluc.Text = "01/01/2010";
            dtThoihan.Text = "01/01/2010";
            cbTrangthai.Text = "";
            txtMota.Text = "";
            cbNhomKH.Text = "";
            dgvChitietSP.DataSource = null;
            dgvChitietSP.Rows.Clear();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checktextbox())
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Kiểm tra trùng lặp mã khách hàng
                    using (SqlCommand checkCustomerCommand = new SqlCommand("SELECT COUNT(*) FROM customers WHERE customer_id = @customerID", connection))
                    {
                        checkCustomerCommand.Parameters.AddWithValue("@customerID", txtMaKH.Text);
                        int customerCount = (int)checkCustomerCommand.ExecuteScalar();
                        if (customerCount > 0)
                        {
                            // Khách hàng đã tồn tại, không thực hiện việc thêm thông tin khách hàng
                            // Thực hiện câu lệnh INSERT hợp đồng
                            using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM contracts WHERE contract_id = @ContractID", connection))
                            {
                                checkCommand.Parameters.AddWithValue("@ContractID", txtMaHD.Text);
                                int count = (int)checkCommand.ExecuteScalar();
                                if (count > 0)
                                {
                                    MessageBox.Show("Đã tồn tại mã hợp đồng " + txtMaHD.Text + "!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return; // Dừng việc thực hiện câu lệnh INSERT
                                }
                            }

                            using (SqlCommand insertContractCommand = connection.CreateCommand())
                            {
                                insertContractCommand.CommandText = "INSERT INTO contracts (contract_id, title, content, staff_id, customer_id, signed_at, started_day, contract_term, status, description) " +
                                                                    "VALUES (@ContractID, @Title, @Content, @StaffID, @CustomerID, @SignedAt, @StartedDay, @ContractTerm, @Status, @Description)";

                                // Gán giá trị cho các tham số
                                insertContractCommand.Parameters.AddWithValue("@ContractID", txtMaHD.Text);
                                insertContractCommand.Parameters.AddWithValue("@Title", txtTenHD.Text);
                                insertContractCommand.Parameters.AddWithValue("@Content", txtNoidung.Text);
                                insertContractCommand.Parameters.AddWithValue("@StaffID", cbMaNV.Text);
                                insertContractCommand.Parameters.AddWithValue("@CustomerID", txtMaKH.Text);
                                insertContractCommand.Parameters.AddWithValue("@SignedAt", DateTime.Parse(dtNgayky.Text));
                                insertContractCommand.Parameters.AddWithValue("@StartedDay", DateTime.Parse(dtNgayhieuluc.Text));
                                insertContractCommand.Parameters.AddWithValue("@ContractTerm", DateTime.Parse(dtThoihan.Text));
                                insertContractCommand.Parameters.AddWithValue("@Status", cbTrangthai.Text);
                                insertContractCommand.Parameters.AddWithValue("@Description", txtMota.Text);

                                MessageBox.Show("Đã thêm hợp đồng mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                insertContractCommand.ExecuteNonQuery();
                                btnLuuHD.Enabled = false;
                            }

                            // Xử lý thông báo thành công, đóng giao diện, vv.
                            return;
                        }
                    }

                    // Thực hiện câu lệnh INSERT khách hàng
                    using (SqlCommand insertCustomerCommand = connection.CreateCommand())
                    {
                        insertCustomerCommand.CommandText = "INSERT INTO customers (customer_id, group_id, name, email, phone_number, address, description) " +
                                                            "VALUES (@customerID, @groupID, @Name, @Email, @Phone, @address, @description)";

                        // Gán giá trị cho các tham số
                        insertCustomerCommand.Parameters.AddWithValue("@customerID", txtMaKH.Text);
                        insertCustomerCommand.Parameters.AddWithValue("@groupID", cbNhomKH.Text);
                        insertCustomerCommand.Parameters.AddWithValue("@Name", txtTenKH.Text);
                        insertCustomerCommand.Parameters.AddWithValue("@Email", txtEmailKH.Text);
                        insertCustomerCommand.Parameters.AddWithValue("@Phone", txtSDT.Text);
                        insertCustomerCommand.Parameters.AddWithValue("@address", txtDiachiKH.Text);
                        insertCustomerCommand.Parameters.AddWithValue("@description", txtMota.Text);

                        insertCustomerCommand.ExecuteNonQuery();
                    }

                    // Thực hiện câu lệnh INSERT hợp đồng
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM contracts WHERE contract_id = @ContractID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@ContractID", txtMaHD.Text);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Đã tồn tại mã hợp đồng " + txtMaHD.Text + "!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Dừng việc thực hiện câu lệnh INSERT
                        }
                    }

                    // Thực hiện câu lệnh INSERT hợp đồng
                    using (SqlCommand insertContractCommand = connection.CreateCommand())
                    {
                        insertContractCommand.CommandText = "INSERT INTO contracts (contract_id, title, content, staff_id, customer_id, signed_at, started_day, contract_term, status, description) " +
                                                            "VALUES (@ContractID, @Title, @Content, @StaffID, @CustomerID, @SignedAt, @StartedDay, @ContractTerm, @Status, @Description)";

                        // Gán giá trị cho các tham số
                        insertContractCommand.Parameters.AddWithValue("@ContractID", txtMaHD.Text);
                        insertContractCommand.Parameters.AddWithValue("@Title", txtTenHD.Text);
                        insertContractCommand.Parameters.AddWithValue("@Content", txtNoidung.Text);
                        insertContractCommand.Parameters.AddWithValue("@StaffID", cbMaNV.Text);
                        insertContractCommand.Parameters.AddWithValue("@CustomerID", txtMaKH.Text);
                        insertContractCommand.Parameters.AddWithValue("@SignedAt", DateTime.Parse(dtNgayky.Text));
                        insertContractCommand.Parameters.AddWithValue("@StartedDay", DateTime.Parse(dtNgayhieuluc.Text));
                        insertContractCommand.Parameters.AddWithValue("@ContractTerm", DateTime.Parse(dtThoihan.Text));
                        insertContractCommand.Parameters.AddWithValue("@Status", cbTrangthai.Text);
                        insertContractCommand.Parameters.AddWithValue("@Description", txtMota.Text);

                        MessageBox.Show("Đã thêm hợp đồng mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        insertContractCommand.ExecuteNonQuery();
                        btnLuuHD.Enabled = false;
                    }
                }
            }
        }


        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (e.KeyCode == Keys.Enter)
                    if (checktextbox())
                    {
                        {
                            txtTenKH.Focus();
                        }
                    }

                string maKhachHang = txtMaKH.Text;
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    string query = "SELECT NAME, ADDRESS, PHONE_NUMBER, email, group_id FROM CUSTOMERS WHERE CUSTOMER_ID = @MaKhachHang";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTenKH.Text = reader.GetString(0);
                                txtDiachiKH.Text = reader.GetString(1);
                                txtSDT.Text = reader.GetString(2);
                                txtEmailKH.Text = reader.GetString(3);
                                cbNhomKH.Text = reader.GetString(4);
                            }
                            else
                            {
                                // Không tìm thấy khách hàng
                                // Xử lý tương ứng (hiển thị thông báo, xóa giá trị ô textbox, vv.)
                                txtTenKH.Text = "";
                                txtDiachiKH.Text = "";
                                txtSDT.Text = "";
                                txtEmailKH.Text = "";
                                cbNhomKH.Text = "";
                            }
                        }
                    }
                }
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

                    string query = "SELECT NAME, unit_price FROM products WHERE product_ID = @MaSP";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaSP", maSP);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTenSp.Text = reader.GetString(0);

                                if (!reader.IsDBNull(1))
                                {
                                    decimal donGia = Convert.ToDecimal(reader.GetValue(1));
                                    txtDongia.Text = donGia.ToString();
                                }
                                else
                                {
                                    // Xử lý trường hợp giá trị null (nếu cần)
                                    txtDongia.Text = "";
                                }
                            }
                            else
                            {
                                // Không tìm thấy sản phẩm
                                txtTenSp.Text = "";
                                txtDongia.Text = "";
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
            decimal unitPrice = Convert.ToDecimal(txtDongia.Text);
            decimal totalPrice = quantity * unitPrice;

            // Thêm dữ liệu mới vào DataGridView
            dgvChitietSP.Rows.Add(contractID, productID, productName, quantity, unitPrice, totalPrice); 

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
            txtDongia.Text = "";
            txtSoluong.Text = "";

            MessageBox.Show("Đã thêm sản phẩm vào hợp đồng "+ txtMaHD.Text +"");
            txtMaSP.Select();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvChitietSP_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < dgvChitietSP.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvChitietSP.Rows[rowIndex];
                txtMaSP.Text = selectedRow.Cells[1].Value.ToString();
                txtTenSp.Text = selectedRow.Cells[2].Value.ToString();
                txtSoluong.Text = selectedRow.Cells[3].Value.ToString();
                txtDongia.Text = selectedRow.Cells[4].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvChitietSP.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvChitietSP.SelectedRows[0];
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
                dgvChitietSP.Rows.Remove(selectedRow);

                MessageBox.Show("Đã xóa sản phẩm "+ txtTenSp.Text+" khỏi hợp đồng "+ txtMaHD.Text+"");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string mahd = txtMaHD.Text;
            string masp = txtMaSP.Text;
            string tensp = txtTenSp.Text;
            int soluong = Convert.ToInt32(txtSoluong.Text);
            decimal unitPrice = Convert.ToDecimal(txtDongia.Text);
            decimal totalPrice = soluong * unitPrice;

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

            if (dgvChitietSP.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvChitietSP.SelectedRows[0];
                selectedRow.Cells["contractidDataGridViewTextBoxColumn"].Value = mahd;
                selectedRow.Cells["productidDataGridViewTextBoxColumn"].Value = masp;
                selectedRow.Cells["productnameDataGridViewTextBoxColumn"].Value = tensp;
                selectedRow.Cells["quantityDataGridViewTextBoxColumn"].Value = soluong;
                selectedRow.Cells["unit_price"].Value = unitPrice;
                selectedRow.Cells["Total"].Value = totalPrice;
            }
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = cbMaNV.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                string MaNV = selectedRow.Row["staff_id"].ToString(); // Thay "tenNhom" bằng tên cột chứa giá trị nhóm khách hàng
                DisplayUserlist(MaNV);
            }

            errorProvider.Dispose();

        }

        private void DisplayUserlist(string MaNV)
        {
            string procedureName = "UserNhanvien";

            using (SqlConnection connection = new SqlConnection(str))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@MaNV", MaNV);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string emailList = reader["username"].ToString();
                            string pass = reader["password"].ToString();
                            string tennv = reader["name"].ToString();
                            string email = reader["email"].ToString();
                            txtUsername.Text = emailList;
                            txtPassword.Text = pass;
                            txtTenNV.Text = tennv;
                            txtEmailNV.Text = email;
                        }
                        else
                        {
                            txtUsername.Text = "No username found.";
                            txtPassword.Text = "No password found.";
                            txtTenNV.Text = "";
                            txtEmailNV.Text = "";
                        }
                    }
                }
            }
        }

        private void btnGuiEmail_Click(object sender, EventArgs e)
        {
            login = new NetworkCredential(txtUsername.Text, txtPassword.Text);
            client = new SmtpClient(txtSmtp.Text);
            client.Port = Convert.ToInt32(txtPort.Text);
            client.EnableSsl = chkSSL.Checked;
            client.Credentials = login;
            msg = new MailMessage { From = new MailAddress(txtUsername.Text + txtSmtp.Text.Replace("smtp.", "@"), "Phòng Kinh doanh - Công ty Cổ phần TMDV Minh Phong", Encoding.UTF8) };

            if (string.IsNullOrEmpty(txtEmailKH.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email người nhận hoặc CC.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(txtEmailKH.Text))
            {
                string[] toEmailAddresses = txtEmailKH.Text.Split(',');

                foreach (string toEmailAddress in toEmailAddresses)
                {
                    if (!string.IsNullOrWhiteSpace(toEmailAddress))
                    {
                        msg.To.Add(new MailAddress(toEmailAddress.Trim()));
                    }
                }
            }

            // Khai báo biến để tính tổng giá trị
            decimal totalValue = 0;

            // Tên cột mà bạn muốn tính tổng
            string columnName = "Total";

            string tableHtml = "<table>";

            foreach (DataGridViewRow row in dgvChitietSP.Rows)
            {
                if (row.Cells[columnName].Value != null)
                {
                    decimal cellValue;
                    if (decimal.TryParse(row.Cells[columnName].Value.ToString(), out cellValue))
                    {
                        totalValue += cellValue;
                    }
                }
            }

            // Thêm hàng tiêu đề
            tableHtml += "<tr>";
            foreach (DataGridViewColumn column in dgvChitietSP.Columns)
            {
                tableHtml += "<th>" + column.HeaderText + "</th>";
            }
            tableHtml += "</tr>";

            // Thêm dữ liệu từ các hàng
            foreach (DataGridViewRow row in dgvChitietSP.Rows)
            {
                tableHtml += "<tr>";
                foreach (DataGridViewCell cell in row.Cells)
                {
                    tableHtml += "<td>" + (cell.Value?.ToString() ?? "") + "</td>";
                }
                tableHtml += "</tr>";
            }

            tableHtml += "</table>";


            // Thêm thông tin khác từ TextBox
            string additionalInfo = txtNoidung.Text.Replace(Environment.NewLine, "<br/>");

            // Tạo nội dung body của email
            string emailBody = "<html><body>";

            string imagePath = @"https://i.pinimg.com/474x/52/fb/cf/52fbcf980f4e697b2a9b23c4426db5af.jpg";
            string imageTag = "<img src='" + imagePath + "' alt='Hình ảnh'>";
            emailBody += imageTag;

            emailBody += "<h2 style='color: blue; font-style: italic;'>CÔNG TY CỔ PHẦN TMDV MINH PHONG - HÀ NỘI</h2>";
            emailBody += "<p>Văn phòng: BT2-VT19, Đô thị Xa La, Phường Phúc La, Quận Hà Đông, Thành phố Hà Nội </p>";
            emailBody += "<p>Điện thoại: 02432232836</p>";
            emailBody += "<p>Mã số thuế: 0106904968</p>";
            emailBody += "<br/>";
            emailBody += "<h2 style='color: red;'>HỢP ĐỒNG MUA HÀNG</h2>";
            emailBody += "<br/>";
            emailBody += "<p>Ngày ký: " + dtNgayky.Text + "</p>";
            emailBody += "<p>Ngày hiệu lực: " + dtNgayhieuluc.Text + "</p>";
            emailBody += "<p>Ngày hết hiệu lực: " + dtThoihan.Text + "</p>";
            emailBody += "<p>Kính gửi: " + txtTenKH.Text + "</p>";
            emailBody += "<p>Địa chỉ: " + txtDiachiKH.Text + "</p>";
            emailBody += "<p>Số điện thoại: " + txtSDT.Text + "</p>";
            emailBody += "<p>Email: " + txtEmailKH.Text + "</p>";
            emailBody += "<br/>";

            emailBody += "<p>" + additionalInfo + "</p>";
            emailBody += "<br/>";
            emailBody += "<h2>Thông tin chi tiết các sản phẩm trong hợp đồng:</h2>";
            emailBody += tableHtml;
            // Thêm tổng giá trị vào nội dung email
            emailBody += "<p style='font-style: bold;'>Tổng giá trị hợp đồng là : " + totalValue.ToString() + " VND</p>";

            // Thêm các thông tin cố định vào cuối nội dung email
            emailBody += "<br/>";
            emailBody += "<p style='color: red;'>GHI CHÚ:</p>";
            emailBody += "<p>- Giá trên là giá cố định của sản phẩm</p>";
            emailBody += "<p>- Sản phẩm sẽ được giao từ 3-10 ngày tùy theo địa chỉ của quý khách hàng</p>";
            emailBody += "<p>- Hợp đồng này sẽ có giá trị kể từ ngày bắt đầu ký</p>";
            emailBody += "<p>- Hợp đồng này bao gồm 2 bản giấy có chữ ký của hai bên đại diện công ty "+txtTenKH.Text+" và Công ty Cổ Phần TMDV Minh Phong</p>";
            emailBody += "<p>- Rất hân hạnh được hợp tác lâu dài với quý khách hàng</p>";
            emailBody += "<br/>";

            emailBody += "<p style='color: red;'>Thông tin người gửi hợp đồng:<p>";
            emailBody += "<p>Họ và tên: " + txtTenNV.Text + "</p>";
            emailBody += "<p>Email: " + txtEmailNV.Text + "</p>";
            emailBody += "<p>Hà Nội, ngày " + dtNgayky.Text + "</p>";
            emailBody += "<p style='font-style: italic;'> Xin quý khách hàng vui lòng liên hệ trong trường hợp cần thêm thông tin.</p>";

            emailBody += "</body></html>";

            // Gửi email và chèn nội dung body
            msg.Body = emailBody;

            msg.Subject = txtTenHD.Text;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
            string userstate = "Sending...";
            client.SendAsync(msg, userstate);
        }

        private static void SendCompletedCallback(object s, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0} send cancelled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Đã gửi email đến khách hàng thành công!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private bool checktextbox()
        {
            if (txtMaHD.Text == "")
            {
                errorProvider.SetError(txtMaHD, "Không được để trống dữ liệu!");
                txtMaHD.Focus();
                return false;
            }

            if (txtTenHD.Text == "")
            {
                errorProvider.SetError(txtTenHD, "Không được để trống dữ liệu!");
                txtTenHD.Focus();
                return false;
            }

            if (cbMaNV.SelectedIndex == -1)
            {
                errorProvider.SetError(cbMaNV, "Không được để trống dữ liệu!");
                cbMaNV.Focus();
                return false;
            }

            if (txtMaKH.Text == "")
            {
                errorProvider.SetError(txtMaKH, "Không được để trống dữ liệu!");
                txtMaKH.Focus();
                return false;
            }

            if (txtTenKH.Text == "")
            {
                errorProvider.SetError(txtTenKH, "Không được để trống dữ liệu!");
                txtTenKH.Focus();
                return false;
            }

            if (txtDiachiKH.Text == "")
            {
                errorProvider.SetError(txtDiachiKH, "Không được để trống dữ liệu!");
                txtDiachiKH.Focus();
                return false;
            }

            if (cbNhomKH.SelectedIndex == -1)
            {
                errorProvider.SetError(cbNhomKH, "Không được để trống dữ liệu!");
                cbNhomKH.Focus();
                return false;
            }

            if (txtEmailKH.Text == "")
            {
                errorProvider.SetError(txtEmailKH, "Không được để trống dữ liệu!");
                txtEmailKH.Focus();
                return false;
            }

            if (txtSDT.Text == "")
            {
                errorProvider.SetError(txtSDT, "Không được để trống dữ liệu!");
                txtSDT.Focus();
                return false;
            }

            if (cbTrangthai.SelectedIndex == -1)
            {
                errorProvider.SetError(cbTrangthai, "Không được để trống dữ liệu!");
                cbTrangthai.Focus();
                return false;
            }

            if (txtMota.Text == "")
            {
                errorProvider.SetError(txtMota, "Không được để trống dữ liệu!");
                txtMota.Focus();
                return false;
            }

            if (txtNoidung.Text == "")
            {
                errorProvider.SetError(txtNoidung, "Không được để trống dữ liệu!");
                txtNoidung.Focus();
                return false;
            }
            return true;
        }

        private void txtMaHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtTenHD.Focus();
                    }
                }
        }

        private void txtTenHD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        cbMaNV.Select();
                    }
                }
        }

        private void cbMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtMaKH.Focus();
                    }
                }
        }

        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtDiachiKH.Focus();
                    }
                }
        }

        private void txtDiachiKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        cbNhomKH.Focus();
                    }
                }
        }

        private void cbNhomKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtEmailKH.Focus();
                    }
                }
        }

        private void txtEmailKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtSDT.Focus();
                    }
                }
        }

        private void txtSDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        cbTrangthai.Focus();
                    }
                }
        }

        private void cbTrangthai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtMota.Focus();
                    }
                }
        }

        private void txtMota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        dtNgayky.Focus();
                    }
                }
        }

        private void txtMaHD_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtTenHD_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtDiachiKH_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbNhomKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtEmailKH_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbTrangthai_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtMota_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtNoidung_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }
    }
}
