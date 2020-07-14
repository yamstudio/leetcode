/*
 * @lc app=leetcode id=931 lang=csharp
 *
 * [931] Minimum Falling Path Sum
 */

using System;

// @lc code=start
public class Solution {
    public int MinFallingPathSum(int[][] A) {
        int n = A.Length, r = 0, ret = int.MaxValue;
        if (n == 1) {
            return A[0][0];
        }
        int[,] dp = new int[2, n];
        for (int i = 0; i < n; ++i) {
            dp[r, 0] = A[i][0] + Math.Min(dp[1 - r, 0], dp[1 - r, 1]);
            for (int j = 1; j < n - 1; ++j) {
                dp[r, j] = A[i][j] + Math.Min(Math.Min(dp[1 - r, j - 1], dp[1 - r, j]), dp[1 - r, j + 1]);
            }
            dp[r, n - 1] = A[i][n - 1] + Math.Min(dp[1 - r, n - 2], dp[1 - r, n - 1]);
            r = 1 - r;
        }
        for (int j = 0; j < n; ++j) {
            ret = Math.Min(ret, dp[1 - r, j]);
        }
        return ret;
    }
}
// @lc code=end

