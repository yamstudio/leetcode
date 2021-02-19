/*
 * @lc app=leetcode id=879 lang=java
 *
 * [879] Profitable Schemes
 */

// @lc code=start
class Solution {
    public int profitableSchemes(int n, int minProfit, int[] group, int[] profit) {
        int m = group.length, ret = 0;
        int[][][] dp = new int[m + 1][n + 1][minProfit + 1];
        dp[0][0][0] = 1;
        for (int i = 1; i <= m; ++i) {
            int g = group[i - 1], p = profit[i - 1];
            for (int j = 0; j <= n; ++j) {
                for (int k = 0; k <= minProfit; ++k) {
                    if (g <= j) {
                        dp[i][j][k] = (dp[i - 1][j][k] + dp[i - 1][j - g][Math.max(0, k - p)]) % 1000000007;
                    } else {
                        dp[i][j][k] = dp[i - 1][j][k];
                    }
                }
            }
        }
        for (int j = 0; j <= n; ++j) {
            ret = (ret + dp[m][j][minProfit]) % 1000000007;
        }
        return ret;
    }
}
// @lc code=end

