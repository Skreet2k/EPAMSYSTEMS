using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Kharkovskiy_Alexander_Task7_LINQ_
{
    internal class Program
    {
        /// <summary>
        ///     Считывание строк файла в List
        /// </summary>
        /// <param name="path">Путь к файлу</param>
        public static List<string> ReadFileToList(string path)
        {
            var list = new List<string>();
            try
            {
                using (var sr = new StreamReader(path, Encoding.Default))
                {
                    while (true)
                    {
                        var line = sr.ReadLine();
                        if (line == null)
                            break;
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            list.Add(line);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Файл {path} не был прочитан: {e.Message}");
            }
            return list;
        }

        /// <summary>
        ///     Создает из строки объект клиента. Если не удается - возвращает null.
        /// </summary>
        /// <param name="str">Исходная строка</param>
        /// <param name="bankName">Имя банка</param>
        /// <returns>null или Client</returns>
        public static Client ParseClientFromString(string str, string bankName)
        {
            if (str == null || !str.Contains("Клиент:")) // Если строка не содержит "Клиент:" значит парсить нечего.
                return null;
            var clientArray = str.Replace("Клиент:", "").Replace(",", "").Trim().Split(' ');
                // Удаляет ненужные символы и сплитит в массив.
            try
            {
                return clientArray.Length == 3
                    ? new Client(clientArray[0], clientArray[1], "", DateTime.Parse(clientArray[2]), bankName)
                    // Если 3 итема в массиве, то отчество пропущенно.
                    : new Client(clientArray[0], clientArray[1], clientArray[2], DateTime.Parse(clientArray[3]),
                        bankName);
            }
            catch (Exception e)
            {
                Console.WriteLine($"При парсинге строки '{str}' произошла ошибка: {e.Message}");
            }
            return null;
        }

        /// <summary>
        ///     Фильтрует лист с клиентами по заданым параметрам. Параметры можно пропустить вставив пустую строчку или null.
        /// </summary>
        /// <param name="clientList">Лист с клиентами для фильтрации.</param>
        /// <param name="surname">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="patronymic">Отчество</param>
        /// <param name="bank">Название банка</param>
        public static List<Client> ClientFilter(List<Client> clientList, string surname, string name, string patronymic,
            string bank)
        {
            return clientList
                .Where(client => string.IsNullOrEmpty(surname) || client.Surname == surname)
                .Where(client => string.IsNullOrEmpty(name) || client.Name == name)
                .Where(client => string.IsNullOrEmpty(patronymic) || client.Patronymic == patronymic)
                .Where(client => string.IsNullOrEmpty(bank) || client.BankName == bank)
                .ToList();
        }

        /// <summary>
        ///     Консольный интерфейс пользователя для фильтации листа клиентов.
        /// </summary>
        /// <param name="clientList">Исходный лист клиентов</param>
        /// <param name="filteredClients">Отфильтрованный лист</param>
        public static void ShowInterfaceClientFilter(List<Client> clientList, out List<Client> filteredClients)
        {
            Console.Write(
                "Отфильтруем данные клиентов! Параметры фильтрации можно пропускать!\nВведите Фамилию клиента: ");
            var surname = Console.ReadLine();
            Console.Write("Введите Имя клиента: ");
            var name = Console.ReadLine();
            Console.Write("Введите Отчество клиента: ");
            var patronimic = Console.ReadLine();
            Console.Write("Введите Банк клиента: ");
            var bankName = Console.ReadLine();
            filteredClients = ClientFilter(clientList, surname, name, patronimic, bankName);
        }

        /// <summary>
        ///     Серелизация объекта в Xml. Объект должен быть серелизуемым.
        /// </summary>
        /// <param name="o">Обьект.</param>
        /// <param name="path">Путь Xml файла.</param>
        public static void SerializeToXml(object o, string path)
        {
            try
            {
                using (var writer = new StreamWriter(path))
                {
                    var serializer = new XmlSerializer(o.GetType());
                    serializer.Serialize(writer, o);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка при чтении {path}: {e.Message}");
            }
        }

        /// <summary>
        ///     Парсинг строки в объект Банк.
        /// </summary>
        /// <param name="str">Исходная строка</param>
        /// <returns>null или Bank</returns>
        public static Bank ParseBankFromString(string str)
        {
            if (str == null || !str.Contains("Банк:"))
                return null;
            return new Bank(str.Replace("Банк:", "").Trim());
        }

        private static void Main()
        {
            var bankList = new List<Bank>();
            // Считывание из файла, заполнение bankList объектами Bank.
            var list = ReadFileToList("input.txt");
            foreach (var item in list)
            {
                var bank = ParseBankFromString(item); //Попытка спарсить и создать объект банка.
                if (bank != null) // Если создался объект - добавляем его в конец коллекции.
                {
                    var tempbank = bankList.Find(x => x.Name == bank.Name);
                    if (tempbank != null)
                        // Если уже существует банк с таким именем, то перемещаем его в конец колекции.
                    {
                        bankList.Remove(tempbank);
                        bankList.Add(tempbank);
                        continue;
                    }
                    bankList.Add(bank);
                    continue;
                }
                var client = ParseClientFromString(item, bankList.Last().Name);
                    //Попытка спарсить и создать объект Client
                if (client != null && bankList.Count > 0)
                    // Если создался объект банка и клиента - добавляем его в только что созданный объект банка.
                {
                    bankList.Last().AddClient(client);
                }
            }

            Console.WriteLine("Из файла были считаны объекты банка с клиентами:");
            foreach (var bank in bankList)
            {
                Console.WriteLine($"\n{bank.Name}:");
                foreach (var client in bank.Clients)
                {
                    Console.WriteLine(client);
                }
            }

            Console.Write(new string('-', Console.WindowWidth));

            List<Client> filteredClients;
            ShowInterfaceClientFilter(bankList.SelectMany(bank => bank.Clients).ToList(), out filteredClients);
                //Фильтрация клиентов

            Console.Write(new string('-', Console.WindowWidth));

            foreach (var client in filteredClients) //Вывод отфильтрованных клиентов.
            {
                Console.WriteLine(client);
            }
            if (filteredClients.Count == 0)
            {
                Console.WriteLine("Клиенты не найдены!");
            }
            Console.WriteLine("Результаты были записаны в clients.xml");
            SerializeToXml(filteredClients, @"clients.xml"); // Запись результатов в xml.
            Console.ReadLine();
        }
    }
}