using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Nguyen_CRM
{
    public partial class Report : Form
    {
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        public Report()
        {
            InitializeComponent();
        }

        private void btnBaocaoKQLV_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                using (SqlCommand command = new SqlCommand("Ketqualamviec", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@NgayBD", dtNgayBD.Text);
                    command.Parameters.AddWithValue("@NgayKT", dtNgayKT.Text);
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BaoCaoKetqualamviec baocao = new BaoCaoKetqualamviec();
                    baocao.SetDataSource(table);
                    InBaoCao f = new InBaoCao();
                    f.crystalReportViewer.ReportSource = baocao;
                    f.ShowDialog();
                }
            }
        }

        private void btnBaocaoDT_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                using (SqlCommand command = new SqlCommand("BaocaoDoanhthu", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@NgayBD", dtNgayBD.Text);
                    command.Parameters.AddWithValue("@NgayKT", dtNgayKT.Text);
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BaocaoDoanhthu baocao = new BaocaoDoanhthu();
                    baocao.SetDataSource(table);
                    InBaoCao f = new InBaoCao();
                    f.crystalReportViewer.ReportSource = baocao;
                    f.ShowDialog();
                }
            }
        }

        private void btnBaocaoCSKH_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                using (SqlCommand command = new SqlCommand("BaoCaoCSKH", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@NgayBD", dtNgayBD.Text);
                    command.Parameters.AddWithValue("@NgayKT", dtNgayKT.Text);
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BaoCaoCSKH baocao = new BaoCaoCSKH();
                    baocao.SetDataSource(table);
                    InBaoCao f = new InBaoCao();
                    f.crystalReportViewer.ReportSource = baocao;
                    f.ShowDialog();
                }
            }
        }

        private void btnBaocaoKD_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                using (SqlCommand command = new SqlCommand("BaoCaoKinhDoanh", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@NgayBD", dtNgayBD.Text);
                    command.Parameters.AddWithValue("@NgayKT", dtNgayKT.Text);
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BaoCaoKinhdoanh baocao = new BaoCaoKinhdoanh();
                    baocao.SetDataSource(table);
                    InBaoCao f = new InBaoCao();
                    f.crystalReportViewer.ReportSource = baocao;
                    f.ShowDialog();
                }
            }
        }

        private void btnBaocaoMar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(str))
            {
                using (SqlCommand command = new SqlCommand("BaoCaoMarketing", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@NgayBD", dtNgayBD.Text);
                    command.Parameters.AddWithValue("@NgayKT", dtNgayKT.Text);
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    BaoCaoMarketing baocao = new BaoCaoMarketing();
                    baocao.SetDataSource(table);
                    InBaoCao f = new InBaoCao();
                    f.crystalReportViewer.ReportSource = baocao;
                    f.ShowDialog();
                }
            }
        }
    }
}
