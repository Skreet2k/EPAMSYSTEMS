using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace UI
{
    /// <summary>
    /// Клас для обработки клиентов из UI.
    /// </summary>
    internal static class ClientService
    {
        /// <summary>
        /// Чтение из файла списка клиентов.
        /// </summary>
        /// <param name="path">Путь к файлу.</param>
        /// <returns>Лист с полями клиентов.</returns>
        public static List<List<string>> ParseClientFromTxt(string path)
        {
            var list = new List<List<string>>();
            try
            {
                using (var sr = new StreamReader(path))
                {
                    string line;
                    var bank = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("Банк:"))
                        {
                            bank = line.Replace("Банк:", "").Trim();
                        }
                        if (line.Contains("Клиент:"))
                        {
                            var array = line.Replace("Клиент:", "").Trim().Split().ToList();
                            array.Add(bank);
                            if (array.Count == 4)
                            {
                                array.Insert(2, "");
                            }
                            if (array.Count == 5)
                            {
                                list.Add(array);
                            }
                        }
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show(e.Message);
            }
            return list;
        }
        /// <summary>
        /// Фильтрация листа клиентов.
        /// </summary>
        /// <param name="clients">Лист с полями клиентов.</param>
        /// <param name="surname">Фамилия.</param>
        /// <param name="name">Имя.</param>
        /// <param name="patronimic">Отчество.</param>
        /// <param name="bank">Банк.</param>
        /// <returns>Отфильтрованный список клиентов.</returns>
        public static List<List<string>> ClientFilter(List<List<string>> clients, string surname, string name, string patronimic, string bank)
        {
            clients = clients.Where(client => (string.IsNullOrWhiteSpace(surname) || client[0].Contains(surname)) &&
                                           (string.IsNullOrWhiteSpace(name) || client[1].Contains(name)) &&
                                           (string.IsNullOrWhiteSpace(patronimic) || client[2].Contains(patronimic)) &&
                                           (string.IsNullOrWhiteSpace(bank) || client[4].Contains(bank))).ToList();
            return clients;
        }
    }
}