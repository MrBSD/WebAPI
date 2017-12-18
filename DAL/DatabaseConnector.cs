using System.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace DAL
{
    public class DatabaseConnector : IDatabaseConnector
    {
        private readonly ConnectionSettings _connectionSettings;

        public string ConnectionString
        {
            get
            {
                var connectionStringFromSetttings = _connectionSettings.ConnectionString;
                var connectionString = new SqlConnectionStringBuilder(connectionStringFromSetttings);
                connectionString.ConnectTimeout = (_connectionSettings.ConnectTimeout > 0)
                    ? _connectionSettings.ConnectTimeout
                    : connectionString.ConnectTimeout;

                return connectionString.ToString();
            }
        }    

        public DatabaseConnector(IOptions<ConnectionSettings> connectionSettings)
        {
            _connectionSettings = connectionSettings.Value;
        }

        public  SqlConnection GetSqlConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
