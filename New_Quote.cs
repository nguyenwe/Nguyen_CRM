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
    public partial class New_Quote : Form
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public string maQuote;
        public string ngayBG;
        public string tieude;
        public string noidung;
        public string makhach;
        public string nguoiBG;
        public string ngayhieuluc;
        public string Mota;

        public New_Quote()
        {
            InitializeComponent();
        }

        private void New_Quote_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'chitietBaoGia.staffs' table. You can move, or remove it, as needed.
            this.staffsTableAdapter.Fill(this.chitietBaoGia.staffs);
            // TODO: This line of code loads data into the 'chitietBaoGia.quote_detail' table. You can move, or remove it, as needed.
            this.quote_detailTableAdapter.Fill(this.chitietBaoGia.quote_detail);
            txtMaBG.Text = "";
            txtTieude.Text = "";
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtEmail.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
            cbNguoiBG.Text = "";
            dtNgayBG.Text = "01/01/2010";
            dtNgayhluc.Text = "01/01/2010";
            txtMota.Text = "";
            txtNoidung.Text = "";
            dgvSP_BG.DataSource = null;
            dgvSP_BG.Rows.Clear();
        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                string maKhachHang = txtMaKH.Text;
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    string query = "SELECT NAME, ADDRESS, PHONE_NUMBER, email FROM leadS WHERE lead_ID = @MaKhachHang";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtTenKH.Text = reader.GetString(0);
                                txtDiachi.Text = reader.GetString(1);
                                txtSDT.Text = reader.GetString(2);
                                txtEmail.Text = reader.GetString(3);
                            }
                            else
                            {
                                // Không tìm thấy khách hàng
                                // Xử lý tương ứng (hiển thị thông báo, xóa giá trị ô textbox, vv.)
                                txtTenKH.Text = "";
                                txtDiachi.Text = "";
                                txtSDT.Text = "";
                                txtEmail.Text = "";
                            }
                        }
                    }

                    txtNoidung.Select();
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

                    string query = "SELECT name, unit_price FROM products WHERE product_ID = @MaSP";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MaSP", maSP);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {

                                if (!reader.IsDBNull(0))
                                {
                                    decimal donGia = Convert.ToDecimal(reader.GetValue(1));
                                    txtTenSP.Text = reader.GetString(0);
                                    txtDongia.Text = donGia.ToString();
                                }
                                else
                                {
                                    // Xử lý trường hợp giá trị null (nếu cần)
                                    txtTenSP.Text = "";
                                    txtDongia.Text = "";
                                }
                            }
                            else
                            {
                                // Không tìm thấy sản phẩm
                                txtTenSP.Text = "";
                                txtDongia.Text = "";
                            }
                        }
                    }
                }
                txtSoluong.Select();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuuBG_Click(object sender, EventArgs e)
        {
            if (checktextbox())
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM quotes WHERE quote_id = @QuoteID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@QuoteID", txtMaBG.Text);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Đã tồn tại mã báo giá " + txtMaBG.Text + "!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Dừng việc thực hiện câu lệnh INSERT
                        }
                    }
                    // Tiếp tục thực hiện câu lệnh INSERT nếu không vi phạm khóa chính
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO quotes (quote_id, quote_day, title, content, lead_id, contact_id, started_day, description) " +
                                                      "VALUES ( @QuoteID, @quote_day, @title,  @Content, @leadID, @contactID, @StartedDay, @Description)";

                        // Gán giá trị cho các tham số
                        // ...
                        command.Parameters.AddWithValue("@Title", txtTieude.Text);
                        command.Parameters.AddWithValue("@QuoteID", txtMaBG.Text);
                        command.Parameters.AddWithValue("@Content", txtNoidung.Text);
                        command.Parameters.AddWithValue("@contactID", cbNguoiBG.Text);
                        command.Parameters.AddWithValue("@leadID", txtMaKH.Text);
                        command.Parameters.AddWithValue("@quote_day", DateTime.Parse(dtNgayBG.Text));
                        command.Parameters.AddWithValue("@StartedDay", DateTime.Parse(dtNgayhluc.Text));
                        command.Parameters.AddWithValue("@Description", txtMota.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm báo giá mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                    }
                }
            }
                
        }

        private void btnThemSp_Click(object sender, EventArgs e)
        {
            string quoteID = txtMaBG.Text;
            string productID = txtMaSP.Text;
            int quantity = Convert.ToInt32(txtSoluong.Text);
            decimal unitPrice = Convert.ToDecimal(txtDongia.Text);
            decimal totalPrice = quantity * unitPrice;
            string name = txtTenSP.Text;

            // Thêm dữ liệu mới vào DataGridView
            dgvSP_BG.Rows.Add(quoteID, productID, name, quantity, unitPrice, totalPrice);

            // Thực hiện câu truy vấn INSERT để thêm dữ liệu vào CSDL
            using (SqlConnection connection = new SqlConnection(str))
            {
            
                    connection.Open();
                    string query = "INSERT INTO quote_detail (quote_id, Product_ID, Quantity) " +
                                   "VALUES (@quoteID, @ProductID, @Quantity)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@quoteID", quoteID);
                    command.Parameters.AddWithValue("@ProductID", productID);
                    command.Parameters.AddWithValue("@Quantity", quantity);

                    command.ExecuteNonQuery();
            
            }

            // Xóa nội dung trong các TextBox sau khi thêm dữ liệu
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtDongia.Text = "";
            txtSoluong.Text = "";

            MessageBox.Show("Đã thêm sản phẩm vào hợp đồng '" + txtMaBG.Text + "'");
            txtMaSP.Select();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string quoteID = txtMaBG.Text;
            string productID = txtMaSP.Text;
            int quantity = Convert.ToInt32(txtSoluong.Text);
            decimal unitPrice = Convert.ToDecimal(txtDongia.Text);
            decimal totalPrice = quantity * unitPrice;

            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();
                string query = "UPDATE quote_detail SET quote_id = @quoteID, product_id = @masp, " +
                    " quantity = @soluong " +
                    "WHERE quote_id = @quoteID and product_id = @masp";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@masp", productID);
                command.Parameters.AddWithValue("@quoteID", quoteID);
                command.Parameters.AddWithValue("@soluong", quantity);

                command.ExecuteNonQuery();
            }

            if (dgvSP_BG.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSP_BG.SelectedRows[0];
                selectedRow.Cells["quoteidDataGridViewTextBoxColumn"].Value = quoteID;
                selectedRow.Cells["productidDataGridViewTextBoxColumn"].Value = productID;
                selectedRow.Cells["quantityDataGridViewTextBoxColumn"].Value = quantity;
                selectedRow.Cells["unit_price"].Value = unitPrice;
                selectedRow.Cells["total"].Value = totalPrice;
            }
        }

        private void dgvSP_BG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex >= 0 && rowIndex < dgvSP_BG.Rows.Count)
            {
                DataGridViewRow selectedRow = dgvSP_BG.Rows[rowIndex];
                txtMaSP.Text = selectedRow.Cells[1].Value.ToString();
                txtTenSP.Text = selectedRow.Cells[2].Value.ToString();
                txtSoluong.Text = selectedRow.Cells[3].Value.ToString();
                txtDongia.Text = selectedRow.Cells[4].Value.ToString();
            }
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (dgvSP_BG.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvSP_BG.SelectedRows[0];
                string quoteID = selectedRow.Cells["quoteidDataGridViewTextBoxColumn"].Value.ToString();
                string productID = selectedRow.Cells["productidDataGridViewTextBoxColumn"].Value.ToString();

                // Thực hiện câu truy vấn DELETE để xóa bản ghi khỏi CSDL
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    string query = "DELETE FROM quote_detail WHERE quote_id = @mabg AND product_id = @masp";
                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@mabg", quoteID);
                    command.Parameters.AddWithValue("@masp", productID);

                    command.ExecuteNonQuery();
                }

                // Xóa dòng khỏi DataGridView
                dgvSP_BG.Rows.Remove(selectedRow);

                MessageBox.Show("Đã xóa sản phẩm '" + txtMaSP.Text + "' khỏi báo giá '" + txtMaBG.Text + "'");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bản ghi để xóa.");
            }
        }

        private void cbNguoiBG_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = cbNguoiBG.SelectedItem as DataRowView;
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

        private void btnGuiBG_Click(object sender, EventArgs e)
        {
            login = new NetworkCredential(txtUsername.Text, txtPassword.Text);
            client = new SmtpClient(txtSmtp.Text);
            client.Port = Convert.ToInt32(txtPort.Text);
            client.EnableSsl = chkSSL.Checked;
            client.Credentials = login;
            msg = new MailMessage { From = new MailAddress(txtUsername.Text + txtSmtp.Text.Replace("smtp.", "@"), "Phòng Kinh doanh - Công ty Cổ phần TMDV Minh Phong", Encoding.UTF8) };

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email người nhận.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                string[] toEmailAddresses = txtEmail.Text.Split(',');

                foreach (string toEmailAddress in toEmailAddresses)
                {
                    if (!string.IsNullOrWhiteSpace(toEmailAddress))
                    {
                        msg.To.Add(new MailAddress(toEmailAddress.Trim()));
                    }
                }
            }

            decimal totalValue = 0;

            // Tên cột mà bạn muốn tính tổng
            string columnName = "total";


            foreach (DataGridViewRow row in dgvSP_BG.Rows)
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

            string tableHtml = "<table>";

            // Thêm hàng tiêu đề
            tableHtml += "<tr>";
            foreach (DataGridViewColumn column in dgvSP_BG.Columns)
            {
                tableHtml += "<th>" + column.HeaderText + "</th>";
            }
            tableHtml += "</tr>";

            // Thêm dữ liệu từ các hàng
            foreach (DataGridViewRow row in dgvSP_BG.Rows)
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
            emailBody += "<h2 style='color: red;'>BẢNG BÁO GIÁ</h2>";
            emailBody += "<br/>";
            emailBody += "<p>Ngày báo giá: "+dtNgayBG.Text+"</p>";
            emailBody += "<p>Ngày hết hiệu lực: "+dtNgayhluc.Text+"</p>";
            emailBody += "<p>Kính gửi quý khách hàng: " +txtTenKH.Text +"</p>";
            emailBody += "<p>Địa chỉ: " +txtDiachi.Text +"</p>";
            emailBody += "<p>Số điện thoại: " + txtSDT.Text + "</p>";
            emailBody += "<p>Email: " + txtEmail.Text + "</p>";
            emailBody += "<br/>";

            emailBody += "<p>" + additionalInfo + "</p>";
            emailBody += "<br/>";
            emailBody += "<h2>Thông tin chi tiết các sản phẩm báo giá:</h2>";
            emailBody += tableHtml;
            // Thêm tổng giá trị vào nội dung email
            emailBody += "<p style='font-style: bold;'>Tổng giá trị báo giá là : " + totalValue.ToString() + " VND</p>";

            // Thêm các thông tin cố định vào cuối nội dung email
            emailBody += "<br/>";
            emailBody += "<p style='color: red;'>GHI CHÚ:</p>";
            emailBody += "<p>- Giá trên là giá ban đầu của sản phẩm</p>";
            emailBody += "<p>- Giá sẽ có sự thay đổi tùy theo thỏa thuận giữa quý khách hàng và Minh Phong</p>";
            emailBody += "<p>- Sản phẩm sẽ được giao từ 3-10 ngày tùy theo địa chỉ của quý khách hàng</p>";
            emailBody += "<p>- Bảng báo giá sẽ hết giá trị sau ngày hết hiệu lực, 15 ngày kể từ ngày quý khách nhận được báo giá </p>";
            emailBody += "<br/>";

            emailBody += "<p style='color: red;'>Thông tin người báo giá:<p>";
            emailBody += "<p>Họ và tên: "+ txtTenNV.Text+ "</p>";
            emailBody += "<p>Email: "+txtEmailNV.Text+"</p>";
            emailBody += "<p>Hà Nội, ngày "+dtNgayBG.Text+"</p>";
            emailBody += "<p style='font-style: italic;'> Xin quý khách hàng vui lòng liên hệ trong trường hợp cần thêm thông tin.</p>";
            emailBody += "</body></html>";

            // Gửi email và chèn nội dung body
            msg.Body = emailBody;

            msg.Subject = txtTieude.Text;
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
            if (txtMaBG.Text == "")
            {
                errorProvider.SetError(txtMaBG, "Không được để trống dữ liệu!");
                txtMaBG.Focus();
                return false;
            }

            if (txtTieude.Text == "")
            {
                errorProvider.SetError(txtTieude, "Không được để trống dữ liệu!");
                txtTieude.Focus();
                return false;
            }

            if (cbNguoiBG.SelectedIndex == -1)
            {
                errorProvider.SetError(cbNguoiBG, "Không được để trống dữ liệu!");
                cbNguoiBG.Focus();
                return false;
            }

            if (txtNoidung.Text == "")
            {
                errorProvider.SetError(txtNoidung, "Không được để trống dữ liệu!");
                txtNoidung.Focus();
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
                errorProvider.SetError(txtMaKH, "Không được để trống dữ liệu!");
                txtMaKH.Focus();
                return false;
            }

            if (txtMota.Text == "")
            {
                errorProvider.SetError(txtMota, "Không được để trống dữ liệu!");
                txtMota.Focus();
                return false;
            }
            return true;
        }

        private void txtMaBG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtTieude.Focus();
                    }
                }
        }

        private void txtTieude_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        cbNguoiBG.Focus();
                    }
                }
        }

        private void cbNguoiBG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtNoidung.Focus();
                    }
                }
        }

        private void txtMaBG_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtTieude_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtNoidung_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtMota_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }
    }
}
