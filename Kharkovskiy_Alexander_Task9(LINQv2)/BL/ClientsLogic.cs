using System;
using System.Collections.Generic;
using System.Linq;
using Servises;

namespace BL
{
    /// <summary>
    /// Клас для обработки данных с UL.
    /// </summary>
    public class ClientsLogic
    {
        /// <summary>
        /// Создание банка с клиентами.
        /// </summary>
        /// <param name="clients">Лист с полями клиентов/</param>
        /// <returns>Лист объектов Bank.</returns>
        private List<Bank> CreateBanksWithClients(List<List<string>> clients)
        {
            var banks = new List<Bank>();
            foreach (var client in clients)
            {
                if (banks.FirstOrDefault(bank => bank.Name == client[4]) == null)
                    banks.Add(new Bank(client[4]));
                DateTime dt;
                if(DateTime.TryParse(client[3], out dt))
                banks.First(bank => bank.Name == client[4]).AddClient(new Client(client[0], client[1],client[2], dt, client[4] ));
            }
            return banks;
        }
        /// <summary>
        /// Сохранение листа с полями клиентов в Xml файл.
        /// </summary>
        /// <param name="clients">Лист с полями клиентов/</param>
        /// <param name="path">Путь к файлу.</param>
        public void SafeListOfClientToXml(List<List<string>> clients, string path)
        {
            var ds = new DAL.DataServices();
            ds.SafeToXml(CreateBanksWithClients(clients), path);
        }
        /// <summary>
        /// Сохранение листа с полями клиентов в текстовый файл.
        /// </summary>
        /// <param name="clients">Лист с полями клиентов/</param>
        /// <param name="path">Путь к файлу.</param>
        public void SafeListOfClientToTxt(List<List<string>> clients, string path)
        {
            var ds = new DAL.DataServices();
            ds.SafeToTxt(CreateBanksWithClients(clients), path);
        }
    }
}
