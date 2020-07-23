/*
 * @lc app=leetcode id=956 lang=csharp
 *
 * [956] Tallest Billboard
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int TallestBillboard(int[] rods) {
        int n = rods.Length, sum = rods.Sum();
        int[,] dp = new int[n + 1, sum + 1];
        for (int i = 0; i <= n; ++i) {
            for (int j = 0; j <= sum; ++j) {
                dp[i, j] = -1;
            }
        }
        dp[0, 0] = 0;
        for (int i = 1; i <= n; ++i) {
            int h = rods[i - 1];
            for (int j = 0; j <= sum - h; ++j) {
                if (dp[i - 1, j] < 0) {
                    continue;
                }
                dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j]);
                dp[i, j + h] = Math.Max(dp[i, j + h], dp[i - 1, j]);
                dp[i, Math.Abs(h - j)] = Math.Max(dp[i, Math.Abs(h - j)], dp[i - 1, j] + Math.Min(j, h));
            }
        }
        return dp[n, 0];
    }
}
// @lc code=end

