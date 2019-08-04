/*
 * @lc app=leetcode id=188 lang=csharp
 *
 * [188] Best Time to Buy and Sell Stock IV
 */
public class Solution {
    public int MaxProfit(int k, int[] prices) {
        int n = prices.Length;
        if (k > n / 2) {
            int ret = 0;
            for (int i = 1; i < n; ++i) {
                if (prices[i] > prices[i - 1]) {
                    ret += prices[i] - prices[i - 1];
                }
            }
            return ret;
        }
        int[] sellAt = new int[k + 1], upTo = new int[k + 1];
        for (int i = 1; i < n; ++i) {
            int diff = prices[i] - prices[i - 1], inc = Math.Max(diff, 0);
            for (int j = k; j > 0; --j) {
                sellAt[j] = Math.Max(inc + upTo[j - 1], sellAt[j] + diff);
                upTo[j] = Math.Max(upTo[j], sellAt[j]);
            }
        }
        return upTo[k];
    }
}

