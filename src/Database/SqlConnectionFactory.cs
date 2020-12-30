using System.Data;
using System.Data.SqlClient;

namespace Database
{
    public class SqlConnectionFactory : IConnectionFactory
    {
        public IDbConnection OpenConnection()
        {
            return new SqlConnection(ConnectionStringHelper.GetConnectionString());
        }
    }
}
