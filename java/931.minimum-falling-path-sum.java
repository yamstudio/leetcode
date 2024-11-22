/*
 * @lc app=leetcode id=931 lang=java
 *
 * [931] Minimum Falling Path Sum
 */

// @lc code=start
class Solution {
    public int minFallingPathSum(int[][] matrix) {
        int n = matrix.length;
        int[][] dp = new int[n][n];
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (i == 0) {
                    dp[i][j] = matrix[i][j];
                    continue;
                }
                dp[i][j] = matrix[i][j] + dp[i - 1][j];
                if (j - 1 >= 0) {
                    dp[i][j] = Math.min(dp[i][j], matrix[i][j] + dp[i - 1][j - 1]);
                }
                if (j + 1 < n) {
                    dp[i][j] = Math.min(dp[i][j], matrix[i][j] + dp[i - 1][j + 1]);
                }
            }
        }
        int ret = Integer.MAX_VALUE;
        for (int i = 0; i < n; ++i) {
            ret = Math.min(ret, dp[n - 1][i]);
        }
        return ret;
    }
}
// @lc code=end

