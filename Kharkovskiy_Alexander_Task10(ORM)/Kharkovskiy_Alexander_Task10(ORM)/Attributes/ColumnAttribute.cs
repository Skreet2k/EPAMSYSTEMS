using System;

namespace Kharkovskiy_Alexander_Task10_ORM_.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string DbColumnName { get; set; }
        public bool IsForeignkey { get; set; }
        public bool IsPrimaryKey { get; set; }

        public ColumnAttribute(string dbColumnName)
        {
            DbColumnName = dbColumnName;
        }
    }
}
