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
    public partial class Quote_Detail : Form
    {
        SqlConnection connection;//ketnoi
        SqlCommand command;//thuchien
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();//docdulieu
        DataTable table = new DataTable();

        public string maQuote;
        public string ngayBG;
        public string tieude;
        public string noidung;
        public string makhach;
        public string nguoiBG;
        public string ngayhieuluc;
        public string Mota;

        public Quote_Detail()
        {
            InitializeComponent();
        }

        private void Quote_Detail_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'chitietBaoGia.quote_detail' table. You can move, or remove it, as needed.
            this.quote_detailTableAdapter.Fill(this.chitietBaoGia.quote_detail);
            // TODO: This line of code loads data into the 'dataSet1.staffs' table. You can move, or remove it, as needed.
            this.staffsTableAdapter.Fill(this.dataSet1.staffs);
            // TODO: This line of code loads data into the 'dataSet1.leads' table. You can move, or remove it, as needed.
            this.leadsTableAdapter.Fill(this.dataSet1.leads);
            txtMaBG.Text = maQuote;
            txtTieude.Text = tieude;
            cbMaKH.Text = makhach;
            cbNguoiBG.Text = nguoiBG;
            dtNgayBG.Text = ngayBG;
            dtNgayhluc.Text = ngayhieuluc;
            txtMota.Text = Mota;
            txtNoidung.Text = noidung;
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //DialogResult ret = MessageBox.Show("Bạn muốn sửa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (ret == DialogResult.Yes)
            //{
            //    using (connection = new SqlConnection(str))
            //    {
            //        connection.Open();
            //        using (command = connection.CreateCommand())
            //        {
            //            command.CommandText = "update quotes set title = N'" + txtTieude.Text + "'," +
            //                " version = N'" + txtVer.Text + "'," +
            //                " unit = N'" + cbDVT.Text + "'," +
            //                " unit_price = N'" + txtGia.Text + "'," +
            //                " license = N'" + txtGiayphep.Text + "'," +
            //                " feature = N'" + txtDacdiem.Text + "'," +
            //                " status = N'" + cbTrangthai.Text + "'," +
            //                " description = '" + txtMota.Text + "' where product_id = '" + txtMaSP.Text + "' ";

            //            // Gán giá trị ngày tháng vào các tham số


            //            command.ExecuteNonQuery();
            //            MessageBox.Show("Đã sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            this.Close();
            //        }
            //    }
            //}
        }
        void loaddata()
        {
            if (connection == null)
            {
                connection = new SqlConnection(str);
                connection.Open();
            }

            command = connection.CreateCommand();
            command.CommandText = "SELECT quote_id, product_id, quantity " +
                                  "FROM quote_detail WHERE quote_id = @quoteID";

            command.Parameters.AddWithValue("@quoteID", txtMaBG.Text);

            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);

            dgvQuoteDetail.DataSource = table;
        }
    }
}
