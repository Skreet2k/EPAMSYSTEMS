using System.Collections.Generic;
using System.Windows.Forms;

namespace UI
{
    /// <summary>
    /// Класс для обработки таблицы.
    /// </summary>
    internal static class TableService
    { 
        /// <summary>
        /// Преобрование листа в таблицу.
        /// </summary>
        /// <param name="cells">Лист с ячейками таблицы</param>
        /// <param name="table">Таблица</param>
        public static  void ListToTable(List<List<string>> cells, DataGridView table)
        {
            table.Rows.Clear();
            for (var i = 0; i < cells.Count; i++)
            {
                table.Rows.Add();
                for (var j = 0; j < cells[i].Count; j++)
                {
                    table.Rows[i].Cells[j].Value = cells[i][j];
                }
            }
        }
        /// <summary>
        /// Извлечение строк из таблицы в List ячеек.
        /// </summary>
        /// <param name="table">Таблица.</param>
        /// <returns>Лист ячеек.</returns>
        public static List<List<string>> TableToList(DataGridView table)
        {
            var list = new List<List<string>>();
            for (var i = 0; i < table.RowCount; i++)
            {
                list.Add(new List<string>());
                for (var j = 0; j < table.ColumnCount; j++)
                {
                    list[i].Add(table.Rows[i].Cells[j].Value.ToString());
                }
            }
            return list;
        }
    }
}
