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
    public partial class Login : Form
    {
        private int loginAttempts = 0; // Biến đếm số lần đăng nhập sai
        private DateTime lockoutEndTime; // Thời gian kết thúc khóa tạm thời
        private bool isLockedOut = false; // Trạng thái khóa tạm thời


        public Login()
        {
            InitializeComponent();
        }

        private void btnQuenMK_Click(object sender, EventArgs e)
        {
            ForgetPass f = new ForgetPass();
            f.ShowDialog();
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            Register f = new Register();
            f.Show();
            //this.Hide();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (isLockedOut && DateTime.Now < lockoutEndTime)
            {
                // Người dùng bị khóa tạm thời
                TimeSpan remainingTime = lockoutEndTime - DateTime.Now;
                string remainingSeconds = remainingTime.Seconds.ToString();
                MessageBox.Show($"Tài khoản của bạn đã bị khóa tạm thời. Vui lòng thử lại sau {remainingSeconds} giây!");
                return;
            }

            string connectionString = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True"; // Chuỗi kết nối cơ sở dữ liệu SQL
            string username = txtTaikhoan.Text; // Lấy giá trị username từ TextBox
            string password = txtMatkhau.Text; // Lấy giá trị password từ TextBox

            // Tạo đối tượng SqlConnection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối
                connection.Open();

                // Tạo câu truy vấn SQL
                string query = "SELECT * FROM Users WHERE Username = @username AND Password = @password";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm các tham số vào câu truy vấn
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    // Thực thi câu truy vấn và lấy dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(txtTaikhoan.Text.Trim() == "") { MessageBox.Show("Không được để trống tài khoản!"); return; }
                        if(txtMatkhau.Text.Trim() == "") { MessageBox.Show("Không được để trống mật khẩu!"); return; }
                        if (reader.Read())
                        {
                            // Đăng nhập thành công
                            MessageBox.Show("Đăng nhập thành công!");
                            loginAttempts = 0; // Đặt lại số lần đăng nhập sai

                            Dashboard f = new Dashboard();
                            f.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Đăng nhập không thành công
                            loginAttempts++;

                            if (loginAttempts >= 3)
                            {
                                // Khóa tạm thời người dùng
                                isLockedOut = true;
                                lockoutEndTime = DateTime.Now.AddSeconds(30); // Đặt thời gian kết thúc khóa tạm thời
                                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu! Tài khoản của bạn đã bị khóa tạm thời.");
                                loginAttempts = 0;
                            }
                            else
                            {
                                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
                            }
                        }
                    }
                }
            }

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
