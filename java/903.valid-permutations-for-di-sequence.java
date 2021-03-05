/*
 * @lc app=leetcode id=903 lang=java
 *
 * [903] Valid Permutations for DI Sequence
 */

// @lc code=start
class Solution {
    public int numPermsDISequence(String S) {
        int n = S.length();
        int[][] dp = new int[n + 1][n + 1];
        for (int j = 0; j <= n; ++j) {
            dp[0][j] = 1;
        }
        for (int i = 0; i < n; ++i) {
            if (S.charAt(i) == 'D') {
                dp[i + 1][0] = dp[i][0];
                for (int j = 1; j < n - i; ++j) {
                    dp[i + 1][j] = (dp[i + 1][j - 1] + dp[i][j]) % 1000000007;
                }
            } else {
                for (int j = n - 1 - i; j >= 0; --j) {
                    dp[i + 1][j] = (dp[i + 1][j + 1] + dp[i][j + 1]) % 1000000007;
                }
            }
        }
        return dp[n][0];
    }
}
// @lc code=end

