using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[10];

        Console.WriteLine("Введите 10 целых чисел:");
        for (int i = 0; i < 10; i++)
        {
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                array[i] = number;
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                i--; // Повторно запросить ввод
            }
        }

        int maxIndex = array.Select((value, index) => new { Value = value, Index = index })
                           .OrderByDescending(x => x.Value)
                           .First()
                           .Index;

        // Обмен местами первого элемента и максимального элемента
        int temp = array[0];
        array[0] = array[maxIndex];
        array[maxIndex] = temp;

        Console.WriteLine("Массив после обмена:");
        Console.WriteLine(string.Join(", ", array));
    }
}
