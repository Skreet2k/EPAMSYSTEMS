using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Kharkovskiy_Alexander_Task10_ORM_.Attributes;
using Kharkovskiy_Alexander_Task10_ORM_.BDAcsess;

namespace Kharkovskiy_Alexander_Task10_ORM_.DataAcsess
{
    //public class DataModel<TDataModel> where TDataModel:class, new()
    //{
    //    private TableModel _table = new TableModel();

    //    public DataModel()
    //    {
    //        _table.Columns = GetColumns();
    //        _table.Name = GetTableName();
    //    }
    //    //public DataAcsess GetDataAcsess()
    //    //{
    //    //    var da = new DataAcsess(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DataBase.mdf;Integrated Security=True") {Table = _table};
    //    //    return da;
    //    //}
    //    public void RegisterInstance(TDataModel instance)
    //    {
    //        for (var i = 0; i < _table.Columns.Count; i++)
    //        {
    //            _table.Columns[i].Cells.Add(typeof(TDataModel).GetProperties()[i].GetValue(instance));
    //        }
    //    }
    //    private List<Column> GetColumns()
    //    {
    //        var columns = new List<Column>();
    //        var propertis = typeof(TDataModel).GetProperties();
    //        foreach (var p in propertis)
    //        {
    //            ColumnAttribute ca;
    //            columns.Add((ca = p.GetCustomAttribute<ColumnAttribute>()) != null
    //                ? new Column()
    //                {
    //                    Name = ca.DbColumnName,
    //                    IsForeignKey = ca.IsForeignkey,
    //                    IsPrimaryKey = ca.IsPrimaryKey,
    //                    Cells = new List<object>()
    //                }
    //                : new Column() { Name = p.Name, Cells = new List<object>() });
    //        }
    //        return columns;
    //    }

    //    private string GetTableName()
    //    {
    //        return typeof(TDataModel).GetCustomAttribute<TableAttribute>().DbTableName ?? typeof(TDataModel).Name;
    //    }
    //}
}
