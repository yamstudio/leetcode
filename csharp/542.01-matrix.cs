/*
 * @lc app=leetcode id=542 lang=csharp
 *
 * [542] 01 Matrix
 */

// @lc code=start
public class Solution {
    public int[][] UpdateMatrix(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        int[][] ret = new int[m][];
        for (int i = 0; i < m; ++i) {
            ret[i] = new int[n];
            for (int j = 0; j < n; ++j) {
                if (matrix[i][j] == 0) {
                    continue;
                }
                int curr = int.MaxValue - 1;
                if (i > 0) {
                    curr = Math.Min(curr, ret[i - 1][j] + 1);
                }
                if (j > 0) {
                    curr = Math.Min(curr, ret[i][j - 1] + 1);
                }
                ret[i][j] = curr;
            }
        }
        for (int i = m - 1; i >= 0; --i) {
            for (int j = n - 1; j >= 0; --j) {
                if (ret[i][j] <= 1) {
                    continue;
                }
                int curr = ret[i][j];
                if (i < m - 1) {
                    curr = Math.Min(curr, ret[i + 1][j] + 1);
                }
                if (j < n - 1) {
                    curr = Math.Min(curr, ret[i][j + 1] + 1);
                }
                ret[i][j] = curr;
            }
        }
        return ret;
    }
}
// @lc code=end

