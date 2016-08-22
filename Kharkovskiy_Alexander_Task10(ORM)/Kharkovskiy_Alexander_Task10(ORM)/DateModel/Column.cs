namespace Kharkovskiy_Alexander_Task10_ORM_.DateModel
{
    public class Column
    {
        public string Name { get; set; }
        public TableModel References { get; set; }
        public string TypeName { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsForeignKey { get; set; }

        public Column(string name, string typeName)
        {
            Name = name;
            TypeName = typeName;
        }
    }
}
