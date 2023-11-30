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
    public partial class Service_Detail : Form
    {

        SqlConnection connection;//ketnoi
        SqlCommand command;//thuchien
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

        public Service_Detail()
        {
            InitializeComponent();
        }

        private void Service_Detail_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.staffs' table. You can move, or remove it, as needed.
            this.staffsTableAdapter.Fill(this.dataSet1.staffs);
            txtMaCS.Text = MaCS;
            txtMaKH.Text = MaKH;
            cbMaNV.Text = MaNV;
            cbKyCS.Text = KyCS;
            cbDouutien.Text = Douutien;
            txtGiaiphap.Text = Giaiphap;
            dtNgayCS.Text = NgayCS;
            txtNoidung.Text = Noidung;
            cbTrangthai.Text = Trangthai;
            txtMota.Text = Mota;
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
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

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        command.CommandText = "update services set solution = N'" + txtGiaiphap.Text + "'," +
                            " period = '" + cbKyCS.Text + "'," +
                            " status = N'" + cbTrangthai.Text + "'," +
                            " content = N'" + txtNoidung.Text + "'," +
                            " staff_id = '" + cbMaNV.Text + "'," +
                            " customer_id = '" + txtMaKH.Text + "'," +
                            " submitted_day = @submitted_day," +
                            " priority = '"+ cbDouutien.Text+"'," +
                            " description = '" + txtMota.Text + "' where service_id = '" + txtMaCS.Text + "' ";

                        // Gán giá trị ngày tháng vào các tham số
                        command.Parameters.AddWithValue("@submitted_day", DateTime.Parse(dtNgayCS.Text));


                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã sửa!");
                        this.Close();
                    }
                }
            }
        }
    }
}
