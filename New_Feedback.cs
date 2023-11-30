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
    public partial class New_Feedback : Form
    {

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

        public New_Feedback()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void New_Feedback_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.products' table. You can move, or remove it, as needed.
            this.productsTableAdapter.Fill(this.dataSet1.products);
            // TODO: This line of code loads data into the 'dataSet1.customers' table. You can move, or remove it, as needed.
            this.customersTableAdapter.Fill(this.dataSet1.customers);
            // TODO: This line of code loads data into the 'dataSet1.staffs' table. You can move, or remove it, as needed.
            this.staffsTableAdapter.Fill(this.dataSet1.staffs);
            txtMaFeedB.Text = "";
            txtTieude.Text = "";
            txtNoidung.Text = "";
            txtGiaiphap.Text = "";
            cbMaKH.Text = "";
            cbMaNV.Text = "";
            cbMaSP.Text = "";
            cbDouutien.Text = "";
            cbTrangthai.Text = "";
            cbDanhgia.Text = "";
            dtNgayGQ.Text = "01-01-2010";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                connection.Open();
                using (SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM feedbacks WHERE feedback_id = @feedbackID", connection))
                {
                    checkCommand.Parameters.AddWithValue("@feedbackID", txtMaFeedB.Text);
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Đã tồn tại mã khiếu nại/yêu cầu '" + txtMaFeedB.Text + "'!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Dừng việc thực hiện câu lệnh INSERT
                    }
                }
                // Tiếp tục thực hiện câu lệnh INSERT nếu không vi phạm khóa chính
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO feedbacks (feedback_id, title, content, submitted_day, product_id, customer_id, staff_id, priority, status, solution,rate) " +
                                                  "VALUES ( @feedbackID, @title, @Content, @submittedDay, @productID, @CustomerID, @StaffID, @priority, @Status, @solution,  @rate)";

                    // Gán giá trị cho các tham số
                    // ...
                    command.Parameters.AddWithValue("@title", txtTieude.Text);
                    command.Parameters.AddWithValue("@feedbackID", txtMaFeedB.Text);
                    command.Parameters.AddWithValue("@Status", cbTrangthai.Text);
                    command.Parameters.AddWithValue("@Content", txtNoidung.Text);
                    command.Parameters.AddWithValue("@StaffID", cbMaNV.Text);
                    command.Parameters.AddWithValue("@CustomerID", cbMaKH.Text);
                    command.Parameters.AddWithValue("@productID", cbMaSP.Text);
                    command.Parameters.AddWithValue("@submittedDay", DateTime.Parse(dtNgayGQ.Text));
                    command.Parameters.AddWithValue("@rate", cbDanhgia.Text);
                    command.Parameters.AddWithValue("@solution", txtGiaiphap.Text);
                    command.Parameters.AddWithValue("@priority", cbDouutien.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm khiếu nại/yêu cầu mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
    }
}
