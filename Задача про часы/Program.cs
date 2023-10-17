using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anastasia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите сколько часов: ");
            int hourHand = Int32.Parse(Console.ReadLine());
            Console.Write("Введите сколько минут: ");
            int minuteHand = Int32.Parse(Console.ReadLine());

            // преобразовываем часы и минуты в их нахождения в градусах
            int minuteHandAngle = minuteHand * 6;
            int clockwiseAngle = (int)(hourHand * 30 + Math.Floor(minuteHand * 0.5));

            int degreesPassed = 0; // пройдено градусов минутной стрелкой
            double time = 0; // результат в минутах


            while (minuteHandAngle != clockwiseAngle)
            {
                if (minuteHandAngle == 360)
                {
                    minuteHandAngle = 0;
                }
                if(clockwiseAngle == 360)
                {
                    clockwiseAngle = 0;
                }

                minuteHandAngle++;
                degreesPassed++;

                if(minuteHandAngle % 12 == 0)
                {
                    clockwiseAngle++;
                }
            }
            time = Math.Ceiling(degreesPassed / 6.0);

            Console.WriteLine($"Должно пройти {time} минут(а,ы)");
            Console.ReadLine();
        }
    }
}
