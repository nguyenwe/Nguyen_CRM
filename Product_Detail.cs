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
    public partial class Product_Detail : Form
    {
        SqlConnection connection;
        SqlCommand command;
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

        public Product_Detail()
        {
            InitializeComponent();
        }

        private void Product_Detail_Load(object sender, EventArgs e)
        {
            txtMaSP.Text = MaSP;
            txtTen.Text = TenSP;
            txtVer.Text = Phienban;
            txtGia.Text = Dongia;
            cbDVT.Text = DVT;
            txtDacdiem.Text = Dacdiem;
            cbTrangthai.Text = Trangthai;
            txtMota.Text = Mota;
            txtGiayphep.Text = Giayphep;

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
                        command.CommandText = "update products set name = N'" + txtTen.Text + "'," +
                            " version = N'" + txtVer.Text + "'," +
                            " unit = N'" + cbDVT.Text + "'," +
                            " unit_price = N'" + txtGia.Text + "'," +
                            " license = N'" + txtGiayphep.Text + "'," +
                            " feature = N'" + txtDacdiem.Text + "'," +
                            " status = N'" + cbTrangthai.Text + "'," +
                            " description = '" + txtMota.Text + "' where product_id = '" + txtMaSP.Text + "' ";

                        // Gán giá trị ngày tháng vào các tham số
                   

                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }
    }
}
