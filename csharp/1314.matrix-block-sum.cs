/*
 * @lc app=leetcode id=1314 lang=csharp
 *
 * [1314] Matrix Block Sum
 */

using System;

// @lc code=start
public class Solution {
    public int[][] MatrixBlockSum(int[][] mat, int K) {
        int m = mat.Length, n = mat[0].Length;
        int[,] sums = new int[m + 1, n + 1];
        int[][] ret = new int[m][];
        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                sums[i, j] = -sums[i - 1, j - 1] + sums[i - 1, j] + sums[i, j - 1] + mat[i - 1][j - 1];
            }
        }
        for (int i = 0; i < m; ++i) {
            int[] row = new int[n];
            for (int j = 0; j < n; ++j) {
                int li = Math.Max(0, i - K), lj = Math.Max(0, j - K), ri = Math.Min(i + K, m - 1), rj = Math.Min(j + K, n - 1);
                row[j] = sums[ri + 1, rj + 1] + sums[li, lj] - sums[li, rj + 1] - sums[ri + 1, lj];
            }
            ret[i] = row;
        }
        return ret;
    }
}
// @lc code=end

