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
    public partial class New_Service : Form
    {

        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();//docdulieu
        DataTable table = new DataTable();

        public string MaCS;
        public string MaKH;
        public string Noidung;
        public string NgayCS;
        public string MaNV;
        public string KyCS;
        public string Douutien;
        public string Giaiphap;
        public string Trangthai;
        public string Mota;

        public New_Service()
        {
            InitializeComponent();
        }

        private void New_Service_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.staffs' table. You can move, or remove it, as needed.
            this.staffsTableAdapter.Fill(this.dataSet1.staffs);
            txtMaCS.Text = "";
            txtMaKH.Text = "";
            cbMaNV.Text = "";
            cbKyCS.Text = "";
            cbDouutien.Text = "";
            txtGiaiphap.Text = "";
            dtNgayCS.Text = "01/01/2010";
            txtNoidung.Text = "";
            txtTenKH.Text = "";
            txtDiachi.Text = "";
            txtSDT.Text = "";
            cbTrangthai.Text = "";
            txtMota.Text = "";
        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                string maKhachHang = txtMaKH.Text;
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    string query = "SELECT NAME, ADDRESS, PHONE_NUMBER FROM CUSTOMERS WHERE CUSTOMER_ID = @MaKhachHang";
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
                            }
                            else
                            {
                                // Không tìm thấy khách hàng
                                // Xử lý tương ứng (hiển thị thông báo, xóa giá trị ô textbox, vv.)
                                txtTenKH.Text = "";
                                txtDiachi.Text = "";
                                txtSDT.Text = "";
                            }
                        }
                    }
                }
            }

            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        cbTrangthai.Focus();
                    }
                }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(checktextbox())
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();
                    using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM services WHERE service_id = @serviceID", connection))
                    {
                        checkCommand.Parameters.AddWithValue("@serviceID", txtMaCS.Text);
                        int count = (int)checkCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Đã tồn tại mã chăm sóc '" + txtMaCS.Text + "'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return; // Dừng việc thực hiện câu lệnh INSERT
                        }
                    }
                    // Tiếp tục thực hiện câu lệnh INSERT nếu không vi phạm khóa chính
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO services (service_id,customer_id, content, submitted_day, staff_id, period, priority, solution, status,  description) " +
                                                      "VALUES ( @serviceID, @CustomerID, @Content, @submittedDay, @StaffID, @period, @priority, @solution,  @Status, @Description)";

                        // Gán giá trị cho các tham số
                        // ...
                        command.Parameters.AddWithValue("@period", cbKyCS.Text);
                        command.Parameters.AddWithValue("@serviceID", txtMaCS.Text);
                        command.Parameters.AddWithValue("@Status", cbTrangthai.Text);
                        command.Parameters.AddWithValue("@Content", txtNoidung.Text);
                        command.Parameters.AddWithValue("@StaffID", cbMaNV.Text);
                        command.Parameters.AddWithValue("@CustomerID", txtMaKH.Text);
                        command.Parameters.AddWithValue("@submittedDay", DateTime.Parse(dtNgayCS.Text));
                        command.Parameters.AddWithValue("@Description", txtMota.Text);
                        command.Parameters.AddWithValue("@solution", txtGiaiphap.Text);
                        command.Parameters.AddWithValue("@priority", cbDouutien.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã thêm hóa đơn chăm sóc mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private bool checktextbox()
        {
            if (txtMaCS.Text == "")
            {
                errorProvider.SetError(txtMaCS, "Không được để trống dữ liệu!");
                txtMaCS.Focus();
                return false;
            }

            if (cbMaNV.SelectedIndex ==-1)
            {
                errorProvider.SetError(cbMaNV, "Không được để trống dữ liệu!");
                cbMaNV.Focus();
                return false;
            }

            if (cbKyCS.SelectedIndex == -1)
            {
                errorProvider.SetError(cbKyCS, "Không được để trống dữ liệu!");
                cbKyCS.Focus();
                return false;
            }

            if (cbDouutien.SelectedIndex == -1)
            {
                errorProvider.SetError(cbDouutien, "Không được để trống dữ liệu!");
                cbDouutien.Focus();
                return false;
            }

            if (txtGiaiphap.Text == "")
            {
                errorProvider.SetError(txtGiaiphap, "Không được để trống dữ liệu!");
                txtGiaiphap.Focus();
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
                txtMaKH.Focus();
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

        private void txtMaCS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        cbMaNV.Focus();
                    }
                }
        }

        private void cbMaNV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        cbKyCS.Focus();
                    }
                }
        }

        private void cbKyCS_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        cbDouutien.Focus();
                    }
                }
        }

        private void cbDouutien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtGiaiphap.Focus();
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
                        txtNoidung.Focus();
                    }
                }
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtMaCS_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbKyCS_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void cbDouutien_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtGiaiphap_TextChanged(object sender, EventArgs e)
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
