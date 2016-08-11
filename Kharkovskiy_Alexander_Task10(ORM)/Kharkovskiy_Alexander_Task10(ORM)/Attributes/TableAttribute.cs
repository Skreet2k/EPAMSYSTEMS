using System;

namespace Kharkovskiy_Alexander_Task10_ORM_.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableAttribute : Attribute
    {
        public string DbTableName { get; set; }
        public TableAttribute(string dbTableName)
        {
            DbTableName = dbTableName;
        }
    }
}
