/*
 * @lc app=leetcode id=877 lang=java
 *
 * [877] Stone Game
 */

// @lc code=start
class Solution {
    public boolean stoneGame(int[] piles) {
        int n = piles.length;
        int[][] dp = new int[n][n];
        for (int i = 0; i < n; ++i) {
            dp[i][i] = piles[i];
        }
        for (int l = 2; l <= n; ++l) {
            for (int i = 0; i + l <= n; ++i) {
                dp[i][i + l - 1] = Math.max(piles[i] - dp[i + 1][i + l - 1], piles[i + l - 1] - dp[i][i + l - 2]);
            }
        }
        return dp[0][n - 1] > 0;
    }
}
// @lc code=end

