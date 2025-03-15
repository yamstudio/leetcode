/*
 * @lc app=leetcode id=1458 lang=java
 *
 * [1458] Max Dot Product of Two Subsequences
 */

// @lc code=start
class Solution {
    public int maxDotProduct(int[] nums1, int[] nums2) {
        int m = nums1.length, n = nums2.length;
        Integer[][] dp = new Integer[m + 1][n + 1];
        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                int v = nums1[i - 1] * nums2[j - 1];
                Integer p = dp[i - 1][j - 1];
                if (p != null && p > 0) {
                    v += p;
                }
                Integer p1 = dp[i - 1][j];
                if (p1 != null) {
                    v = Math.max(v, p1);
                }
                Integer p2 = dp[i][j - 1];
                if (p2 != null) {
                    v = Math.max(v, p2);
                }
                dp[i][j] = v;
            }
        }
        return dp[m][n];
    }
}
// @lc code=end

