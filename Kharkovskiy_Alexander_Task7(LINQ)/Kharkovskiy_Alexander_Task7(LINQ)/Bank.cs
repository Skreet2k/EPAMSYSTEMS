using System.Collections.Generic;

namespace Kharkovskiy_Alexander_Task7_LINQ_
{
    public class Bank
    {
        public Bank(){}
        public Bank(string name)
        {
            Name = name;
        }

        public List<Client> Clients { get; } = new List<Client>();

        public string Name { get; }

        public void AddClient(Client clients)
        {
            Clients.Add(clients);
        }
    }
}
