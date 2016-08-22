using System.Data;
using System.Data.SqlClient;

namespace DataBase
{
    public class LocalDb : Database
    {
        public override IDbConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public override IDbCommand CreateCommand()
        {
            return new SqlCommand();
        }

        public override IDbConnection CreateOpenConnection()
        {
            var connection = (SqlConnection) CreateConnection();
            connection.Open();

            return connection;
        }

        public override IDbCommand CreateCommand(string commandText, IDbConnection connection)
        {
            var command = (SqlCommand) CreateCommand();

            command.CommandText = commandText;
            command.Connection = (SqlConnection) connection;
            command.CommandType = CommandType.Text;

            return command;
        }

        public override IDbCommand CreateStoredProcCommand(string procName, IDbConnection connection)
        {
            var command = (SqlCommand) CreateCommand();

            command.CommandText = procName;
            command.Connection = (SqlConnection) connection;
            command.CommandType = CommandType.StoredProcedure;

            return command;
        }

        public override IDataParameter CreateParameter(string parameterName, object parameterValue)
        {
            return new SqlParameter(parameterName, parameterValue);
        }
    }
}

