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
    public partial class ForgetPass : Form
    {
        public ForgetPass()
        {
            InitializeComponent();
           
        }

        private void ForgetPass_Load(object sender, EventArgs e)
        {
            txtKetqua.Text = "";
        }

        private void btnLaylaiMK_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True"; // Chuỗi kết nối cơ sở dữ liệu SQL
            string username = txtTenDN.Text; // Lấy giá trị username từ TextBox

            // Tạo đối tượng SqlConnection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối
                connection.Open();

                // Tạo câu truy vấn SQL
                string query = "SELECT password FROM users WHERE Username = @username";

                // Tạo đối tượng SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số vào câu truy vấn
                    command.Parameters.AddWithValue("@username", username);

                    // Thực thi câu truy vấn và lấy dữ liệu
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(txtTenDN.Text.Trim() == "") { txtKetqua.Text = "Vui lòng điền tên đăng nhập!"; return; }
                        if (reader.Read())
                        {
                            // Tìm thấy mật khẩu tương ứng với tài khoản
                            string password = reader.GetString(0);
                            txtKetqua.Text = password;
                        }
                        else
                        {
                            // Không tìm thấy mật khẩu tương ứng với tài khoản
                            txtKetqua.Text = "Không tìm thấy mật khẩu tương ứng";
                        }
                    }
                }
            }
        }
    }
}
