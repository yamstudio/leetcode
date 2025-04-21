/*
 * @lc app=leetcode id=1605 lang=java
 *
 * [1605] Find Valid Matrix Given Row and Column Sums
 */

// @lc code=start
class Solution {
    public int[][] restoreMatrix(int[] rowSum, int[] colSum) {
        int m = rowSum.length, n = colSum.length;
        int[][] ret = new int[m][n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                ret[i][j] = Math.min(rowSum[i], colSum[j]);
                rowSum[i] -= ret[i][j];
                colSum[j] -= ret[i][j];
            }
        }
        return ret;
    }
}
// @lc code=end

