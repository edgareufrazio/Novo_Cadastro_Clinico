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
<<<<<<< Updated upstream
        private readonly string connectionString = @"";
=======
        private readonly string connectionString = @"Data Source=VPR0684793W11-1\SQLEXPRESS;Initial Catalog=Projeto;Persist Security Info=True;User ID=sa;Password=123456;Encrypt=True";
>>>>>>> Stashed changes

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
