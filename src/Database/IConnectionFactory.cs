using System.Data;

namespace Database
{
    public interface IConnectionFactory
    {
        IDbConnection OpenConnection();
    }
}
