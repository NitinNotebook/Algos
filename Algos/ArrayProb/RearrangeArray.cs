using System;
using System.ComponentModel.DataAnnotations;

namespace Algos.ArrayProb
{
    //Rearrange an array so that arr[i] becomes arr[arr[i]] 
    public class RearrangeArray
    {
        public static void Test()
        {

            /* arr[arr[0]] is 1 so arr[0] in output array is 1
             * arr[arr[1]] is 0 so arr[1] in output array is 0
             * arr[arr[2]] is 3 so arr[2] in output array is 3
             * arr[arr[3]] is 2 so arr[3] in output array is 2
             */
            //UnitTest(new int[] { 3, 2, 0, 1 }, new int[] { 1, 0, 3, 2 });

            /* arr[arr[0]] is 3 so arr[0] in output array is 3
             * arr[arr[1]] is 4 so arr[1] in output array is 4
             * arr[arr[2]] is 2 so arr[2] in output array is 2
             * arr[arr[3]] is 0 so arr[3] in output array is 0
             * arr[arr[4]] is 1 so arr[4] in output array is 1
             */
            //UnitTest(new int[] { 4, 0, 2, 1, 3 }, new int[] { 3, 4, 2, 0, 1 });
            //UnitTest(new int[] { 0, 1, 2, 3 }, new int[] { 0, 1, 2, 3 });


            UnitTest_Alternate(new int[] { 1, 2, 3, 4, 5 }, new int[] { 5, 1, 4, 2, 3 });
            UnitTest_Alternate(new int[] { 1, 2, 3, 4, 5, 6 }, new int[] { 6, 1, 5, 2, 4, 3 });
            UnitTest_Alternate(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110 }, new int[] { 110, 10, 100, 20, 90, 30, 80, 40, 70, 50, 60 });
        }

        public static void UnitTest(int[] A, int[] expected)
        {
            ReArrange(A, 9);
            var result = string.Join(',', A);
            var strExpected = string.Join(',', expected);
            Console.WriteLine($"{result == strExpected}");
            Console.WriteLine($"{strExpected}");
            Console.WriteLine($"{result}");
            Console.WriteLine("----------------");
        }

        public static void ReArrange(int[] A, int n)
        {
            for (int i = 0; i < A.Length; i++)
            {
                //-> A[A[i]] or b could have been modified (or multiplied by n) in previous iterations hence first modulo with n
                //a = a + (b%n) *n                 
                A[i] += (A[A[i]] % n) * n;
            }

            for (int i = 0; i < A.Length; i++)
            {
                A[i] /= n;
            }
        }

        public static void UnitTest_Alternate(int[] A, int[] expected)
        {
            ReArrangeAlternate(A);
            var result = string.Join(',', A);
            var strExpected = string.Join(',', expected);
            Console.WriteLine($"{result == strExpected}");
            Console.WriteLine($"{strExpected}");
            Console.WriteLine($"{result}");
            Console.WriteLine("----------------");
        }


        // 1, 2, 3, 4, 5, 6
        public static void ReArrangeAlternate_2Pointer(int[] A)
        {
            int i = 0;
            int j = A.Length - 1;
            int[] A_dup = new int[A.Length];

            for (int k = 0; k < A.Length; k++)
            {
                if (k % 2 == 0)
                    A_dup[k] = A[j--];
                else
                    A_dup[k] = A[i++];
            }

            for (i = 0; i < A.Length; i++)
            {
                A[i] = A_dup[i];
            }
        }

        public static void ReArrangeAlternate(int[] A)
        {
            int min = 0;
            int max = A.Length - 1;
            int n = A.Length;
            int maxEle = A[n - 1] + 1;

            for (int i = 0; i < n; i++)
            {
                if (i % 2 == 0)
                {
                    A[i] = A[i] + (A[max--] % maxEle) * maxEle;
                }
                else
                {
                    A[i] = A[i] + (A[min++] % maxEle) * maxEle;
                }
            }

            for (int i = 0; i < n; i++)
            {
                A[i] /= maxEle;
            }
        }
    }
}
