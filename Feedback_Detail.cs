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
    public partial class Feedback_Detail : Form
    {
        SqlConnection connection;//ketnoi
        SqlCommand command;//thuchien
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();//docdulieu
        DataTable table = new DataTable();

        public string MaFeedback;
        public string Tieude;
        public string Noidung;
        public string NgayGQ;
        public string MaSP;
        public string MaKH;
        public string MaNV;
        public string Douutien;
        public string Trangthai;
        public string Giaiphap;
        public string Danhgia;

        public Feedback_Detail()
        {
            InitializeComponent();
        }

        private void Feedback_Detail_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.dataSet1.customers);
            // TODO: This line of code loads data into the 'dataSet1.staffs' table. You can move, or remove it, as needed.
            this.staffsTableAdapter.Fill(this.dataSet1.staffs);
            // TODO: This line of code loads data into the 'dataSet1.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.dataSet1.products);
            txtMaFeedB.Text = MaFeedback;
            txtTieude.Text = Tieude;
            txtNoidung.Text = Noidung;
            txtGiaiphap.Text = Giaiphap;
            cbMaKH.Text = MaKH;
            cbMaNV.Text = MaNV;
            cbMaSP.Text = MaSP;
            cbDouutien.Text = Douutien;
            cbTrangthai.Text = Trangthai;
            cbDanhgia.Text = Danhgia;
            dtNgayGQ.Text = NgayGQ;
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
                        command.CommandText = "update feedbacks set title = N'" + txtTieude.Text + "'," +
                            " product_id = '" + cbMaSP.Text + "'," +
                            " status = N'" + cbTrangthai.Text + "'," +
                            " content = N'" + txtNoidung.Text + "'," +
                            " staff_id = '" + cbMaNV.Text + "'," +
                            " customer_id = '" + cbMaKH.Text + "'," +
                            " submitted_day = @submitted_day," +
                            " priority = '" + cbDouutien.Text + "'," +
                            " solution = N'"+ txtGiaiphap.Text+"'," +
                            " rate = '" + cbDanhgia.Text + "' where feedback_id = '" + txtMaFeedB.Text + "' ";

                        // Gán giá trị ngày tháng vào các tham số
                        command.Parameters.AddWithValue("@submitted_day", DateTime.Parse(dtNgayGQ.Text));

                        command.ExecuteNonQuery();
                        MessageBox.Show("Đã sửa!");
                        this.Close();
                    }
                }
            }
        }
    }
}
