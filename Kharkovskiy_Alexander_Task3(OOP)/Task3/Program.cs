using System;

namespace Task3
{
    internal class Program
    {
        private static void Main()
        {
            var user = User.AddNewUserFromConsole();
            Console.WriteLine($"{user.Surname} {user.Name} {user.Patronymic}.\nДень рождения: {user.Birthday:dd  MMMM yyyy}\nВозраст: {user.Age()}");
            Console.ReadLine();
        }
    }
}
