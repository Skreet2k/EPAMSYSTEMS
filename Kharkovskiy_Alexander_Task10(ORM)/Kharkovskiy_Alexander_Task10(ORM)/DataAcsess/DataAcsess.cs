using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kharkovskiy_Alexander_Task10_ORM_.BDAcsess;

namespace Kharkovskiy_Alexander_Task10_ORM_.DataAcsess
{
    public class DataAcsess: IDataAcsess
    {
        private string _connectionString;
        public DataAcsess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int Insert()
        {
            using (DbConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "";
                return 0;
            }
        }
    }
}
