using System;

namespace Algos.DP.LCS
{
    public class ShortestCommonSuperSequence
    {

        public static void Test()
        {
            UnitTest("nitin", "tin", "nitin");
            UnitTest("nitin", "nitin", "nitin");
            UnitTest("nitin", "natan", "niatian");
            UnitTest("natin", "natan", "natian");
            UnitTest("nitin", "mitin", "nmitin");
        }

        private static void UnitTest(string s1, string s2, string expected)
        {
            var result = SCS(s1, s2);
            Console.WriteLine($"{expected == result}, {expected}={result}");
        }


        //Given two strings, generate a string which has both the strings as subsequences.
        //Length of SCS = s1.Length + s2.Length - LCS
        //Longest Super sequence = s1 + s2, in this LCS is getting counted twice
        //Printing SCS - same as LCS but we should also print the chars which did not match
        public static string SCS(string s1, string s2)
        {
            var dp = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 || j == 0)
                        continue;

                    if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            int r = s1.Length;
            int c = s2.Length;
            string scs = string.Empty;
            while (r > 0 && c > 0)
            {
                if (s1[r - 1] == s2[c - 1])
                {
                    scs = s1[r - 1] + scs;
                    r--;
                    c--;
                }
                else
                {
                    if (dp[r - 1, c] > dp[r, c - 1])
                    {
                        scs = s1[r - 1] + scs;
                        r--;
                    }
                    else
                    {
                        scs = s2[c - 1] + scs;
                        c--;
                    }
                }
            }

            while (r > 0)
            {
                scs = s1[r - 1] + scs;
                r--;
            }

            while (c > 0)
            {
                scs = s1[c - 1] + scs;
                c--;
            }

            return scs;
        }

    }
}
