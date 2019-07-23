/*
 * @lc app=leetcode id=122 lang=csharp
 *
 * [122] Best Time to Buy and Sell Stock II
 */
public class Solution {
    public int MaxProfit(int[] prices) {
        int ret = 0;
        for (int i = 1; i < prices.Length; ++i) {
            ret += Math.Max(0, prices[i] - prices[i - 1]);
        }
        return ret;
    }
}

