using Algos.Search;
using Algos.Sort;
using System;

namespace Algos
{
    class Program
    {
        static void Main(string[] args)
        {
            //int x = int.Parse(Console.ReadLine());
            //int n = int.Parse(Console.ReadLine());
            //Console.WriteLine(Pow(x, n));
            FindAPeak.Test();
        }
        
        static int Pow(int x, int n)
        {
            if (n == 0) return 1;

            int pow = Pow(x, n / 2);
           
            if (n % 2 == 0)
            {
                return pow * pow;
            }
            else
            {
                return x * pow * pow ;
            }
        }

        static void Pow2(int x, int n)
        {
            int value = 1;
            for (int i = 0; i < n; i++)
            {
                value *= x;
            }
        }
    }
}
