using System;
using Task1;
using Task3;


namespace Task4
{
    internal class Employee: User
    {
        public Employee(string surname, string name, string patronymic, DateTime birthday, string possition, double experience) : base(surname, name, patronymic, birthday)
        {
            Possition = possition;
            Experience = experience;
        }

        public string Possition { get; set; }
        public double Experience { get; }

        public static Employee AddNewEployeeFromConsole()
        {
            Console.Write("Добавить нового сотрудника.\nВведите фамилию: ");
            var surname = Console.ReadLine();
            Console.Write("Введите имя: ");
            var name = Console.ReadLine();
            Console.Write("Введите отчество: ");
            var patronymic = Console.ReadLine();
            Console.WriteLine("Теперь разберемся с датой рождения!");
            var birthday = Task3.DateHelper.ReadDateOfBirthdayFormConsole();
            Console.Write("Занимаемая должность: ");
            var position = Console.ReadLine();
            var experience = DoubleHelper.ReadDoubleFormConsole("Стаж работы: ", true);
            return new Employee(surname, name, patronymic, birthday, position, experience);
        }
    }
}
