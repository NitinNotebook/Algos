using System;
using System.Collections.Generic;

namespace Algos.StackProb
{
    /// <summary>
    /// Write a class StockSpanner which collects daily price quotes for some stock, and returns the span of that stock's price for the current day.
    /// The span of the stock's price today is defined as the maximum number of consecutive days (starting from today and going backwards) for which the price of the stock was less than or equal to today's price.
    /// For example, prices: [100, 80, 60, 70, 60, 75, 85], spans: [1, 1, 1, 2, 1, 4, 6].
    /// </summary>
    public class StockSpanner
    {
        public static void Test()
        {
            var stockPrice = new int[] { 100, 80, 60, 70, 60, 75, 85 };
            var priceSpan = new int[] { 1, 1, 1, 2, 1, 4, 6 };
            //UnitTest(stockPrice, priceSpan);

            stockPrice = new int[] { 28, 14, 28, 35, 46, 53, 66, 80, 87, 88 };
            priceSpan = new int[] { 1, 1, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            UnitTest(stockPrice, priceSpan);

        }

        private static void UnitTest(int[] stockPrice, int[] priceSpan)
        {
            var ss = new StockSpanner();
            for (int i = 0; i < stockPrice.Length; i++)
            {
                var result = ss.Next(stockPrice[i]);
                Console.WriteLine($"{priceSpan[i] == result}, {priceSpan[i]}, {result}");
            }
        }


        Stack<int[]> prices = new Stack<int[]>();
        int counter = 0;
        public int Next(int price)
        {
            int[] nse = null;

            while (prices.Count > 0 && price >= prices.Peek()[1])
            {
                nse = prices.Pop();
            }

            int start = nse != null ? nse[0] : counter;
            prices.Push(new int[] { start, price });
            counter++;
            return counter - start;
        }
    }
}
