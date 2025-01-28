/*
 * @lc app=leetcode id=1292 lang=java
 *
 * [1292] Maximum Side Length of a Square with Sum Less than or Equal to Threshold
 */

// @lc code=start
class Solution {
    public int maxSideLength(int[][] mat, int threshold) {
        int m = mat.length, n = mat[0].length, ret = 0;
        int[][] sum = new int[m + 1][n + 1];
        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                sum[i][j] = mat[i - 1][j - 1] + sum[i - 1][j] + sum[i][j - 1] - sum[i - 1][j - 1];
                int len = ret + 1;
                if (i >= len && j >= len && sum[i][j] + sum[i - len][j - len] - sum[i][j - len] - sum[i - len][j] <= threshold) {
                    ret = len;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

