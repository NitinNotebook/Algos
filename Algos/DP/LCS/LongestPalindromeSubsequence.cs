using System;

namespace Algos.DP
{
    //Given a sequence, find the length of its Longest Palindromic Subsequence (LPS).
    public class LongestPalindromeSubsequence
    {
        public static void Test()
        {
            Console.WriteLine("Longest Palindrome Subsequence");
            UnitTest("banana", "anana");
            UnitTest("nitin", "nitin");
            UnitTest("ananab", "anana");
            UnitTest("abcd", "a");
            UnitTest("baaaa", "aaaa");
            UnitTest("naitbin", "nitin");
        }

        public static void UnitTest(string s, string expected)
        {
            //string result = GetLPS(s);
            //Console.WriteLine($"{expected == result}");
            //var result = LPSCount_Rec(s, 0, s.Length - 1);
            var result = LPSCount_BottomUp(s);
            Console.WriteLine($"{expected.Length == result}, {expected.Length} = {result}");
        }

        /// <summary>
        /// We can start processing from the beginning and the end of the sequence. So at any step, we have two options:
        /// If element at the beginning and the end are same, we increment our count by two and make a recursive call for the remaining sequence.
        /// Else We will skip the element either from the beginning or the end to make two recursive calls for the remaining subsequence.
        /// </summary>
        public static int LPSCount_Rec(string s1, int start, int end)
        {
            if (start == end) return 1;
            if (start > end) return 0;

            if (s1[start] == s1[end])
                return 2 + LPSCount_Rec(s1, start + 1, end - 1);

            return Math.Max(LPSCount_Rec(s1, start + 1, end), LPSCount_Rec(s1, start, end - 1));
        }


        public static int LPSCount_BottomUp(string s)
        {
            var dp = new int[s.Length, s.Length];

            for (int j = 0; j < s.Length; j++)
            {
                for (int i = j; i >= 0; i--)
                {
                    if (i == j)
                        dp[i, j] = 1;
                    else if (s[i] == s[j])
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    else
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                }
            }
            return dp[0, s.Length - 1];
        }
    }
}
