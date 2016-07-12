using System;

namespace Task4
{
    internal class Program
    {
        private static void Main()
        {
            var employee = Employee.AddNewEployeeFromConsole();
            Console.WriteLine($"Новый сотрудник {employee.Surname} {employee.Name} {employee.Patronymic}.\nДень рождения: {employee.Birthday:dd  MMMM yyyy}\nВозраст: {employee.Age()}\nЗанимаемая должность {employee.Possition}\nСтаж {employee.Experience}");
            Console.Read();
        }
    }
}
