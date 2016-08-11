using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Kharkovskiy_Alexander_Task10_ORM_.Attributes;
using Kharkovskiy_Alexander_Task10_ORM_.DataAcsess;

namespace Kharkovskiy_Alexander_Task10_ORM_
{
    class Program
    {
        static void Main(string[] args)
        {
            var EntityModel = new EntityModel() {Date = DateTime.Now, Name = "ItIsName"};
            var dm = new DataModel<EntityModel>();
            dm.RegisterInstance(EntityModel);
            dm.RegisterInstance(EntityModel);
            dm.RegisterInstance(EntityModel);
            dm.RegisterInstance(EntityModel);
            dm.RegisterInstance(EntityModel);
            dm.RegisterInstance(EntityModel);
            dm.RegisterInstance(EntityModel);
        }
    }
}
