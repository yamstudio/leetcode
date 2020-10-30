/*
 * @lc app=leetcode id=1388 lang=csharp
 *
 * [1388] Pizza With 3n Slices
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    
    private static int MaxSizeSlices(int[] slices, int k) {
        int n = slices.Length;
        int[,] dp = new int[n + 1, k + 1];
        for (int i = 1; i <= n; ++i) {
            for (int j = 1; j <= k; ++j) {
                if (i == 1) {
                    dp[i, j] = slices[0];
                } else {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i - 2, j - 1] + slices[i - 1]);
                }
            }
        }
        return dp[n, k];
    }
    
    public int MaxSizeSlices(int[] slices) {
        int n = slices.Length, k = n / 3;
        return Math.Max(MaxSizeSlices(slices.SkipLast(1).ToArray(), k), MaxSizeSlices(slices.Skip(1).ToArray(), k));
    }
}
// @lc code=end

