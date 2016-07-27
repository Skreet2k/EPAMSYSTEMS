using System.Configuration;

namespace Infrastructure.LoggingToDB
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
