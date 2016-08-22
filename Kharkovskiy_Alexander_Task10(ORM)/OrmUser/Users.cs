using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kharkovskiy_Alexander_Task10_ORM_.Attributes;

namespace OrmUser
{
    [Table("rfgh")]
    public class Users
    {
        [Column("Name","nvarchar(128)", IsPrimaryKey = true)]
        public string Name { get; set; }
        public string Password { get; set; }
    }
}
