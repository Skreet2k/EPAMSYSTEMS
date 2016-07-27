using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Infrastructure.LoggingToDB
{
    public class DbTraceListener : TraceListener
    {
        private readonly List<string> _commandsStore = new List<string>();
        private readonly string _loggingDb;
        private readonly int _messageBufferSize;

        public DbTraceListener(string configSectionName)
        {
            try
            {
                var config = ConfigurationManager.GetSection(configSectionName) as LoggingConfigSection;
                _loggingDb = config.ConnectionStrings["LoggingDB"].ToString();
                _messageBufferSize = config.MessageBufferSize;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public override void Write(string message)
        {
            _commandsStore.Add(message);
        }

        public override void WriteLine(string message)
        {
            _commandsStore[_commandsStore.Count - 1] += message;
            if (_commandsStore.Count == 1)
            {
                using (IDbConnection connection = new SqlConnection(_loggingDb))
                {
                    try
                    {
                        connection.Open();
                    }
                    catch (DbException ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                    if (connection.State == ConnectionState.Open)
                    {
                        var sqlCommand = "";
                        var command = connection.CreateCommand();
                        foreach (var item in _commandsStore)
                        {
                            var type = "Information";
                            if (item.Contains("Error"))
                                type = "Error";
                            if (item.Contains("Warning"))
                                type = "Warning";

                            sqlCommand +=
                                $"IF NOT EXISTS(SELECT [name] FROM sys.tables WHERE [name] = '{type}')"
                                + $"CREATE TABLE {type}("
                                + "id UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID(),"
                                + "dt datetime," 
                                + "info char(255))" 
                                + $"INSERT INTO {type}(dt,info) VALUES"
                                + $@"(GetDate(), '{item.Replace("'", "&#39;")}')";
                        }
                        command.CommandText = sqlCommand;
                        using (var reader = command.ExecuteReader())
                        {
                        }
                    }
                    _commandsStore.Clear();
                }
            }
        }
    }
}