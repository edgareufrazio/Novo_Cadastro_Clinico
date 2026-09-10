using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastro_Clinico
{
    internal class Connection
    {
        private readonly string connectionString = @"";

        public SqlConnection Conectar()
        {
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open();

            return conn;
        }

        public void Desconectar(SqlConnection conn)
        {
            if (conn != null && conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
