using System;
using System.Configuration;

namespace Database
{
    public class ConnectionStringHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings[GetConnectionStringKey()].ConnectionString;
        }

        private static string GetConnectionStringKey()
        {
            return $"conn:db:{Environment.MachineName}";
        }
    }
}
