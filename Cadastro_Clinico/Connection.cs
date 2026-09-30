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

        private readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Projeto2;Integrated Security=True;Encrypt=True";


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
