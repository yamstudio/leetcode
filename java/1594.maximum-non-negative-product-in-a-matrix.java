/*
 * @lc app=leetcode id=1594 lang=java
 *
 * [1594] Maximum Non Negative Product in a Matrix
 */

// @lc code=start
class Solution {
    public int maxProductPath(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        long acc = 1L;
        long[][] dp = new long[n + 1][2];
        boolean zero = false;
        for (int j = 0; j < n; ++j) {
            long val = (long)grid[0][j];
            acc *= val;
            if (acc > 0) {
                dp[j + 1][1] = acc;
            } else {
                dp[j + 1][0] = acc;
            }
            zero = zero || val == 0;
        }
        for (int i = 1; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                long val = (long)grid[i][j];
                if (val > 0) {
                    dp[j + 1][0] = val * Math.min(dp[j][0], dp[j + 1][0]);
                    dp[j + 1][1] = val * Math.max(dp[j][1], dp[j + 1][1]);
                } else {
                    long pos = val * Math.min(dp[j][0], dp[j + 1][0]), neg = val * Math.max(dp[j][1], dp[j + 1][1]);
                    dp[j + 1][0] = neg;
                    dp[j + 1][1] = pos;
                }
                zero = zero || val == 0;
            }
        }
        long max = dp[n][1];
        return (max == 0 && !zero) ? -1 : (int)(max % 1000000007);
    }
}
// @lc code=end

