using System;

namespace Algos.Subset
{
    /// <summary>
    /// There are n gas stations along a circular circuit
    /// A[i] = Amount of gas available at station i
    /// B[i] = Amount of gas required to from station i to i + 1
    /// Completing a circuit means starting and end at the same station
    /// Return minimum starting station from where you can complete the circuit
    /// </summary>
    public static class GasStationCircuit
    {
        public static void Test()
        {
            UnitTest(new int[] { 6, 5, 3, 5 }, new int[] { 4, 6, 7, 4 }, -1);
            UnitTest(new int[] { 6, 5, 3, 5 }, new int[] { 4, 6, 5, 4 }, 3);
            UnitTest(new int[] { 6, 7, 4, 10, 6, 5 }, new int[] { 5, 6, 7, 8, 6, 4 }, 3);
            UnitTest(new int[] { 1, 2, 3, 4, 5 }, new int[] { 3, 4, 5, 1, 2 }, 3);
        }

        private static void UnitTest(int[] A, int[] B, int expected)
        {
            int result = Solve(A, B);
            Console.WriteLine($"OptimalSol: {result == expected}, result={result}");
            result = Solve_BruteForce(A, B);
            Console.WriteLine($"BruteForce: {result == expected}, result={result}");
        }

        public static int Solve(int[] A, int[] B)
        {
            int n = A.Length;
            int start = 0;

            while (start < n)
            {
                int balance = 0;
                bool isSuccess = true;
                for (int j = start; j < n + start; j++)
                {
                    int i = j % n;
                    balance += A[i] - B[i];
                    if (balance < 0)
                    {
                        start = start == j ? ++start : j;
                        isSuccess = false;
                        break;
                    }
                }
                if (isSuccess) return start;
            }

            return -1;
        }

        private static int Solve_BruteForce(int[] A, int[] B)
        {
            int n = A.Length;
            for (int start = 0; start < n; start++)
            {
                int balance = 0;
                for (int j1 = start; j1 < start + n; j1++)
                {
                    int i = j1 % n;
                    balance += A[i] - B[i];
                    if (balance < 0) break;
                }
                if (balance >= 0) return start;
            }

            return -1;
        }
    }
}
