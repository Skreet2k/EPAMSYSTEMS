using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class DataWorker
    {
        private static Database _database;
        static DataWorker()
        {
            _database = DatabaseFactory.CreateDatabase();
        }
        public static Database database
        {
            get { return _database; }
        }
    }
}
