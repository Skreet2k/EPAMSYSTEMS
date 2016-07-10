using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Task3
{
    internal sealed class CustomSection: ConfigurationSection
    {
        public static readonly ConfigurationProperty IntDefaultCapacity =
            new ConfigurationProperty("IntDefaultCapacity",
        typeof(int), 4,
        ConfigurationPropertyOptions.None);

        public CustomSection()
        {
            Properties.Add(IntDefaultCapacity);
        }
    }
}
