using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kharkovskiy_Alexander_Task10_ORM_.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ForeignKeyAttribute: Attribute
    {
        public string Name { get; set; }
        public string TypeName { get; set; }

        public ForeignKeyAttribute(string name, string typeName)
        {
            Name = name;
            TypeName = typeName;
        }
    }
}
