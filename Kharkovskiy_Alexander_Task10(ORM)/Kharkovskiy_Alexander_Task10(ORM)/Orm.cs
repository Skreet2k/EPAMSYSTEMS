using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Kharkovskiy_Alexander_Task10_ORM_.Attributes;
using Kharkovskiy_Alexander_Task10_ORM_.DateModel;

namespace Kharkovskiy_Alexander_Task10_ORM_
{
    public class Orm
    {
        /// <summary>
        /// Типы объектов для переноса из CLR в БД
        /// </summary>
        private Dictionary<Type, string> _typeName = new Dictionary<Type, string>
        {
            { typeof(int), "int"},
            { typeof(string), "nvarchar(128)" },
            { typeof(DateTime),"datetime"}
        };
        /// <summary>
        /// Конструктор инициализирующий репозитории.
        /// </summary>
        public Orm()
        {
            var props = GetType().GetProperties();
            foreach (var p in props)
            {
                InitializeOrmRepository(p);
            }
        }
        /// <summary>
        /// Инстанцирование полей типа OrmRepository
        /// </summary>
        /// <param name="p"></param>
        private void InitializeOrmRepository(PropertyInfo p)
        {
            if(p.PropertyType.GetGenericTypeDefinition() == typeof(IOrmRepository<>) && p.GetValue(this) == null)
            {
                var entityType = p.PropertyType.GetGenericArguments().First();
                var ormRepositoryInstance =
                    Activator.CreateInstance(typeof (OrmRepository<>).MakeGenericType(entityType));
                var tableModelInstance = new TableModel
                {
                    Name = GetTableName(entityType),
                    Columns = GetColumns(entityType)
                };
                ormRepositoryInstance.GetType().GetProperties()[0].SetValue(ormRepositoryInstance, tableModelInstance);
                p.SetValue(this, ormRepositoryInstance);
            }
        }
        /// <summary>
        /// Получение массива Column из полей типа.
        /// </summary>
        /// <param name="type">Тип</param>
        private IList<Column> GetColumns(Type type)
        {
            var columns = new List<Column>();
            var propertis = type.GetProperties();
            foreach (var p in propertis)
            {
                ForeignKeyAttribute fca;
                if ((fca = p.GetCustomAttribute<ForeignKeyAttribute>()) != null)
                {
                    foreach (var prop in GetType().GetProperties())
                    {
                        if (prop.PropertyType.GetGenericArguments()[0] == p.PropertyType)
                        {
                            var pi = GetType().GetProperty(prop.Name);
                            InitializeOrmRepository(pi);
                            var tablemodel = (TableModel)pi.PropertyType.GetProperty("TableModel").GetValue(pi.GetValue(this));
                            columns.Add(new Column(fca.Name, tablemodel.Columns.Single(c=>c.IsPrimaryKey).TypeName) {References = tablemodel, IsForeignKey = true, });

                            break;
                        }
                    }
                    
                }
                else
                {
                    ColumnAttribute ca;
                    if ((ca = p.GetCustomAttribute<ColumnAttribute>()) != null)
                    {
                        columns.Add(
                            new Column(ca.Name, ca.TypeName)
                            {
                                IsPrimaryKey = ca.IsPrimaryKey,
                            });
                    }
                    else if (_typeName.ContainsKey(p.PropertyType))
                        columns.Add(new Column(p.Name,  _typeName[p.PropertyType]));
                    else
                        throw new Exception($"Orm cant recognize type of property {p.Name}");
                }          
            }
            // Проверка на содержание в типе Entity одного поля с атрибутом PrimaryKey
            if(columns.Count(c => c.IsPrimaryKey) != 1)
                throw new Exception($"Type {type.Name} not include or got more then one property with attributes [Column(PrimaryKey=true)]");
            return columns;
        }
        /// <summary>
        /// Получение имени таблицы типа
        /// </summary>
        /// <param name="type">Тип</param>
        /// <returns>Имя таблицы</returns>
        private string GetTableName(Type type)
        {
            return type.GetCustomAttribute<TableAttribute>().DbTableName ?? type.Name;
        }
    }
}
