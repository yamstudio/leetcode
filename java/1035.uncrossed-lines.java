/*
 * @lc app=leetcode id=1035 lang=java
 *
 * [1035] Uncrossed Lines
 */

// @lc code=start
class Solution {
    public int maxUncrossedLines(int[] nums1, int[] nums2) {
        int m = nums1.length, n = nums2.length;
        int[][] maxLines = new int[m + 1][n + 1];
        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                if (nums1[i - 1] == nums2[j - 1]) {
                    maxLines[i][j] = maxLines[i - 1][j - 1] + 1;
                } else {
                    maxLines[i][j] = Math.max(maxLines[i - 1][j], maxLines[i][j - 1]);
                }
            }
        }
        return maxLines[m][n];
    }
}
// @lc code=end

