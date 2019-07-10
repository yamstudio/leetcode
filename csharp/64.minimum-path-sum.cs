/*
 * @lc app=leetcode id=64 lang=csharp
 *
 * [64] Minimum Path Sum
 */
public class Solution {
    public int MinPathSum(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[] dp = new int[n];
        dp[0] = grid[0][0];
        for (int i = 1; i < n; ++i) {
            dp[i] = dp[i - 1] + grid[0][i];
        }
        for (int j = 1; j < m; ++j) {
            dp[0] += grid[j][0];
            for (int i = 1; i < n; ++i) {
                dp[i] = Math.Min(dp[i], dp[i - 1]) + grid[j][i];
            }
        }
        return dp[n - 1];
    }
}

