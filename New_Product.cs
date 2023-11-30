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
    public partial class New_Product : Form
    {
        //SqlConnection connection;
        //SqlCommand command;
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public string MaSP;
        public string TenSP;
        public string Phienban;
        public string Dongia;
        public string DVT;
        public string Giayphep;
        public string Dacdiem;
        public string Trangthai;
        public string Mota;

        private void New_Product_Load(object sender, EventArgs e)
        {
            txtMaSP.Text = "";
            txtTen.Text = "";
            txtVer.Text = "";
            txtGia.Text = "";
            cbDVT.Text = "";
            txtGiayphep.Text = "";
            txtDacdiem.Text = "";
            cbTrangthai.Text = "";
            txtMota.Text = "";
        }

        public New_Product()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checktextbox())
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM products WHERE product_id = @ProductID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@ProductID", txtMaSP.Text);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Đã tồn tại mã SP '" + txtMaSP.Text + "'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Dừng việc thực hiện câu lệnh INSERT
                        }
                    }
                    // Tiếp tục thực hiện câu lệnh INSERT nếu không vi phạm khóa chính
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO products (product_id, name, version, unit, unit_price, license, feature, status, description) " +
                                                      "VALUES ( @ProductID, @name,  @version, @unit, @unit_price, @license, @feature, @Status, @Description)";

                        // Gán giá trị cho các tham số
                        // ...
                        command.Parameters.AddWithValue("@ProductID", txtMaSP.Text);
                        command.Parameters.AddWithValue("@name", txtTen.Text);
                        command.Parameters.AddWithValue("@version", txtVer.Text);
                        command.Parameters.AddWithValue("@unit", cbDVT.Text);
                        command.Parameters.AddWithValue("@unit_price", txtGia.Text);
                        command.Parameters.AddWithValue("@license", txtGiayphep.Text);
                        command.Parameters.AddWithValue("@feature", txtDacdiem.Text);
                        command.Parameters.AddWithValue("@Status", cbTrangthai.Text);
                        command.Parameters.AddWithValue("@Description", txtMota.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm bản ghi mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool checktextbox()
        {
            if (txtMaSP.Text == "")
            {
                errorProvider.SetError(txtMaSP, "Không được để trống dữ liệu!");
                txtMaSP.Focus();
                return false;
            }

            if (txtTen.Text == "")
            {
                errorProvider.SetError(txtTen, "Không được để trống dữ liệu!");
                txtTen.Focus();
                return false;
            }

            if (txtVer.Text == "")
            {
                errorProvider.SetError(txtVer, "Không được để trống dữ liệu!");
                txtVer.Focus();
                return false;
            }

            if (txtGia.Text == "")
            {
                errorProvider.SetError(txtGia, "Không được để trống dữ liệu!");
                txtGia.Focus();
                return false;
            }

            if (txtGiayphep.Text == "")
            {
                errorProvider.SetError(txtGiayphep, "Không được để trống dữ liệu!");
                txtGiayphep.Focus();
                return false;
            }

            if (cbDVT.SelectedIndex == -1)
            {
                errorProvider.SetError(cbDVT, "Không được để trống dữ liệu!");
                cbDVT.Focus();
                return false;
            }

            if (txtDacdiem.Text == "")
            {
                errorProvider.SetError(txtDacdiem, "Không được để trống dữ liệu!");
                txtDacdiem.Focus();
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
            return true;
        }

        private void txtMaSP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtTen.Focus();
                    }
                }
        }

        private void txtTen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtVer.Focus();
                    }
                }
        }

        private void txtVer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtGia.Focus();
                    }
                }
        }

        private void txtGia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtGiayphep.Focus();
                    }
                }
        }

        private void txtGiayphep_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        cbDVT.Focus();
                    }
                }
        }

        private void cbDVT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtDacdiem.Focus();
                    }
                }
        }

        private void txtDacdiem_KeyDown(object sender, KeyEventArgs e)
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

        private void txtMaSP_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtVer_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtGiayphep_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbDVT_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtDacdiem_TextChanged(object sender, EventArgs e)
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
    }
}
