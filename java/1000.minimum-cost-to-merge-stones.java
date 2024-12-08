/*
 * @lc app=leetcode id=1000 lang=java
 *
 * [1000] Minimum Cost to Merge Stones
 */

// @lc code=start
class Solution {
    public int mergeStones(int[] stones, int k) {
        int n = stones.length;
        if ((n - 1) % (k - 1) != 0) {
            return -1;
        }
        int[] sum = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            sum[i + 1] = sum[i] + stones[i];
        }
        int[][] dp = new int[n][n];
        for (int len = k; len <= n; ++len) {
            for (int l = 0; l + len <= n; ++l) {
                int r = l + len - 1;
                dp[l][r] = Integer.MAX_VALUE;
                for (int m = l; m < r; m += k - 1) {
                    dp[l][r] = Math.min(dp[l][r], dp[l][m] + dp[m + 1][r]);
                }
                if ((len - 1) % (k - 1) == 0) {
                    dp[l][r] += sum[r + 1] - sum[l];
                }
            }
        }
        return dp[0][n - 1];
    }
}
// @lc code=end

