/*
 * @lc app=leetcode id=123 lang=csharp
 *
 * [123] Best Time to Buy and Sell Stock III
 */
public class Solution {
    public int MaxProfit(int[] prices) {
        int n = prices.Length;
        if (n == 0) {
            return 0;
        }
        int[] maxFirstProfits = new int[n];
        int lowestBuy = prices[0];
        for (int i = 1; i < n; ++i) {
            maxFirstProfits[i] = Math.Max(maxFirstProfits[i - 1], prices[i] - lowestBuy);
            lowestBuy = Math.Min(lowestBuy, prices[i]);
        }

        int highestSell = prices[n - 1], ret = maxFirstProfits[n - 1], maxSecondProfit = 0;
        for (int i = n - 2; i >= 1; --i) {
            maxSecondProfit = Math.Max(maxSecondProfit, highestSell - prices[i]);
            ret = Math.Max(ret, maxFirstProfits[i - 1] + maxSecondProfit);
            highestSell = Math.Max(highestSell, prices[i]);
        }
        return ret;
    }
}

