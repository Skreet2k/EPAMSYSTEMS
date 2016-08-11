using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kharkovskiy_Alexander_Task10_ORM_.BDAcsess
{
    public class Column
    {
        public string Name { get; set; }
        public List<object> Cells { get; set; }
        public bool IsPrimaryKey { get; set; }
        public bool IsForeignKey { get; set; }
    }
}
