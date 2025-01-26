/*
 * @lc app=leetcode id=1277 lang=java
 *
 * [1277] Count Square Submatrices with All Ones
 */

// @lc code=start
class Solution {
    public int countSquares(int[][] matrix) {
        int m = matrix.length, n = matrix[0].length;
        int[][] verticalCount = new int[2][n], diagonalCount = new int[2][n];
        int t = 0, ret = 0;
        for (int i = 0; i < m; ++i) {
            int leftCount = 0;
            for (int j = 0; j < n; ++j) {
                if (matrix[i][j] == 0) {
                    leftCount = 0;
                    diagonalCount[t][j] = 0;
                    verticalCount[t][j] = 0;
                    continue;
                }
                leftCount++;
                verticalCount[t][j] = 1 + verticalCount[1 - t][j];
                if (j > 0) {
                    diagonalCount[t][j] = Math.min(leftCount, Math.min(verticalCount[t][j], 1 + diagonalCount[1 - t][j - 1]));
                } else {
                    diagonalCount[t][j] = 1;
                }
                ret += diagonalCount[t][j];
            }
            t = 1 - t;
        }
        return ret;
    }
}
// @lc code=end

