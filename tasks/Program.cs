using System;

namespace tasks
{
    class Program
    {

        static void Main(string[] args)
        {
            int line = int.Parse(Console.ReadLine()); // кол-во уравнений
            double[][] vx = new double[line][];

            //вводим построчно коэффициенты через пробел, последнее значение это значение после знака =
            for (int i = 0; i < line; i++)
            {
                vx[i] = Array.ConvertAll(Console.ReadLine().Split(' '), double.Parse);
            }
            int len = vx[0].GetLength(0);
            double[,] ax = new double[line,len-1];//левая часть матрицы
            double[] b = new double[line];//правая часть
            
            //Разделение на два массива
            for (int i = 0; i <line ; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (j == len - 1)
                    {
                        b[i] = vx[i][j];
                    }
                    else
                    {
                        ax[i,j] = vx[i][j];
                    }
                }

            }
            //Проверка 0 на главной дигонали
            double temp;
            for (int i = 0; i < line; i++)
            {
                if (ax[i, i] == 0)
                {
                    for(int j=0; j<len;j++)
                    {
                        if (i == j || j>=line)
                            continue;
                        if (ax[i,j]!=0 && ax[j, i] != 0)
                        {
                            //меняем первую и вторую строку местами
                            for(int k = 0; k < len-1; k++)
                            {
                                temp = ax[j, k];
                                ax[j, k] = ax[i, k];
                                ax[i, k] = temp;
                            }
                            temp = b[j];
                            b[j] = b[i];
                            b[i] = temp;
                        }
                    }
                }
            }
            //решение
            for (int k = 0; k < line; k++)
            {
                for (int i = k + 1; i < line; i++)
                {
                    if (ax[k, k] == 0)
                    {
                        Console.WriteLine("Нет решения");
                        return;
                    }
                    double m = ax[i, k] / ax[k, k];
                    for (int j = k; j < line; j++)
                    {
                        ax[i, j] -= m * ax[k, j];

                    }
                    b[i] -= m * b[k];
                }
            }
            int q = 0;
            //вывод левой части матрицы после преобразования
            foreach(double i in ax)
            {
                if (q == len-1)
                {
                    q = 0;
                    Console.WriteLine();
                }
                Console.Write(i + " ");
                q++;
                
            }
            double[] x = new double[len-1];//храниться результат
            for (int i = line - 1; i >= 0; i--)
            {
                double f = 0;
                for (int j = i; j < len-1; j++)
                {
                    f += ax[i, j] * x[j];
                }
                x[i] = (b[i] - f) / ax[i, i];
            }
            q = 0;
            Console.WriteLine();
            //вывод ответа
            foreach(double i in x)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
