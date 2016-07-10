using System;

namespace Task3
{
    internal class Program
    {
        private static void Main()
        {
            Console.Write("Создадим экземпляр класса DynamicArray.\tВведите значение Capacity или оставте поле пустым для значения по умолчанию:\tCapacity = ");
            int capacity;
            var dynamicArray = new DynamicArray<string>();
            if (!int.TryParse(Console.ReadLine(), out capacity))
            {
                Console.WriteLine($"Capacity = {dynamicArray.Capacity}");
            }
            Console.WriteLine("Введите элементы массива DynamicArray<string> через enter. Введите пустую строчку для прекращения.");
            for (var i = 0;; i++)
            {
                Console.Write($"dynamicArray[{i}] = ");
                var str = Console.ReadLine();
                if (str == "")
                    break;
                dynamicArray.Add(str);
            }
          
            Console.WriteLine($"Вы задали массив, число элементов которого Count = {dynamicArray.Length}, Capacity = {dynamicArray.Capacity}, а список элементов:");
            for (var i = 0; i < dynamicArray.Length; i++)
            {
                Console.WriteLine($"dynamicArray[{i}] = {dynamicArray[i]}");
            }
            Console.ReadLine();
        }
    }
}
