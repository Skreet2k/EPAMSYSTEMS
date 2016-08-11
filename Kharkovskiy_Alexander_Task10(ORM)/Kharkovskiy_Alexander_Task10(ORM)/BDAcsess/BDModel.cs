using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kharkovskiy_Alexander_Task10_ORM_.BDAcsess
{
    public class BdModel: IBdCommand
    {
        public TableModel Select(string tableName)
        {
            throw new NotImplementedException();
        }

        public int Insert(string tableName, string columns, string values)
        {
            throw new NotImplementedException();
        }
    }
}
