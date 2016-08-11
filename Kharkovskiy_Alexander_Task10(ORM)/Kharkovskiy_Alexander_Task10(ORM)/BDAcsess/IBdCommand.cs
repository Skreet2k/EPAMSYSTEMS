using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kharkovskiy_Alexander_Task10_ORM_.BDAcsess
{
public interface IBdCommand
{
    TableModel Select(string tableName);
    int Insert(string tableName, string columns, string values);
    }
}
