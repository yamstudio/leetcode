/*
 * @lc app=leetcode id=63 lang=csharp
 *
 * [63] Unique Paths II
 */
public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int m = obstacleGrid.Length, n;
        if (m == 0) {
            return 0;
        }
        n = obstacleGrid[0].Length;
        int[] dp = new int[n];
        dp[0] = obstacleGrid[0][0] == 1 ? 0 : 1;
        for (int i = 1; i < n; ++i) {
            dp[i] = obstacleGrid[0][i] == 1 ? 0 : dp[i - 1];
        }
        for (int j = 1; j < m; ++j) {
            if (obstacleGrid[j][0] == 1) {
                dp[0] = 0;
            }
            for (int i = 1; i < n; ++i) {
                if (obstacleGrid[j][i] == 1) {
                    dp[i] = 0;
                } else {
                    dp[i] += dp[i - 1];
                }
            }
        }
        return dp[n - 1];
    }
}

