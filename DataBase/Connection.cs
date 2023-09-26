using System.Data.SqlClient;

namespace uni_project.DataBase
{
    public class Connection
    {
        private readonly IConfiguration _configuration;

        public Connection(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private SqlConnection connection;

        public SqlConnection GetConnection()
        {

            if (connection == null)
            {
                this.connection = new SqlConnection(connectionString: _configuration["sqlConnection"]);
                return connection;
            }
            return connection;
        }
    }
}
