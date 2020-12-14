/*
 * @lc app=leetcode id=1572 lang=csharp
 *
 * [1572] Matrix Diagonal Sum
 */

// @lc code=start
public class Solution {
    public int DiagonalSum(int[][] mat) {
        int ret = 0, n = mat.Length;
        for (int i = 0; i < n; ++i) {
            ret += mat[i][i] + mat[i][n - 1 - i];
        }
        return ret - (n % 2) * mat[n / 2][n / 2];
    }
}
// @lc code=end

