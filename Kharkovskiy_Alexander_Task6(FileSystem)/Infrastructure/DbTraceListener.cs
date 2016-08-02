using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;

namespace Infrastructure
{
    public class DbTraceListener : TraceListener
    {
        private readonly LinkedList<string[]> _commandsStore = new LinkedList<string[]>();
        private readonly string _loggingDb;
        private readonly string _tableName;
        private readonly int _messageBufferSize;

        public DbTraceListener(string configSectionName)
        {
            try
            {
                var config = ConfigurationManager.GetSection(configSectionName) as LoggingConfigSection;
                _loggingDb = config.ConnectionStrings["LoggingDB"].ToString();
                _messageBufferSize = config.MessageBufferSize;
                _tableName = config.TableName;

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message, "Information");
                throw;
            }
        }

        public override void Write(string message)
        {
            _commandsStore.Last.Value[1] = message;
        }

        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id,
            string message)
        {
            _commandsStore.AddLast(new[] { eventType.ToString(), null });
            base.TraceEvent(eventCache, source, eventType, id, message);
        }
        

        public override void WriteLine(string message)
        {
            if (_commandsStore.Last == null)
                _commandsStore.AddLast(new []{ TraceEventType.Information.ToString(), message});
            else
                _commandsStore.Last.Value[1]+= message;

            if (_commandsStore.Count >= _messageBufferSize)
            {
                if(SendToDb() == _commandsStore.Count) //Проверка, если строки поместились в БД то очищаем лист.
                    _commandsStore.Clear();
            }
        }

        private int SendToDb()
        {
            using (var connection = new SqlConnection(_loggingDb))
            {
                try
                {
                    connection.Open();
                }
                catch (DbException ex)
                {
                    Trace.WriteLine(ex.Message, "Information");
                    throw;
                }
                if (connection.State == ConnectionState.Open)
                {
                    var changedLines = 0;
                    var command = connection.CreateCommand();
                    command.CommandText = $"IF NOT EXISTS(SELECT [name] FROM sys.tables WHERE [name] = '{_tableName}')"
                                          + $"CREATE TABLE {_tableName}(id UNIQUEIDENTIFIER DEFAULT NEWSEQUENTIALID(), dt datetime, type char(255), info char(255))";
                    command.ExecuteNonQuery(); //Создаем таблицу, если ее не существует.
                    command.CommandText =
                        $"INSERT INTO {_tableName}(dt, type, info) VALUES (GetDate(), @type, @info)";
                    command.Parameters.Add("@type",SqlDbType.VarChar);
                    command.Parameters.Add("@info", SqlDbType.VarChar);
                    foreach (var item in _commandsStore)
                    {
                        command.Parameters["@type"].Value = item[0];
                        command.Parameters["@info"].Value = item[1];                         
                        changedLines+=command.ExecuteNonQuery();
                    }
                    return changedLines;
                }
            }
            return 0;
        }
    }
}