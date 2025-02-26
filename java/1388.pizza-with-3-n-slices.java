/*
 * @lc app=leetcode id=1388 lang=java
 *
 * [1388] Pizza With 3n Slices
 */

// @lc code=start
class Solution {
    public int maxSizeSlices(int[] slices) {
        return Math.max(helper(slices, 0), helper(slices, 1));
    }

    private static int helper(int[] slices, int offset) {
        int l = slices.length - 1, n = slices.length / 3;
        int[][] dp = new int[l + 1][n + 1];
        for (int i = 1; i <= l; ++i) {
            for (int j = 1; j <= n; ++j) {
                if (i == 1) {
                    dp[i][j] = slices[offset];
                } else {
                    dp[i][j] = Math.max(
                        slices[offset + i - 1] + dp[i - 2][j - 1],
                        dp[i - 1][j]
                    );
                }
            }
        }
        return dp[l][n];
    }
}
// @lc code=end

