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
    public partial class New_Email : Form
    {
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();//docdulieu
        DataTable table = new DataTable();

        public string MaEmail;
        public string Tieude;
        public string Noidung;
        public string Ngaygui;
        public string Nguoigui;
        public string NhomKh;

        public New_Email()
        {
            InitializeComponent();
        }

        private void New_Email_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'emailandUser.groups' table. You can move, or remove it, as needed.
            this.groupsTableAdapter.Fill(this.emailandUser.groups);
            // TODO: This line of code loads data into the 'emailandUser.staffs' table. You can move, or remove it, as needed.
            this.staffsTableAdapter.Fill(this.emailandUser.staffs);
            txtMaEmail.Text = "";
            txtSubject.Text = "";
            txtMessage.Text = "";
            cbNguoigui.Text = "";
            dtNgaygui.Text = "01/01/2010";
            cbNhomKH.Text = "";
            txtTo.Text = "";
            txtCC.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checktextbox())
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM Emails WHERE email_id = @emailID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@emailID", txtMaEmail.Text);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Đã tồn tại mã Email '" + txtMaEmail.Text + "'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Dừng việc thực hiện câu lệnh INSERT
                        }
                    }
                    // Tiếp tục thực hiện câu lệnh INSERT nếu không vi phạm khóa chính
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO emails (email_id, title, content, despatch, staff_id, group_id) " +
                                                      "VALUES ( @emailID, @title, @Content, @despatch, @StaffID, @groupID)";

                        // Gán giá trị cho các tham số
                        // ...

                        string value = txtMessage.Text.Replace(Environment.NewLine, "<br />");

                        command.Parameters.AddWithValue("@emailID", txtMaEmail.Text);
                        command.Parameters.AddWithValue("@title", txtSubject.Text);
                        command.Parameters.AddWithValue("@Content", value);
                        command.Parameters.AddWithValue("@StaffID", cbNguoigui.Text);
                        command.Parameters.AddWithValue("@groupID", cbNhomKH.Text);
                        command.Parameters.AddWithValue("@despatch", DateTime.Parse(dtNgaygui.Text));

                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm Email mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Close();
                    }

                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandText = "chitietEmail";
                        command.ExecuteNonQuery();
                        //MessageBox.Show("Đã thêm Email mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }      
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbNhomKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = cbNhomKH.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                string nhom = selectedRow.Row["group_id"].ToString(); // Thay "tenNhom" bằng tên cột chứa giá trị nhóm khách hàng
                DisplayEmailList(nhom);                
            }

            errorProvider.Dispose();
        }

        private void DisplayEmailList(string nhom)
        {
            string procedureName = "EmailKhachHang";

            using (SqlConnection connection = new SqlConnection(str))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@nhom", nhom);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string emailList = reader["DSEmail"].ToString();
                            string tenKH = reader["TenKH"].ToString();
                            txtCC.Text = emailList;
                            txtTennhomKH.Text = tenKH;
                        }
                        else
                        {
                            txtCC.Text = "No email found.";
                            txtCC.Text = "";
                        }
                    }
                }
            }
        }

        private void cbNguoigui_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedRow = cbNguoigui.SelectedItem as DataRowView;
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

        private void btnSend_Click(object sender, EventArgs e)
        {
            // luu ma email va ma khach hang



            //
            login = new NetworkCredential(txtUsername.Text, txtPassword.Text);
            client = new SmtpClient(txtSmtp.Text);
            client.Port = Convert.ToInt32(txtPort.Text);
            client.EnableSsl = chkSSL.Checked;
            client.Credentials = login;
            msg = new MailMessage { From = new MailAddress(txtUsername.Text + txtSmtp.Text.Replace("smtp.", "@"), "Bộ phận Marketing - Công ty Cổ phần TMDV Minh Phong", Encoding.UTF8) };

            if (string.IsNullOrEmpty(txtTo.Text) && string.IsNullOrEmpty(txtCC.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email người nhận hoặc CC.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!string.IsNullOrEmpty(txtTo.Text))
            {
                string[] toEmailAddresses = txtTo.Text.Split(',');

                foreach (string toEmailAddress in toEmailAddresses)
                {
                    if (!string.IsNullOrWhiteSpace(toEmailAddress))
                    {
                        msg.To.Add(new MailAddress(toEmailAddress.Trim()));
                    }
                }
            }

            if (!string.IsNullOrEmpty(txtCC.Text))
            {
                string[] ccEmailAddresses = txtCC.Text.Split(',');

                foreach (string ccEmailAddress in ccEmailAddresses)
                {
                    if (!string.IsNullOrWhiteSpace(ccEmailAddress))
                    {
                        msg.Bcc.Add(new MailAddress(ccEmailAddress.Trim()));
                    }
                }
            }

            string additionalInfo = txtMessage.Text.Replace(Environment.NewLine, "<br/>");

            // Tạo nội dung body của email
            string emailBody = "<html><body>";

            string imagePath = @"https://i.pinimg.com/474x/52/fb/cf/52fbcf980f4e697b2a9b23c4426db5af.jpg";
            string imageTag = "<img src='" + imagePath + "' alt='Hình ảnh'>";
            emailBody += imageTag;

            emailBody += "<h2 style='color: blue; font-style: italic;'>CÔNG TY CỔ PHẦN TMDV MINH PHONG - HÀ NỘI</h2>";
            emailBody += "<p>Văn phòng: BT2-VT19, Đô thị Xa La, Phường Phúc La, Quận Hà Đông, Thành phố Hà Nội </p>";
            emailBody += "<p>Điện thoại: 02432232836</p>";
            emailBody += "<p>Mã số thuế: 0106904968</p>";
            emailBody += "<p>Kính gửi: "+txtTennhomKH.Text+"</p>";
            emailBody += "<br/>";

            emailBody += "<p>" + additionalInfo + "</p>";
            emailBody += "<p>Trân trọng!</p>";
            emailBody += "<br/>";
            // Thêm các thông tin cố định vào cuối nội dung email

            emailBody += "<p style='color: red;'>Thông tin người liên hệ:<p>";
            emailBody += "<p>Họ và tên: " + txtTenNV.Text + "</p>";
            emailBody += "<p>Email: " + txtEmailNV.Text + "</p>";
            emailBody += "<p>Hà Nội, ngày " + dtNgaygui.Text + "</p>";
            emailBody += "<p style='font-style: italic;'> Xin quý khách hàng vui lòng liên hệ lại qua email của công ty trong trường hợp cần thêm thông tin.</p>";
            emailBody += "</body></html>";

            // Gửi email và chèn nội dung body
            msg.Body = emailBody;

            msg.Subject = txtSubject.Text;
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
            if (txtMaEmail.Text == "")
            {
                errorProvider.SetError(txtMaEmail, "Không được để trống dữ liệu!");
                txtMaEmail.Focus();
                return false;
            }

            //if (txtTo.Text == "")
            //{
            //    errorProvider.SetError(txtTo, "Không được để trống dữ liệu!");
            //    txtTo.Focus();
            //    return false;
            //}

            if (txtCC.Text == "")
            {
                errorProvider.SetError(txtCC, "Không được để trống dữ liệu!");
                txtCC.Focus();
                return false;
            }

            if (txtSubject.Text == "")
            {
                errorProvider.SetError(txtSubject, "Không được để trống dữ liệu!");
                txtSubject.Focus();
                return false;
            }

            if (txtMessage.Text == "")
            {
                errorProvider.SetError(txtMessage, "Không được để trống dữ liệu!");
                txtMessage.Focus();
                return false;
            }

            if (cbNhomKH.SelectedIndex == -1)
            {
                errorProvider.SetError(cbNhomKH, "Không được để trống dữ liệu!");
                cbNhomKH.Focus();
                return false;
            }

            if (cbNguoigui.SelectedIndex == -1)
            {
                errorProvider.SetError(cbNguoigui, "Không được để trống dữ liệu!");
                cbNguoigui.Focus();
                return false;
            }
            return true;
        }

        private void txtMaEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtTo.Focus();
                    }
                }
        }

        //private void txtTo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        if (checktextbox())
        //        {
        //            {
        //                txtCC.Focus();
        //            }
        //        }
        //}

        private void txtCC_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtSubject.Focus();
                    }
                }
        }

        private void txtSubject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtMessage.Focus();
                    }
                }
        }

        //private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //        if (checktextbox())
        //        {
        //            {
        //                dtNgaygui.Focus();
        //            }
        //        }
        //}

        private void cbNhomKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        cbNguoigui.Focus();
                    }
                }
        }

        private void cbNguoigui_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        chkSSL.Focus();
                    }
                }
        }

        private void txtMaEmail_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        //private void txtTo_TextChanged(object sender, EventArgs e)
        //{
        //    errorProvider.Dispose();
        //}

        private void txtCC_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtSubject_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void chkSSL_CheckedChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }
    }
}
