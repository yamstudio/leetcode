/*
 * @lc app=leetcode id=1420 lang=java
 *
 * [1420] Build Array Where You Can Find The Maximum Exactly K Comparisons
 */

// @lc code=start
class Solution {
    public int numOfArrays(int n, int m, int k) {
        long[][][] dp = new long[n + 1][m + 1][k + 1];
        for (int j = 1; j <= m; ++j) {
            dp[1][j][1] = 1;
        }
        for (int i = 2; i <= n; ++i) {
            for (int j = 1; j <= m; ++j) {
                for (int l = 1; l <= k; ++l) {
                    long c = (j * dp[i - 1][j][l]) % 1000000007;
                    for (int pj = j - 1; pj >= 1; --pj) {
                        c = (c + dp[i - 1][pj][l - 1]) % 1000000007;
                    }
                    dp[i][j][l] = c;
                }
            }
        }
        long ret = 0;
        for (int j = 1; j <= m; ++j) {
            ret = (ret + dp[n][j][k]) % 1000000007;
        }
        return (int)ret;
    }
}
// @lc code=end

