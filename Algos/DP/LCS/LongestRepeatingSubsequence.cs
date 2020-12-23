using System;

namespace Algos.DP.LCS
{
    /// <summary>
    /// Given a sequence, find the length of its longest repeating subsequence (LRS). 
    /// A repeating subsequence will be the one that appears at least twice in the original sequence and is not overlapping
    /// (i.e. none of the corresponding characters in the repeating subsequences have the same index).
    /// </summary>
    public static class LongestRepeatingSubsequence
    {
        public static void Test()
        {
            Console.WriteLine("------Longest Repeating Subsequence----");
            UnitTest("baa", "a");
            UnitTest("bbaabbaa", "bbaa");
            UnitTest("baadxx", "ax");
            UnitTest("abcd", "");
            UnitTest("aaaa", "aaa");
            UnitTest("aabdbcec", "abc");
        }

        private static void UnitTest(string s1, string expected)
        {
            var result = LRS_rec(s1, s1.Length - 1, s1.Length - 1);
            //var result = LRS(s1);
            Console.WriteLine($"{expected == result}, {expected}={result}");
        }

        public static string LRS(string s1)
        {
            int n = s1.Length + 1;
            var dp = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0) continue;

                    if (i != j && s1[i - 1] == s1[j - 1])
                    {
                        dp[i, j] = 1 + dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    }
                }
            }

            int r = n - 1;
            int c = n - 1;
            string lrs = string.Empty;
            while (r > 0 && c > 0)
            {
                if (r != c && s1[r - 1] == s1[c - 1])
                {
                    lrs = s1[r - 1] + lrs;
                    r--;
                    c--;
                }
                else
                {
                    if (dp[r - 1, c] > dp[r, c - 1])
                    {
                        r--;
                    }
                    else
                    {
                        c--;
                    }
                }
            }
            return lrs;
        }


        public static string LRS_rec(string s1, int i, int j)
        {
            if (i < 0 || j < 0) return "";

            if (i != j && s1[i] == s1[j])
            {
                return LRS_rec(s1, i - 1, j - 1) + s1[i];
            }

            var a1 = LRS_rec(s1, i - 1, j);
            var a2 = LRS_rec(s1, i, j - 1);

            return a1.Length > a2.Length ? a1 : a2;

        }
    }
}
