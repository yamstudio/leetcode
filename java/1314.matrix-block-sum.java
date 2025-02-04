/*
 * @lc app=leetcode id=1314 lang=java
 *
 * [1314] Matrix Block Sum
 */

// @lc code=start
class Solution {
    public int[][] matrixBlockSum(int[][] mat, int k) {
        int m = mat.length, n = mat[0].length;
        int[][] sums = new int[m + 1][n + 1];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                sums[i + 1][j + 1] = mat[i][j] - sums[i][j] + sums[i + 1][j] + sums[i][j + 1];
            }
        }
        int[][] ret = new int[m][n];
        for (int i = 0; i < m; ++i) {
            int li = Math.max(i - k, 0), ri = Math.min(m - 1, i + k);
            for (int j = 0; j < n; ++j) {
                int lj = Math.max(j - k, 0), rj = Math.min(n - 1, j + k);
                ret[i][j] = sums[ri + 1][rj + 1] + sums[li][lj] - sums[ri + 1][lj] - sums[li][rj + 1];
            }
        }
        return ret;
    }
}
// @lc code=end

