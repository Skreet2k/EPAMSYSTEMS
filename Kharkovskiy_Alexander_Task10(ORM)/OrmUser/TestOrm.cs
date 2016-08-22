using Kharkovskiy_Alexander_Task10_ORM_;

namespace OrmUser
{
    class TestOrm: Orm
    {
        public IOrmRepository<Person> Person { get; private set; }
        public IOrmRepository<Users> Users { get; private set; }
    }
}
