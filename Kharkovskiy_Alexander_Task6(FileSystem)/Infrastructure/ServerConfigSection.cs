using System.Configuration;

namespace Infrastructure
{
    public class ServerConfigSection : ConfigurationSection
    {
        [ConfigurationProperty("ip")]
        public string IpAdress
        {
            get
            {
                return (base["ip"]).ToString();
            }
        }
        [ConfigurationProperty("port")]
        public int Port
        {
            get
            {
                var str = (base["port"]).ToString();
                return int.Parse(str);
            }
        }
    }
}