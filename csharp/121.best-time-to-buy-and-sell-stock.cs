/*
 * @lc app=leetcode id=121 lang=csharp
 *
 * [121] Best Time to Buy and Sell Stock
 */
public class Solution {
    public int MaxProfit(int[] prices) {
        if (prices.Length == 0) {
            return 0;
        }
        int ret = 0, prevMin = prices[0];
        foreach (int price in prices) {
            prevMin = Math.Min(prevMin, price);
            ret = Math.Max(ret, price - prevMin);
        }
        return ret;
    }
}

