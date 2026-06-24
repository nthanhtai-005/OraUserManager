using System.Data;
using Oracle.ManagedDataAccess.Client;
using DAL.Providers;

namespace DAL.Repositories
{
    public class DbExecutor
    {
        private readonly DbConnectionManager _connManager;
        public DbExecutor() { _connManager = new DbConnectionManager(); }

        // SỬ DỤNG PARAMETER ĐỂ CHỐNG SQL INJECTION
        public DataTable ExecuteQuery(string sql, OracleParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (var conn = _connManager.GetConnection())
            {
                conn.Open();
                using (var cmd = new OracleCommand(sql, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (var adapter = new OracleDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }
    }
}