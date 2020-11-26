using System;
using System.Collections.Generic;

namespace Algos.StockSell
{
    /*
     * Design an algorithm to find the maximum profit. 
     * You may complete as many transactions as you like 
     * (ie, buy one and sell one share of the stock multiple times) with the following restrictions:
     *     You may not engage in multiple transactions at the same time 
     *          (ie, you must sell the stock before you buy again).
     *     After you sell your stock, you cannot buy stock on next day. (ie, cooldown 1 day)
     */
    public static class SellStockWithCooldown
    {
        public static void Test()
        {
            UnitTest(new int[] { 1, 2, 3, 0, 2 }, 3);
            UnitTest(new int[] { 1, 4, 2 }, 3);
            UnitTest(new int[] { 2, 1, 4 }, 3);
        }

        private static void UnitTest(int[] prices, int expected)
        {
            int result = MaxProfit_Recursive(prices);

            if (result == expected)
                Console.WriteLine("Passed Recursive");
            else
                Console.WriteLine($"Failed Recursive, result={result}, expected={expected}, {string.Join(',', prices)}");

            result = MaxProfit(prices);

            if (result == expected)
                Console.WriteLine("Passed TopDown");
            else
                Console.WriteLine($"Failed Topdown, result={result}, expected={expected}, {string.Join(',', prices)}");
        }


        /// TopDown without using the arrays for buy and sell arrays
        public static int MaxProfit(int[] prices)
        {
            int buyT1 = -prices[0];
            int sellT1 = 0;
            int sellT2 = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                buyT1 = Math.Max(buyT1, sellT2 - prices[i]);
                sellT2 = sellT1;
                sellT1 = Math.Max(sellT1, buyT1 + prices[i]);
            }

            return sellT1;
        }

        /// TopDown
        public static int MaxProfit_Array(int[] prices)
        {
            //max profit at i when series of transaction end with buy
            int[] buy = new int[prices.Length];

            //max profit at i when series of transaction end with sell
            int[] sell = new int[prices.Length];

            buy[0] = -prices[0];
            buy[1] = -Math.Min(prices[0], prices[1]);
            sell[0] = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                //Either carry forward from old buy decision and holding on to it 
                //Or Buying today based on Sell at / before i - 2
                if (i > 1)
                    buy[i] = Math.Max(buy[i - 1], sell[i - 2] - prices[i]);

                //Either hold on to old decision Or Sell today based on Buy at / before i - 1
                sell[i] = Math.Max(sell[i - 1], buy[i - 1] + prices[i]);
            }

            return sell[^1];
        }

        public static int MaxProfit_Recursive(int[] prices)
        {
            //dayProfitMapApproach1 = new Dictionary<int, int>();
            //return MaxProfit_RecursiveApproach1(prices, 0);

            dayProfitMapApproach2 = new Dictionary<string, int>();
            return MaxProfit_RecursiveApproach2(prices, 0, false);
        }

        #region Approach 2
        static Dictionary<string, int> dayProfitMapApproach2;
        private static int MaxProfit_RecursiveApproach2(int[] prices, int day, bool buyState)
        {
            if (day >= prices.Length) return 0;

            string memoKey = $"{day}-{(buyState ? 1 : 0)}";
            if (dayProfitMapApproach2.ContainsKey(memoKey)) return dayProfitMapApproach2[memoKey];

            int pHold = MaxProfit_RecursiveApproach2(prices, day + 1, buyState);
            if (buyState)
            {
                pHold = Math.Max(pHold, prices[day] + MaxProfit_RecursiveApproach2(prices, day + 2, false));
            }
            else
            {
                pHold = Math.Max(pHold, MaxProfit_RecursiveApproach2(prices, day + 1, true) - prices[day]);
            }

            dayProfitMapApproach2.Add(memoKey, pHold);
            return pHold;
        }
        #endregion

        #region Approach 1
        static Dictionary<int, int> dayProfitMapApproach1;
        private static int MaxProfit_RecursiveApproach1(int[] prices, int day)
        {
            if (day >= prices.Length) return 0;

            if (dayProfitMapApproach1.ContainsKey(day)) return dayProfitMapApproach1[day];

            int maxProfit = 0;

            for (int i = day; i < prices.Length; i++)
            {
                if (prices[i] < prices[day]) continue;

                maxProfit = Math.Max(maxProfit, MaxProfit_RecursiveApproach1(prices, i + 2) + prices[i] - prices[day]);
            }

            maxProfit = Math.Max(maxProfit, MaxProfit_RecursiveApproach1(prices, day + 1));

            dayProfitMapApproach1.Add(day, maxProfit);
            return maxProfit;
        }
        #endregion
    }
}
