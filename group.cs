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
    public partial class group : Form
    {
        Dictionary<string, string> columnMapping = new Dictionary<string, string>();

        Ketnoi kn = new Ketnoi();
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();


        public group()
        {
            InitializeComponent();
            columnMapping.Add("Mã phân loại", "Group_id");
            columnMapping.Add("Tên phân loại", "name");
        }

        private void group_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.groups' table. You can move, or remove it, as needed.
            this.groupsTableAdapter.Fill(this.dataSet1.groups);
            connection = new SqlConnection(str);
            connection.Open();
            loaddata();
        }

        void loaddata()
        {
            if (connection == null)
            {
                connection = new SqlConnection(str);
                connection.Open();
            }
            command = connection.CreateCommand();
            command.CommandText = "select * from groups";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dgvGroup.DataSource = table;
        }

        private void dgvGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dgvGroup.CurrentRow.Index;
            txtMaPL.Text = dgvGroup.Rows[i].Cells[0].Value.ToString();
            txtTenPL.Text = dgvGroup.Rows[i].Cells[1].Value.ToString();
            txtMota.Text = dgvGroup.Rows[i].Cells[2].Value.ToString();
        }

        private bool checktextbox()
        {
            if (txtMaPL.Text == "")
            {
                errorProvider.SetError(txtMaPL, "Không được để trống dữ liệu!");
                txtMaPL.Focus();
                return false;
            }
            if (txtTenPL.Text == "")
            {
                errorProvider.SetError(txtTenPL, "Không được để trống dữ liệu!");
                txtTenPL.Focus();
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checktextbox())
            {
                command = connection.CreateCommand();
                command.CommandText = "insert into groups values ('" + txtMaPL.Text + "'," +
                    " N'" + txtTenPL.Text + "', N'" + txtMota.Text + "')";
                try
                {
                    command.ExecuteNonQuery();
                    loaddata();
                    MessageBox.Show("Đã thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch 
                {
                    MessageBox.Show("Đã tồn tại mã phân loại này!");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn sửa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "update groups set name = N'" + txtTenPL.Text + "', group_id = '" + txtMaPL.Text + "', description = N'" + txtMota.Text + "'where group_id = '" + txtMaPL.Text + "' ";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Đã sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Bạn muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ret == DialogResult.Yes)
            {
                command = connection.CreateCommand();
                command.CommandText = "delete from groups where group_id = '" + txtMaPL.Text + "'";
                command.ExecuteNonQuery();
                loaddata();
                MessageBox.Show("Đã xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTaomoi_Click(object sender, EventArgs e)
        {
            txtMaPL.Text = "";
            txtTenPL.Text = "";
            txtMota.Text = "";
        }

        private void txtMaPL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtTenPL.Focus();
                    }
                }
        }

        private void txtTenPL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                if (checktextbox())
                {
                    {
                        txtMota.Focus();
                    }
                }
        }

        private void txtMaPL_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtTenPL_TextChanged(object sender, EventArgs e)
        {
            errorProvider.Dispose();
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            string searchtext = txtTimkiem.Text.Trim();
            if (searchtext != "")
            {
                SearchandFilterData(searchtext);
            }
            else
            {
                loaddata();
            }
        }

        private void SearchandFilterData(string searchtext)
        {
            if (cbTimkiem.SelectedItem != null && columnMapping.ContainsKey(cbTimkiem.SelectedItem.ToString()))
            {
                string selectedColumn = columnMapping[cbTimkiem.SelectedItem.ToString()];
                string sql = $"SELECT * FROM groups WHERE {selectedColumn} LIKE @searchtext";

                if (connection != null)
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = sql;
                        command.Parameters.Clear();
                        command.Parameters.AddWithValue("@searchtext", "%" + searchtext + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable table = new DataTable();
                        adapter.Fill(table);
                        dgvGroup.DataSource = table;
                    }
                }
            }
        }

        private void cbTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtTimkiem.Focus();
            }
        }

        private void dgvGroup_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Bản ghi này đã tồn tại!");
        }
    }
}
