using System;

namespace Algos.DP.LCS
{
    /// <summary>
    /// Give three strings ‘m’, ‘n’, and ‘p’, write a method to find out if ‘p’ has been formed by interleaving ‘m’ and ‘n’. 
    /// ‘p’ would be considered interleaving ‘m’ and ‘n’ if it contains all the letters from ‘m’ and ‘n’ and the order of letters is preserved too.
    /// </summary>
    public static class StringsInterleaving
    {
        public static void Test()
        {
            Console.WriteLine("Strings Interleaving");
            UnitTest("aabbcc", "axyz", "aaaxbbyzcc", true);
            UnitTest("aabbcc", "axyz", "xyzaabbcca", false);
            UnitTest("nit", "in", "nitin", true);
            UnitTest("abd", "cef", "abcdef", true);
            UnitTest("abd", "cef", "abcbef", false);

        }

        public static void UnitTest(string s1, string s2, string s3, bool expected)
        {
            //bool actual = IsInterleaving(s1, s2, s3, s1.Length - 1, s2.Length - 1, s3.Length - 1);
            bool actual = IsInterleaving(s1, s2, s3);
            Console.WriteLine($"{expected == actual}, {expected}={actual}");
        }

        public static bool IsInterleaving(string s1, string s2, string s3)
        {
            var dp = new bool[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 && j == 0)
                        dp[i, j] = true;
                    else
                    {
                        if (j > 0 && s2[j - 1] == s3[i + j - 1])
                            dp[i, j] = dp[i, j - 1];

                        if (i > 0 && s1[i - 1] == s3[i + j - 1])
                            dp[i, j] = dp[i, j] || dp[i - 1, j];
                    }
                }
            }

            return dp[s1.Length, s2.Length];
        }

        public static bool IsInterleaving(string s1, string s2, string s3, int i, int j , int k)
        {
            if (i < 0 && j < 0 && k < 0) return true;

            if (k < 0) return false;

            bool result = false;
            if (i >= 0 && s1[i] == s3[k])
                result = IsInterleaving(s1, s2, s3, i - 1, j, k - 1);

            if (j >= 0 && s2[j] == s3[k])
                result = result || IsInterleaving(s1, s2, s3, i, j - 1, k - 1);

            return result;
        }
    }
}
