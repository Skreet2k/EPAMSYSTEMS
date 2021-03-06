﻿using System;

namespace Kharkovskiy_Alexander_Task10_ORM_.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public string Name { get; set; }
        public string TypeName { get; set; }
        public bool IsPrimaryKey { get; set; }

        public ColumnAttribute(string name, string typeName)
        {
            Name = name;
            TypeName = typeName;
        }
        public ColumnAttribute(string name)
        {
            Name = name;
        }
    }
}
