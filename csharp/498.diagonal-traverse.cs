/*
 * @lc app=leetcode id=498 lang=csharp
 *
 * [498] Diagonal Traverse
 */

// @lc code=start
public class Solution {
    public int[] FindDiagonalOrder(int[][] matrix) {
        int m = matrix.Length;
        if (m == 0) {
            return new int[0];
        }
        int n = matrix[0].Length, total = m * n, r = 0, c = 0, d = -1;
        int[] ret = new int[total];
        for (int i = 0; i < total; ++i) {
            ret[i] = matrix[r][c];
            r += d;
            c -= d;
            if (r >= m) {
                r = m - 1;
                c += 2;
                d = -d;
            }
            if (c >= n) {
                c = n - 1;
                r += 2;
                d = -d;
            }
            if (c < 0) {
                c = 0;
                d = -d;
            } 
            if (r < 0) {
                r = 0;
                d = -d;
            }
        }
        return ret;
    }
}
// @lc code=end

