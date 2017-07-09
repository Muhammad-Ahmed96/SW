using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SW.DAL
{
    internal class DBHelper : IDisposable
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        SqlConnection con = null;

        public DBHelper()
        {
            con = new SqlConnection(connString);
            con.Open();
        }

        public int ExecuteQuery(string query)
        {
            SqlCommand command = new SqlCommand(query, con);
            var count = command.ExecuteNonQuery();
            return count;
        }

        public Object ExecuteScalar(string query)
        {
            SqlCommand command = new SqlCommand(query, con);
            return command.ExecuteScalar();
        }

        public SqlDataReader ExecuteReader(string query)
        {
            SqlCommand command = new SqlCommand(query, con);
            return command.ExecuteReader();
        }


        public void Dispose()
        {
            if (con != null & con.State == System.Data.ConnectionState.Open)
                con.Close();
        }
    }
}
