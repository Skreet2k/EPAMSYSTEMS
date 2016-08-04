using System;

namespace Servises
{
    /// <summary>
    /// Объект Клиент.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Конструктор клиента.
        /// </summary>
        /// <param name="surname">Фамилия.</param>
        /// <param name="name">Имя.</param>
        /// <param name="patronymic">Отчество.</param>
        /// <param name="dateOfBirth">Дата рождения.</param>
        /// <param name="bankName">Имя банка.</param>
        public Client(string surname, string name, string patronymic, DateTime dateOfBirth, string bankName)
        {
            Name = name;
            Patronymic = patronymic;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            BankName = bankName;
        }
        /// <summary>
        /// Конструктор по умолчанию для сериализации.
        /// </summary>
        public Client() { }
        /// <summary>
        /// Фамилия клиента.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string Patronymic { get; set; }
        /// <summary>
        /// Отчество клиента.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Имя банка.
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Строковое представление объекта.
        /// </summary>
        /// <returns>Выводит фамилия имя отчество дата рождения имя банка.</returns>
        public override string ToString()
        {
            return $"{Surname} {Name} {Patronymic} {DateOfBirth.ToShortDateString()} {BankName}";
        }
    }
}
