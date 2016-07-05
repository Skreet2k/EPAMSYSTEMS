using System;

namespace Task3
{
    public class User
    {
        public User(string surname, string name, string patronymic, DateTime birthday)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Birthday = birthday;
        }
        public string Name { get; set; }
        public string Surname { get; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; }

        public int Age()
        {
            var age = DateTime.Now.Year - Birthday.Year;
            if (DateTime.Now.Month < Birthday.Month ||
                (DateTime.Now.Month == Birthday.Month && DateTime.Now.Day < Birthday.Day)) age--;
            return age;
        }

        public static User AddNewUserFromConsole()
        {
            Console.Write("Добавим нового юзера? Хорошо!\nВведите фамилию: ");
            var surname = Console.ReadLine();
            Console.Write("Введите имя: ");
            var name = Console.ReadLine();
            Console.Write("Введите отчество: ");
            var patronymic = Console.ReadLine();
            Console.WriteLine("Теперь разберемся с датой рождения!");
            var birthday = DateHelper.ReadDateOfBirthdayFormConsole();
            return new User(surname, name, patronymic, birthday);
        }

    }
}
