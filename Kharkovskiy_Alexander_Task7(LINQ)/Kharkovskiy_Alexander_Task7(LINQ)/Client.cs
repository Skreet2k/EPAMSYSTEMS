using System;

namespace Kharkovskiy_Alexander_Task7_LINQ_
{
    public class Client
    {
        public Client(string surname, string name, string patronymic, DateTime dateOfBirth, string bankName)
        {
            Name = name;
            Patronymic = patronymic;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            BankName = bankName;
        }
        public Client() { }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Surname { get; set; }
        public string BankName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic} {DateOfBirth.ToShortDateString()} {BankName}";
        }
    }
}
