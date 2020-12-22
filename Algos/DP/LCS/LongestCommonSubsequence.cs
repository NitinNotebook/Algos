using System;

namespace Algos.DP.LCS
{
    /// <summary>
    /// Biologists use the longest common subsequence to find similarities in DNA strands. 
    /// They can use this to tell how similar two animals or two diseases are. 
    /// The longest common subsequence is being used to find a cure for multiple sclerosis.
    /// </summary>
    public class LongestCommonSubsequence
    {

        public static void Test()
        {
            UnitTest("nitin", "tin", "tin");
            UnitTest("nitin", "nitin", "nitin");
            UnitTest("nitin", "natan", "ntn");
            UnitTest("natin", "natan", "natn");
            UnitTest("nitin", "mitim", "iti");
        }

        private static void UnitTest(string s1, string s2, string expected)
        {
            var dp = new int[s1.Length + 1, s2.Length + 1];
            var result = LCS(s1, s2);
            //LCS_Recursive(s1, s2, s1.Length, s2.Length, dp);
            //var result = DpToLCS(s1, s2, dp);
            Console.WriteLine($"{expected == result}, {expected}={result}");
        }


        public static string LCS(string s1, string s2)
        {
            var dp = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        continue;
                    }

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
            string lcs = string.Empty;
            while (r > 0 && c > 0)
            {
                if (s1[r - 1] == s2[c - 1])
                {
                    lcs = s1[r - 1] + lcs;
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
            return lcs;
        }

        private static string DpToLCS(string s1, string s2, int[,] dp)
        {
            int r = s1.Length;
            int c = s2.Length;
            string lcs = string.Empty;
            while (r > 0 && c > 0)
            {
                if (s1[r - 1] == s2[c -1])
                {
                    lcs = s1[r -1] + lcs;
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
            return lcs;
        }


        public static int LCS_Recursive(string s1, string s2, int i, int j, int[,] dp)
        {
            if (i == 0 || j == 0) return 0;

            if (dp[i, j] > 0) return dp[i, j];

            if (s1[i - 1] == s2[j - 1])
            {
                dp[i, j] = 1 + LCS_Recursive(s1, s2, i - 1, j - 1, dp);
                return dp[i, j];
            }

            var a1 = LCS_Recursive(s1, s2, i - 1, j, dp);
            var a2 = LCS_Recursive(s1, s2, i, j - 1, dp);

            dp[i, j] = Math.Max(a1, a2);

            return dp[i, j];
        }
    }
}
