using System.Configuration;

namespace Infrastructure
{
    public class LoggingConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("messageBufferSize")]
        public int MessageBufferSize
        {
            get
            {
                var str = (base["messageBufferSize"]).ToString();
                return int.Parse(str);
            }
        }

        [ConfigurationProperty("tableName")]
        public string TableName
        {
            get
            {
                return (base["tableName"]).ToString();
            }
        }

        [ConfigurationProperty("dbConnection")]
        public ConnectionStringSettings DbConnection
        {
            get
            {
                return (ConnectionStringSettings)base["dbConnection"];
            }
        }

        [ConfigurationProperty("connectionStrings")]
        [ConfigurationCollection(typeof(ConnectionStringSettings))]
        public ConnectionStringSettingsCollection ConnectionStrings
        {
            get
            {
                return (ConnectionStringSettingsCollection)base["connectionStrings"];
            }
        }
    }
}
