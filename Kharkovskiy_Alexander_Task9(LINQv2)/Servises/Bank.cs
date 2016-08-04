using System.Collections.Generic;
using System.Linq;

namespace Servises
{
    /// <summary>
    /// Объект Банк.
    /// </summary>
    public class Bank
    {
        private string _name;
        /// <summary>
        /// Конструктор по умолчанию для сериализации.
        /// </summary>
        public Bank() { }
        /// <summary>
        /// Констуктор банка.
        /// </summary>
        /// <param name="name">Имя банка.</param>
        public Bank(string name)
        {
            Name = name;
        }
        /// <summary>
        /// List клиентов принадлежащих банку.
        /// </summary>
        public List<Client> Clients { get; private set; } = new List<Client>();

        /// <summary>
        /// Имя банка. При изменении имени банка - автоматически меняется имя банка у клиентов.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set {
                _name = value;
                ChangeName(value);
            }
        }

        /// <summary>
        /// Добавление клиента в банк.
        /// </summary>
        /// <param name="client">Объект Клиент.</param>
        public void AddClient(Client client)
        {
            Clients.Add(client);
        }
        /// <summary>
        /// Добавление нескольких клиентов.
        /// </summary>
        /// <param name="clients">Коллекция клиентов.</param>
        public void AddClientRange(IEnumerable<Client> clients)
        {
            Clients.AddRange(clients);
            Clients = (List<Client>)Clients.Distinct(); // Удаление дубликатов.
        }

        private void ChangeName(string newName)
        {
            foreach (var client in Clients)
            {
                client.BankName = newName;
            }
        }
        /// <summary>
        /// Строковое представление объекта.
        /// </summary>
        /// <returns>Выводит имя банка и количество клиента.</returns>
        public override string ToString()
        {
            return $"{Name} с {Clients.Count} клиентами";
        }
    }
}
