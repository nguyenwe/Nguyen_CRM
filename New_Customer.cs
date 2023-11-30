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
    public partial class New_Customer : Form
    {
        public string MaKH;
        public string NhomKH;
        public string TenKH;
        public string email;
        public string Sdt;
        public string Diachi;
        public string Mota;


        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public New_Customer()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(checktextbox())
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM customers WHERE customer_id = @customerID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@customerID", txtMaKH.Text);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Đã tồn tại mã khách hàng  "+ txtMaKH.Text + " !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Dừng việc thực hiện câu lệnh INSERT
                        }
                    }
                    // Tiếp tục thực hiện câu lệnh INSERT nếu không vi phạm khóa chính
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO customers (customer_id, group_id, name, email, phone_number, address, description) " +
                                                      "VALUES ( @customerID, @groupID,  @Name, @Email, @Phone, @address, @description)";

                        // Gán giá trị cho các tham số
                        // ...
                        command.Parameters.AddWithValue("@Name", txtTenKH.Text);
                        command.Parameters.AddWithValue("@customerID", txtMaKH.Text);
                        command.Parameters.AddWithValue("@groupID", cbNhomKH.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@Phone", txtSDT.Text);
                        command.Parameters.AddWithValue("@address", txtDiachi.Text);
                        command.Parameters.AddWithValue("@Description", txtMota.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm bản ghi mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }

        }

        private void New_Customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.groups' table. You can move, or remove it, as needed.
            this.groupsTableAdapter.Fill(this.dataSet1.groups);
            txtMaKH.Text = "";
            cbNhomKH.Text = "";
            txtTenKH.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtDiachi.Text = "";
            txtMota.Text = "";
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checktextbox()
        {
            if (txtMaKH.Text == "")
            {
                errorProvider.SetError(txtMaKH, "Không được để trống dữ liệu!");
                txtMaKH.Focus();
                return false;
            }
            if (cbNhomKH.SelectedIndex == -1)
            {
                errorProvider.SetError(cbNhomKH, "Không được để trống dữ liệu!");
                cbNhomKH.Focus();
                return false;
            }

            if (txtTenKH.Text == "")
            {
                errorProvider.SetError(txtTenKH, "Không được để trống dữ liệu!");
                txtTenKH.Focus();
                return false;
            }

            if (txtEmail.Text == "")
            {
                errorProvider.SetError(txtEmail, "Không được để trống dữ liệu!");
                txtEmail.Focus();
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

            if (txtMota.Text == "")
            {
                errorProvider.SetError(txtMota, "Không được để trống dữ liệu!");
                txtMota.Focus();
                return false;
            }
            return true;
        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
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
                        txtTenKH.Focus();
                    }
                }
        }

        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtEmail.Focus();
                    }
                }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
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
                        txtDiachi.Focus();
                    }
                }
        }

        private void txtDiachi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtMota.Focus();
                    }
                }
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbNhomKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
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

        private void txtMota_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }
    }
}
