using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace OrmUser
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new Users() { Name = "Павел", Password = "1231j23213123123"};
            var entity = new Person() { Name = "неимя", Number = 15, Surname = "Вася", User = user };

            var testOrm = new TestOrm();
            // testOrm.Users.Add(user);
            // testOrm.Person.Add(entity);
           // var persons = testOrm.Person.GetById("Вася");
        }
    }
}
