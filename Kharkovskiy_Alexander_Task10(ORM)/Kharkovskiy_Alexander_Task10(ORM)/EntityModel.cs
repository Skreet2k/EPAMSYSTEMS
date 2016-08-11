using System;

using Kharkovskiy_Alexander_Task10_ORM_.Attributes;

namespace Kharkovskiy_Alexander_Task10_ORM_
{
    [Table("EntityModelTableName")]
    public class EntityModel
    {
        [Column("columnName")]
        public string Name { get; set; }

        public DateTime Date { get; set; }
    }
}
