using System;
using System.Diagnostics;
using System.Linq;using System.Reflection;
using DataBase;
using Kharkovskiy_Alexander_Task10_ORM_.Attributes;
using Kharkovskiy_Alexander_Task10_ORM_.DateModel;

namespace Kharkovskiy_Alexander_Task10_ORM_
{
    /// <summary>
    /// Репозиторий обектра типа TEntity
    /// </summary>
    /// <typeparam name="TEntity">Класс для мапинга</typeparam>
    public class OrmRepository<TEntity>: DataWorker, IOrmRepository<TEntity>
    {
        /// <summary>
        /// Размапленный тип TEntity
        /// </summary>
        public TableModel TableModel { get; set; }
        /// <summary>
        /// Получить объект из БД по ключу
        /// </summary>
        /// <param name="primaryKey">ключ</param>
        /// <returns>Объект TEntity</returns>
        public TEntity GetById(string primaryKey)
        {
            if (primaryKey == null)
                throw new ArgumentNullException();
            var primarykeyColumn = "";
            foreach (var p in typeof(TEntity).GetProperties())
            {
                ColumnAttribute ca;
                if ((ca = p.GetCustomAttribute<ColumnAttribute>()) != null)
                {
                    if (ca.IsPrimaryKey)
                    {
                        primarykeyColumn = ca.Name;
                        break;
                    }
                }
            }
            var entity = (TEntity)Activator.CreateInstance(typeof(TEntity));
            using (var connection = database.CreateOpenConnection())
            {
                var commandtext = $"SELECT * FROM {typeof(TEntity).GetCustomAttribute<TableAttribute>().DbTableName ?? typeof(TEntity).Name} WHERE {primarykeyColumn} = @primarykey";
                var command = database.CreateCommand(commandtext, connection);
                command.Parameters.Add(database.CreateParameter("@primarykey", primaryKey));
                command.CommandText = commandtext;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            var prop = entity.GetType().GetProperties()[i];
                            if (prop.GetCustomAttribute<ForeignKeyAttribute>() != null)
                            {
                                var ormrepository = Activator.CreateInstance(typeof (OrmRepository<>).MakeGenericType(prop.PropertyType));
                                var referenceEntity = ormrepository.GetType().GetMethod("GetById").Invoke(ormrepository, new[] {reader.GetValue(i)});
                                prop.SetValue(entity, referenceEntity);
                            }
                            else
                            {
                                prop.SetValue(entity, reader.GetValue(i));
                            }
                        }
                    }
                }
                Trace.TraceInformation("A request is made to the database:" + commandtext);
            }
            return entity;
        }
        /// <summary>
        /// Создание таблицы для типа TEntity
        /// </summary>
        /// <returns>Репозиторий</returns>
        public IOrmRepository<TEntity> Create()
        {
            using (var connection = database.CreateOpenConnection())
            {
                // Создание таблицы, если ее не существует.
                var commandtext =
                    $"IF NOT EXISTS(SELECT [name] FROM sys.tables WHERE [name] = '{TableModel.Name}') CREATE TABLE {TableModel.Name}(";
                foreach (var column in TableModel.Columns)
                {
                    commandtext += column.Name + " " + column.TypeName;
                    if (column.IsPrimaryKey)
                        commandtext += " NOT NULL PRIMARY KEY";
                    if (column.IsForeignKey)
                    {
                        commandtext += " FOREIGN KEY REFERENCES " + column.References.Name + "(";
                        commandtext += column.References.Columns.Single(c => c.IsPrimaryKey).Name + ")";
                    }

                    commandtext += ",";
                }
                commandtext = commandtext.Trim(',');
                commandtext += ");";
                var command = database.CreateCommand(commandtext, connection);
                command.ExecuteNonQuery();
                Trace.TraceInformation("A request is made to the database:" + commandtext);
            }
            return this;
        }
        /// <summary>
        /// Добавление в БД объекта entity
        /// </summary>
        /// <param name="entity">Экземпляр объекта</param>
        /// <returns>Репозиторий.</returns>
        public IOrmRepository<TEntity> Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            // Создание таблицы TEntity.
            Create();
            // Добавление в таблицу объектра entity
            using (var connection = database.CreateOpenConnection())
            {
                var command = connection.CreateCommand();
                var commandtext = $"INSERT INTO {TableModel.Name} VALUES (";
                foreach (var prop in entity.GetType().GetProperties())
                {
                    if (prop.GetCustomAttribute<ForeignKeyAttribute>() != null)
                    {
                        var value =
                            prop.PropertyType.GetProperties()
                                .Single(
                                    p =>
                                        p.GetCustomAttribute<ColumnAttribute>() != null &&
                                        p.GetCustomAttribute<ColumnAttribute>().IsPrimaryKey)
                                .GetValue(prop.GetValue(entity));
                        command.Parameters.Add(database.CreateParameter("@" + prop.Name, value));
                    }
                    else
                    {
                        command.Parameters.Add(database.CreateParameter("@" + prop.Name, prop.GetValue(entity)));
                    }
                    commandtext += "@" + prop.Name + ",";
                }
                commandtext = commandtext.Trim(',');
                commandtext += ");";
                command.CommandText = commandtext;
                command.ExecuteNonQuery();
                Trace.TraceInformation("A request is made to the database:" + commandtext);
            }
            return this;
        }
        /// <summary>
        /// Удаление объектра из БД по ключу.
        /// </summary>
        /// <param name="primaryKey">Ключ.</param>
        /// <returns>Репозиторий.</returns>
        public IOrmRepository<TEntity> Remove(string primaryKey)
        {
            if (primaryKey == null)
                throw new ArgumentNullException();
            var primarykeyColumn = TableModel.Columns.Single(c => c.IsPrimaryKey).Name;
            using (var connection = database.CreateOpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = $"DELETE FROM {TableModel.Name} WHERE {primarykeyColumn}=@primarykey";
                command.Parameters.Add(database.CreateParameter("@primarykey", primaryKey));
                command.ExecuteNonQuery();
                Trace.TraceInformation("A request is made to the database:" + command.CommandText);

            }
            return this;
        }
        /// <summary>
        /// Обновление объекта в БД
        /// </summary>
        /// <param name="primaryKey">Ключ</param>
        /// <param name="entity">Новый объект</param>
        /// <returns>Репозиторий.</returns>
        public IOrmRepository<TEntity> Update(string primaryKey,TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException();
            var primarykeyColumn = TableModel.Columns.Single(c => c.IsPrimaryKey).Name;
            using (var connection = database.CreateOpenConnection())
            {
                var commandtext = $"UPDATE {TableModel.Name} SET ";
                var command = connection.CreateCommand();
                foreach (var prop in entity.GetType().GetProperties())
                {
                    object value;
                    if (prop.GetCustomAttribute<ForeignKeyAttribute>() != null)
                    {
                        value = prop.PropertyType.GetProperties().Single(p => p.GetCustomAttribute<ColumnAttribute>() != null && p.GetCustomAttribute<ColumnAttribute>().IsPrimaryKey).GetValue(prop.GetValue(entity));
                    }
                    else
                    {
                        value = prop.GetValue(entity);
                    }
                    command.Parameters.Add(database.CreateParameter("@" + prop.Name, value));

                    commandtext += prop.Name + "=@" + prop.Name + ",";
                }
                command.Parameters.Add(database.CreateParameter("@primarykey", primaryKey));
                commandtext = commandtext.Trim(',');
                commandtext += $" WHERE {primarykeyColumn}=@primarykey;";
                command.CommandText = commandtext;
                command.ExecuteNonQuery();
                Trace.TraceInformation("A request is made to the database:" + command.CommandText);
            }
            return this;
        }
    }
}
