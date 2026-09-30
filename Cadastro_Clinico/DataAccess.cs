using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Cadastro_Clinico
{
    internal static class DataAccess
    {
        public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            var connObj = new Connection();
            using (var conn = connObj.Conectar())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            var connObj = new Connection();
            using (var conn = connObj.Conectar())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                return cmd.ExecuteScalar();
            }
        }

        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            var connObj = new Connection();
            using (var conn = connObj.Conectar())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                return cmd.ExecuteNonQuery();
            }
        }

        public static async Task<DataTable> ExecuteDataTableAsync(string sql, params SqlParameter[] parameters)
        {
            var dt = new DataTable();
            var connObj = new Connection();
            using (var conn = connObj.Conectar())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    dt.Load(reader);
                }
            }

            return dt;
        }

        public static async Task<object> ExecuteScalarAsync(string sql, params SqlParameter[] parameters)
        {
            var connObj = new Connection();
            using (var conn = connObj.Conectar())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                return await cmd.ExecuteScalarAsync();
            }
        }

        public static async Task<int> ExecuteNonQueryAsync(string sql, params SqlParameter[] parameters)
        {
            var connObj = new Connection();
            using (var conn = connObj.Conectar())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0)
                    cmd.Parameters.AddRange(parameters);

                return await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}
