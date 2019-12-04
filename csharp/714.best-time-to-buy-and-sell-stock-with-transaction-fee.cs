/*
 * @lc app=leetcode id=714 lang=csharp
 *
 * [714] Best Time to Buy and Sell Stock with Transaction Fee
 */

// @lc code=start
public class Solution {
    public int MaxProfit(int[] prices, int fee) {
        int h = -prices[0], s = 0, n = prices.Length;
        foreach (int price in prices) {
            int os = s;
            s = Math.Max(s, h + price - fee);
            h = Math.Max(h, os - price);
        }
        return s;
    }
}
// @lc code=end

