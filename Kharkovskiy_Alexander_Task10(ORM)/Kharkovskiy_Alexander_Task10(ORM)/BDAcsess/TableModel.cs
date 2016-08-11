using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kharkovskiy_Alexander_Task10_ORM_.BDAcsess
{
    public class TableModel
    {
        public string Name { get; set; }
        public List<Column> Columns { get; set; }
    }
}
