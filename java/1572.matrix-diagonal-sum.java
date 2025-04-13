/*
 * @lc app=leetcode id=1572 lang=java
 *
 * [1572] Matrix Diagonal Sum
 */

// @lc code=start
class Solution {
    public int diagonalSum(int[][] mat) {
        int n = mat.length, ret = -(n % 2) * mat[n / 2][n / 2];
        for (int i = 0; i < n; ++i) {
            ret += mat[i][i] + mat[i][n - 1 - i];
        }
        return ret;
    }
}
// @lc code=end

