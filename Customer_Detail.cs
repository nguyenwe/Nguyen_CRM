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
    public partial class Detail_Customer : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();



        public Detail_Customer()
        {
            InitializeComponent();
        }

        public string MaKH;
        public string NhomKH;
        public string TenKH;
        public string email;
        public string Sdt;
        public string Diachi;
        public string Mota;

        private void Detail_Customer_Load(object sender, EventArgs e)
        {
            txtMaKH.Text = MaKH;
            txtManhom.Text = NhomKH;
            txtTenKH.Text = TenKH;
            txtEmail.Text = email;
            txtSDT.Text = Sdt;
            txtDiachi.Text = Diachi;
            txtMota.Text = Mota;
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
                        command.CommandText = "update customers set name = N'" + txtTenKH.Text + "'," +
                            " customer_id = '" + txtMaKH.Text + "'," +
                            " group_id = N'" + txtManhom.Text + "'," +
                            " email = N'" + txtEmail.Text + "'," +
                            " phone_number = '" + txtSDT.Text + "'," +
                            " address = N'" + txtDiachi.Text + "'," +
                            " description = N'" + txtMota.Text + "' where customer_id = '" + txtMaKH.Text + "' ";

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
