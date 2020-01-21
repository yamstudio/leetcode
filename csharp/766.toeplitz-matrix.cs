/*
 * @lc app=leetcode id=766 lang=csharp
 *
 * [766] Toeplitz Matrix
 */

// @lc code=start
public class Solution {
    public bool IsToeplitzMatrix(int[][] matrix) {
        int m = matrix.Length;
        if (m == 0) {
            return true;
        }
        int n = matrix[0].Length;
        for (int i = 0; i < m; ++i) {
            int val = matrix[i][0];
            for (int r = i + 1, c = 1; r < m && c < n; ++r, ++c) {
                if (val != matrix[r][c]) {
                    return false;
                }
            }
        }
        for (int j = 1; j < n; ++j) {
            int val = matrix[0][j];
            for (int r = 1, c = j + 1; r < m && c < n; ++r, ++c) {
                if (val != matrix[r][c]) {
                    return false;
                }
            }
        }
        return true;
    }
}
// @lc code=end

