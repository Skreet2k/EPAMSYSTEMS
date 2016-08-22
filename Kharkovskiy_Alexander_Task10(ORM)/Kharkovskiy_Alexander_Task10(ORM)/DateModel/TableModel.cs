using System.Collections.Generic;

namespace Kharkovskiy_Alexander_Task10_ORM_.DateModel
{
    public class TableModel
    {
        public string Name { get; set; }
        public IList<Column> Columns { get; set; }
    }
}
