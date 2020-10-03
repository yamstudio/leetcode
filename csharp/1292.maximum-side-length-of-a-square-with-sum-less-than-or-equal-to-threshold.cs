/*
 * @lc app=leetcode id=1292 lang=csharp
 *
 * [1292] Maximum Side Length of a Square with Sum Less than or Equal to Threshold
 */

// @lc code=start
public class Solution {
    public int MaxSideLength(int[][] mat, int threshold) {
        int m = mat.Length, n = mat[0].Length, ret = 0;
        int[,] sum = new int[m + 1, n + 1];
        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                int l = ret + 1;
                sum[i, j] = mat[i - 1][j - 1] - sum[i - 1, j - 1] + sum[i - 1, j] + sum[i, j - 1];
                if (i >= l && j >= l && threshold >= sum[i, j] + sum[i - l, j - l] - sum[i - l, j] - sum[i, j - l]) {
                    ++ret;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

