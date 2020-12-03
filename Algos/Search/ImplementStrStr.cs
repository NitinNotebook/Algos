using System;

namespace Algos.Search
{
    class ImplementStrStr
    {

        public static void Test()
        {
            UnitTest("hello", "ll", 2);
        }

        private static void UnitTest(string haystack, string needle, int expected)
        {
            int result = StrStr("hello", "ll");
            Console.Write($"{expected == result}");
        }

        public static int StrStr(string haystack, string needle)
        {
            if (haystack.Length < needle.Length)
                return -1;

            if (needle.Length == 0) return 0;
            if (needle.Length == haystack.Length && needle == haystack) return 0;

            const long prime = 5197;

            long keyHash = CreateHash(needle, prime);
            long rollingHash = CreateHash(haystack.Substring(0, needle.Length), prime);
            if (keyHash == rollingHash) return 0;

            for (int i = needle.Length; i < haystack.Length; i++)
            {
                char curChar = haystack[i];
                char delChar = haystack[i - needle.Length];
                rollingHash = RollHash(prime, rollingHash, curChar, delChar, needle.Length - 1);

                if (keyHash == rollingHash)
                {
                    return i + 1 - needle.Length;
                }
            }
            return -1;
        }

        private static long RollHash(long prime, long hash, char curChar, char delChar, int length)
        {
            long charValue = (delChar - 'a') * (long)Math.Pow(26, length) % prime;
            hash -= (charValue % prime);
            hash *= 26;
            charValue = (curChar - 'a') % prime;
            hash += charValue % prime;
            return hash;
        }


        private static long CreateHash(string str, long prime)
        {
            long hash = 0;
            for (int i = str.Length - 1; i >= 0; i--)
            {
                long charValue = ((str[str.Length - 1 - i] - 'a') * (long)Math.Pow(26, i)) % prime;
                hash = (hash + charValue) % prime;
            }
            return hash;
        }
    }
}
