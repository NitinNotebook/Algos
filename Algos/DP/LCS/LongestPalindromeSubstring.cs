using System;

namespace Algos.DP.LCS
{
    //Given a sequence, find the length of its Longest Palindromic Subsequence (LPS).
    public class LongestPalindromeSubstring
    {
        public static void Test()
        {
            Console.WriteLine("Longest Palindromic Substring");
            UnitTest("banana", "anana");
            UnitTest("nitin", "nitin");
            UnitTest("ananab", "anana");
            UnitTest("abcd", "a");
            UnitTest("baaaa", "aaaa");
            UnitTest("aaa", "aaa");
        }

        public static void UnitTest(string s, string expected)
        {
            string result = GetLPS(s);
            Console.WriteLine($"{expected == result}");
            //var result = LPSCount_Rec(s, 0, s.Length - 1);
            //var result = LPSLength_Rec(s, 0, s.Length - 1);
            //Console.WriteLine($"{expected.Length == result}, {expected.Length} = {result}");
        }

        public static string GetLPS(string s)
        {
            var dp = new bool[s.Length, s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                dp[i, i] = true;
            }

            int maxRow = 0;
            int maxCol = 0;

            for (int col = 1; col < s.Length; col++)
            {
                for (int row = col - 1; row >= 0; row--)
                {
                    if (s[row] != s[col]) continue;

                    dp[row, col] = col - row == 1 || dp[row + 1, col - 1];

                    if (dp[row, col] && col - row > maxCol - maxRow)
                    {
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }
            return s.Substring(maxRow, maxCol + 1 - maxRow);
        }

        public static int LPSLength_Rec(string s1, int start, int end)
        {
            if (start == end) return 1;
            if (start > end) return 0;

            if (s1[start] == s1[end])
            {
                var r1 = LPSLength_Rec(s1, start + 1, end - 1);
                if (r1 == end - start - 1) //length from recursive call will be without first and last char
                    return 2 + r1;
            }

            return Math.Max(LPSLength_Rec(s1, start + 1, end), LPSLength_Rec(s1, start, end - 1));
        }

        /// Given a string, find the total number of palindromic substrings in it.
        public static int LPSCount(string s1)
        {
            int count = 0;

            var dp = new bool[s1.Length, s1.Length];

            for (int i = 0; i < s1.Length; i++)
            {
                dp[i, i] = true;
                count++;
            }

            for (int col = 1; col < s1.Length; col++)
            {
                for (int row = col - 1; row >= 0; row--)
                {
                    if (s1[row] != s1[col]) continue;

                    //col-row = 1 --> two length string with same characters at both positions
                    dp[row, col] = col - row == 1 || dp[row + 1, col - 1];

                    if (dp[row, col]) count++;
                }
            }

            return count;
        }
    }
}
