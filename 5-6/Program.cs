using System;

namespace _5_6
{
    class Program
    {
        //наша диффиренциальная функция
        public static double func(double x, double y)
        {

            return Math.Pow(x,2)+y;
        }
        static void Main(string[] args)
        {
            //начальное условие x и y
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            //шаг 
            double h = double.Parse(Console.ReadLine());
            //таблица значенйи x и y
            double[,] xy = new double[5, 2];

            double xi = 0, yi = 1;
            for(int i = 0; i < 5; i++)
            {
                xy[i, 0] = xi;
                xy[i, 1] = yi;
                xi += h;
                yi += h;
            }

            //таблица значений f
            double[,] f = new double[5, 5];

            for(int i = 0; i<5; i++)
            {
                f[i, 1] = func(xy[i, 0], xy[i, 1]);
                f[i, 2] = func(xy[i, 0] + (h/2), xy[i, 1] + (h/2) * f[i,1]);
                f[i, 3] = func(xy[i, 0] + (h/2), xy[i, 1] + (h/2) * f[i,2]);
                f[i, 4] = func(xy[i, 0] + h, xy[i, 1] + h * f[i,3]);
                f[i, 0] = xy[i, 1] + h / 6 * (f[i, 1] + 2 * (f[i, 2] + f[i, 3]) + f[i, 4]);
            }

            double yn5 = f[4, 0] + h / 720 * (1901 * f[4, 1] - 2774 * f[3, 1] + 2616 * f[2, 1] - 1274 * f[1, 1] + 251 * f[0, 1]);
            Console.WriteLine(yn5);
            Console.ReadKey();
        }
    }
}
