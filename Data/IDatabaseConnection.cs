using System.Data.SqlClient;

namespace person_api.Data
{
    public interface IDatabaseConnection
    {
        SqlConnection OpenDatabaseConnection();
    }
}