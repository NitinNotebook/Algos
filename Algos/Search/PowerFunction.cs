using System;

namespace Algos.Search
{
    public static class PowerFunction
    {
        public static void Test()
        {
            double x = double.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Pow(x, n));
        }

        static double Pow(double x, int n)
        {
            if (n == 0) return 1;

            double pow = Pow(x, n / 2);


            if (n % 2 == 0)
            {
                return pow * pow;
            }
            else
            {
                if (n < 0)
                    return (1 / x) * pow * pow;
                else
                    return x * pow * pow;
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
