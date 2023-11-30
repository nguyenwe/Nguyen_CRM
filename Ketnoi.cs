using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Nguyen_CRM
{
    class Ketnoi
    {
        public SqlConnection connection;
        public SqlCommand command;
        public DataTable table;
        public SqlDataAdapter adapter;

        public void ketnoi_CSDL()
        {
            string ketnoi = @"Data Source=LAPTOP-JUURU7V4\SQLEXPRESS;Initial Catalog=CRM_system;Integrated Security=True";
            connection = new SqlConnection(ketnoi);
            connection.Open();
        }

        public void huyketnoi()
        {
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        public DataTable Lay_DL(string sql)
        {
            ketnoi_CSDL();
            adapter = new SqlDataAdapter(sql, connection);
            table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public void Execute(string sql)
        {
            ketnoi_CSDL();
            command = new SqlCommand(sql,connection);
            command.ExecuteNonQuery();
            huyketnoi();
        }
    }
}
