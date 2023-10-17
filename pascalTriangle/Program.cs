using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите высоту треугольника: ");
            int heightTreangle = Int32.Parse(Console.ReadLine()); // Высота треугольника

            double[,] treanglePascal = new double[heightTreangle, heightTreangle]; // Двумерный массив для хранениния
                                                                                   // биноминальных коэффициентов

            FillingArray(treanglePascal, heightTreangle); // Заполнение двумерного массива биноминальными коэффициентами
            Console.WriteLine("\nТреугольник Паскаля:\n");
            OutputArray(treanglePascal, heightTreangle); // Вывод значений двумерного массива

            Console.ReadLine();
        }

        // Функция по вычеслению факториала
        static double FactorialRec(double number)
        {
            if (number == 0)
                return 1;

            return number * FactorialRec(number - 1);
        }

        // функция по вычислению биноминального коэффициента
        static double BinomialСoefficient(double n, double k)
        {
            double res = 0;
            double nF = FactorialRec(n);

            res = nF / (FactorialRec(k) * FactorialRec((n - k)));

            return res;
        }

        // Функция по заполнению двумерного массива биноминальными коэффициентами
        static void FillingArray(double[,] treanglePascal, int heightTreangle)
        {
            for (int i = 0; i < heightTreangle; i++)
                for (int j = 0; j <= i; j++)
                    treanglePascal[i, j] = BinomialСoefficient(i, j);
        }

        // Функция по выводу двумерного массива
        static void OutputArray(double[,] treanglePascal, int heightTreangle)
        {
            for (int i = 0; i < heightTreangle; i++)
            {
                for (int j = 0; j <= i; j++)
                    Console.Write($"{treanglePascal[i, j]} ");

                Console.WriteLine();
            }
        }
    }
}
