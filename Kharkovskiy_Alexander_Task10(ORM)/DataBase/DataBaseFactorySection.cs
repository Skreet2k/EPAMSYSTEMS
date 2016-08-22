using System;
using System.Configuration;

namespace DataBase
{
    public sealed class DatabaseFactorySection : ConfigurationSection
    {
        [ConfigurationProperty("Name")]
        public string Name
        {
            get { return (string)base["Name"]; }
        }

        [ConfigurationProperty("ConnectionStringName")]
        public string ConnectionStringName
        {
            get { return (string)base["ConnectionStringName"]; }
        }

        public string ConnectionString
        {
            get
            {
                try
                {
                    return ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString;
                }
                catch (Exception e)
                {
                    throw new Exception("Connection string " + ConnectionStringName + " was not found. " + e.Message);
                }
            }
        }
    }
}