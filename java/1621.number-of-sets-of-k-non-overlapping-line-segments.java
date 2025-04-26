/*
 * @lc app=leetcode id=1621 lang=java
 *
 * [1621] Number of Sets of K Non-Overlapping Line Segments
 */

// @lc code=start
class Solution {
    public int numberOfSets(int n, int k) {
        return comb(n - k - 1, 2 * k, new int[n - k][2 * k + 1]);
    }

    private static int comb(int n, int k, int[][] dp) {
        if (n == 0 || k == 0) {
            return 1;
        }
        int ret = dp[n][k];
        if (ret == 0) {
            ret = (comb(n - 1, k, dp) + comb(n, k - 1, dp)) % 1000000007;
            dp[n][k] = ret;
        }
        return ret;
    }
}
// @lc code=end

