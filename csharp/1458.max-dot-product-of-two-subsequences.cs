/*
 * @lc app=leetcode id=1458 lang=csharp
 *
 * [1458] Max Dot Product of Two Subsequences
 */

using System;

// @lc code=start
public class Solution {
    public int MaxDotProduct(int[] nums1, int[] nums2) {
        int m = nums1.Length, n = nums2.Length;
        var dp = new int?[m + 1, n + 1];
        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                int p = nums1[i - 1] * nums2[j - 1];
                if (dp[i - 1, j - 1].HasValue) {
                    p = Math.Max(p,  p + dp[i - 1, j - 1].Value);
                }
                if (dp[i - 1, j].HasValue) {
                    p = Math.Max(p,  dp[i - 1, j].Value);
                }
                if (dp[i, j - 1].HasValue) {
                    p = Math.Max(p,  dp[i, j - 1].Value);
                }
                dp[i, j] = p;
            }
        }
        return dp[m, n].Value;
    }
}
// @lc code=end

