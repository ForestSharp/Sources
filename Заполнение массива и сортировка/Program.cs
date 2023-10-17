using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alexsandr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите длину массива: ");
            int lengt = Int32.Parse(Console.ReadLine());
            int[] arrayInt = new int[lengt];

            Console.WriteLine();
            
            Console.WriteLine("Массив после заполнения рандомными числами");
            FillingArrayWithRandomNumbers(arrayInt); // заполняем рандомными числами массив
            WriteArray(arrayInt);         
            
            Console.WriteLine("Массив после сортировки");
            sortArray(arrayInt); // сортируем данный массив методом пузырька
            WriteArray(arrayInt);

            Console.ReadLine();
        }
        static void FillingArrayWithRandomNumbers(int[] arrayInt)
        {
            // создаем объект класса Random 
            Random rand = new Random();

            for (int i = 0; i < arrayInt.Length; i++)
            {
                arrayInt[i] = rand.Next(1, 100); // метод Next класса Random
                                                 // позволяет генерировать числа в заданных пределах
            }
        }


        static void WriteArray(int[] arrayInt)
        {
            for (int j = 0; j < arrayInt.Length; j++)
            {
                Console.Write($"{arrayInt[j]} ");
            }
            Console.WriteLine("\n");
        }

        static void sortArray(int[] arrayInt)
        {
            int temp = 0;

            // сортировка методом пузырька
            for (int i = 0; i < arrayInt.Length; i++)
                for (int j = 0; j < arrayInt.Length - 1; j++)
                    if (arrayInt[j] > arrayInt[j + 1])
                    {
                        temp = arrayInt[j];
                        arrayInt[j] = arrayInt[j + 1];
                        arrayInt[j + 1] = temp;
                    }
        }
    }
}
