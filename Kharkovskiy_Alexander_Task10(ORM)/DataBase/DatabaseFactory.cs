using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public static class DatabaseFactory
    {
        public static DatabaseFactorySection SectionHandler = (DatabaseFactorySection)ConfigurationManager.GetSection("DatabaseFactoryConfiguration");

        public static Database CreateDatabase()
        {
            if (SectionHandler.Name.Length == 0)
            {
                throw new Exception("Database name not defined in DatabaseFactoryConfiguration section.");
            }

            try
            {
                Type database = Type.GetType(SectionHandler.Name);
                ConstructorInfo constructor = database.GetConstructor(new Type[] { });
                Database createdObject = (Database)constructor.Invoke(null);
                createdObject.ConnectionString = SectionHandler.ConnectionString;
                return createdObject;
            }
            catch (Exception excep)
            {
                throw new Exception("Error instantiating database " + SectionHandler.Name + ". " + excep.Message);
            }
        }
    }
}

