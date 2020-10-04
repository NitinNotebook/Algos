using System;

namespace Algos.Search
{
    /// <summary>
    /// or Allocate Minimum number of pages
    /// College library has N books,the ith book has A[i] number of pages.
    /// You have to allocate books to B number of students so that 
    ///     maximum number of pages alloted to a student is minimum.
    /// A book will be allocated to exactly one student.
    /// Each student has to be allocated at least one book.
    /// Allotment should be in contiguous order, for example: 
    ///     A student cannot be allocated book 1 and book 3, skipping book 2.
    /// </summary>
    public static class AllocateBooks
    {
        public static void Test()
        {
            UnitTest(new int[] { 12, 34, 67, 90 }, 2, 113);
            UnitTest(new int[] { 5, 17, 100, 11 }, 4, 100);
        }

        private static void UnitTest(int[] A, int b, int expected)
        {
            int actual = Allocate(A, b);
            Console.WriteLine($"{expected == actual}, expected:{expected}, actual:{actual}");
        }

        public static int Allocate(int[] A, int b)
        {
            //number of students more than number of books, no valid solution
            if (A == null || A.Length < b) return -1; 

            int start = 0;
            int end = 0;
            int result = -1;

            for (int i = 0; i < A.Length; i++)
            {
                start = Math.Max(start, A[i]);
                end += A[i];
            }

            //number of books equal to number of students, only one solution possible
            if (A.Length == b) return start; 

            while (end >= start)
            {
                int mid = (start + end) / 2;
                if (IsValid(A, b, mid))
                {
                    result = mid;
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }
            }
            return result;
        }

        private static bool IsValid(int[] books, int students, int maxPages)
        {
            int sCount = 1;
            int pageCount = 0;
            for (int i = 0; i < books.Length; i++)
            {
                pageCount += books[i];
                if (pageCount > maxPages)
                {
                    pageCount = books[i];
                    sCount++;
                    if (sCount > students) return false;
                }
            }

            return true;
        }
    }
}
