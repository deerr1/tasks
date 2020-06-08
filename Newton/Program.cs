using System;

namespace Newton
{
    class Program
    {
        public static int fact(int n)
        {
            int res = 1;
            while (n != 1)
            {
                res = res * n;
                n = n - 1;
            }
            return res;
        }
        static void Main(string[] args)
        {
            //кол-во узлов
            int i = int.Parse(Console.ReadLine());

            double[] x = new double[i];
            //ввод значений узлов 1 и 2
            Console.WriteLine("Введите x1 и x2");
            x[0] = double.Parse(Console.ReadLine());
            x[1] = double.Parse(Console.ReadLine());
            //x[0]= 0.385;
            //x[1]= 0.585;
            //x[2] = 0.785;
            //x[3] = 0.985;
            double h = Math.Round(x[1] - x[0], 3);
            double[,] f = new double[i,i];
            //ввод f(x)
            Console.WriteLine("Введите значение f(x) построчно");
            for (int j = 0; j < i; j++)
            {
                f[j, 0] = double.Parse(Console.ReadLine());
            }
            //f[0, 0] = 1.93943;
            //f[1, 0] = 2.22857;
            //f[2, 0] = 2.76519;
            //f[3, 0] = 3.68079;
            //заполнение разностью f
            for (int k = 0; k < i - 1; k++)
            {
                for (int j = 0; j < i - k - 1; j++)
                {
                    f[j, k + 1] = f[j + 1, k] - f[j, k];
                }
            }
           
            //вычисление остальных x
            if (x.Length != 2)
            {
                for (int j = 2; j < i; j++)
                {
                    x[j] = x[j - 1] + h;
                }
            }

            //ввод Xn
            Console.WriteLine("Введит Xn");
            double Xn = double.Parse(Console.ReadLine());
            //double Xn = 0.885;
            double q = (Xn - x[x.Length - 1]) / h;
            double p = f[i-1,0];
            for(int j = 1; j<i; j++)
            {
                double s=q;
                for (int k=1; k<j; k++)
                {
                    s *= (q - k + 1);
                }
                p += (s / fact(j)) * f[j, i - j - 1];
            }

            Console.WriteLine(p);
            Console.ReadKey();
        }
    }
}
