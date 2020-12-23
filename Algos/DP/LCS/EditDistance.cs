using System;

namespace Algos.DP.LCS
{
    /// <summary>
    /// Edit Distance - Levenshtein
    /// Minimum number of single-character edits(i.e.insertions, deletions, or substitutions) required to change one word into the other
    /// </summary>
    public static class EditDistance
    {
        public static void Test()
        {
            Console.WriteLine("-----Edit Distance----");
            UnitTest("baa", "a", 2);
            UnitTest("nitin", "natan", 2);
            UnitTest("abcd", "efgh", 4);
            UnitTest("aabbccdd", "abbccdd", 1);
        }

        private static void UnitTest(string s1, string s2, int expected)
        {
            //var result = EditDistance_Rec(s1, s2, s1.Length - 1, s2.Length - 1);
            var result = EditDistance_Iter(s1, s2);
            Console.WriteLine($"{expected == result}, {expected}={result}");
        }


        private static int EditDistance_Iter(string s1, string s2)
        {
            int n1 = s1.Length + 1;
            int n2 = s2.Length + 1;
            var dp = new int[n1, n2];

            for (int i = 0; i < n1; i++)
            {
                for (int j = 0; j < n2; j++)
                {
                    if (i == 0)
                        dp[i, j] = j;
                    else if (j == 0)
                        dp[i, j] = i;
                    else if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j], dp[i, j - 1]);
                        dp[i, j] = Math.Min(dp[i, j], 1 + dp[i - 1, j - 1]);
                    }
                }
            }

            return dp[n1 - 1, n2 - 1];
        }


        private static int EditDistance_Rec(string s1, string s2, int i, int j)
        {
            if (i < 0)
                return j + 1;

            if (j < 0)
                return i + 1;

            if (s1[i] == s2[j])
            {
                return EditDistance_Rec(s1, s2, i - 1, j - 1);
            }

            int r1 = 1 + EditDistance_Rec(s1, s2, i - 1, j - 1);
            int r2 = 1 + EditDistance_Rec(s1, s2, i - 1, j);
            int r3 = 1 + EditDistance_Rec(s1, s2, i, j - 1);
            return 1 + Math.Min(r1, Math.Min(r2, r3));
        }
    }
}
