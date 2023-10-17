using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Georgiy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество чисел для суммирования: ");

            int countInputNumver = Int32.Parse(Console.ReadLine());

            if (countInputNumver % 2 == 0)
            {
                
                int[] arrayNumbers = new int[countInputNumver];
                int[] arraySumNumbers = new int[countInputNumver / 2];

                for (int i = 0; i < arrayNumbers.Length; i++)
                {
                    Console.Write($"Введите {i + 1} целочисленное: ");
                    arrayNumbers[i] = Int32.Parse(Console.ReadLine());
                }

                Console.WriteLine();

                for (int i = 0, g = 0; i < arraySumNumbers.Length; i++, g += 2)
                {
                    arraySumNumbers[i] = arrayNumbers[g] + arrayNumbers[g + 1];
                    Console.WriteLine($"Сумма {g + 1} и {g + 2} равна {arraySumNumbers[i]}");
                }
            }
            else
            {
                Console.WriteLine("Надо ввести число кратное 2");
                Main(args);
            }

            Console.ReadKey();
        }
    }
}
