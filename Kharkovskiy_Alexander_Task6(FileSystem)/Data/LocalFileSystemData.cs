using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Data
{
    /// <summary>
    ///     Тип для получение или записи состояния файловой системы.
    /// </summary>
    public class LocalFileSystemData
    {
        /// <summary>
        ///     Результат выполнения операции.
        /// </summary>
        public string ResultRequest { get; private set; }

        /// <summary>
        ///     Загрузка состояния файловой системы.
        /// </summary>
        /// <param name="path">Место загрузки состояния.</param>
        /// <returns>Считаный объект</returns>
        public object Load(string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.Open))
                {
                    var formatter = new BinaryFormatter();
                    var obj = formatter.Deserialize(fs);
                    ResultRequest = "Состояние системы было успешно загружено.";
                    return obj;
                }
            }
            catch (Exception e)
            {
                ResultRequest = $"Произошла ошибка при загрузке состояния системы: {e.Message}";
                return null;
            }
        }

        /// <summary>
        ///     Запись состояния файловой системы.
        /// </summary>
        /// <param name="obj">Объект для записи.</param>
        /// <param name="path">Место записи.</param>
        public void Safe(object obj, string path)
        {
            try
            {
                using (var fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    var formatter = new BinaryFormatter();
                    formatter.Serialize(fs, obj);
                }
                ResultRequest = "Состояние системы было успешно сохранено.";
            }
            catch (Exception e)
            {
                ResultRequest = $"Произошла ошибка при сохранении состояния системы: {e.Message}";
            }
        }
    }
}