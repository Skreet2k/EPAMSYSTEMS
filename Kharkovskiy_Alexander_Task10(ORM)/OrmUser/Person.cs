using System;
using Kharkovskiy_Alexander_Task10_ORM_.Attributes;

namespace OrmUser
{
    [Table("Person")]
    public class Person
    {
        [Column("Name", "nvarchar(128)")]
        public string Name { get; set; }
        [Column("Surname", "nvarchar(128)", IsPrimaryKey = true)]
        public string Surname { get; set; }
        public int Number { get; set; }
        [ForeignKey("UserID", "nvarchar(128)")]
        public Users User { get; set; }
    }
}
