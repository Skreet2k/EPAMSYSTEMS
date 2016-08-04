using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Servises;

namespace DAL
{
    public class DataServices
    {
        /// <summary>
        /// Сохранение объекта в Xml.
        /// </summary>
        /// <param name="obj">Объект.</param>
        /// <param name="path">Путь к файлу.</param>
        public void SafeToXml(object obj, string path)
        {
                using (var sr = new StreamWriter(path))
                {
                    var ser = new XmlSerializer(obj.GetType());
                    ser.Serialize(sr, obj);
                }
        }
        /// <summary>
        /// Сохранение List объектов Bank в txt файл.
        /// </summary>
        /// <param name="banks">List объектов Bank.</param>
        /// <param name="path">Путь к файлу.</param>
        public void SafeToTxt(List<Bank> banks, string path)
        {
            using (var sr = new StreamWriter(path))
            {
                foreach (var bank in banks)
                {
                    sr.WriteLine($"Банк: {bank.Name}");
                    foreach (var client in bank.Clients)
                    {
                        sr.WriteLine($"Клиент: {client.Surname} {client.Name} {client.Patronymic} {client.DateOfBirth.ToShortDateString()}");
                    }
                }
            }
        }
        /// <summary>
        /// Загрузка объекта из Xml файла.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns>Загруженный объект.</returns>
        public object LoadFromXml(string path)
        {
            using (var sr = new StreamReader(path))
            {
                var ser = new XmlSerializer(typeof(object));
                var obj = ser.Deserialize(sr);
                return obj;
            }
        }
        /// <summary>
        /// Загрузка объекта из текстового файла.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns>Объект.</returns>
        public object LoadFromTxt(string path)
        {
            using (var sr = new StreamReader(path))
            {
                var obj = sr.ReadToEnd();
                return obj;
            }
        }

    }
}
