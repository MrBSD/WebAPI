using System.Data.SqlClient;

namespace DAL
{
    public interface IDatabaseConnector
    {
        SqlConnection GetSqlConnection();
    }
}