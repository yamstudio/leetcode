/*
 * @lc app=leetcode id=1329 lang=csharp
 *
 * [1329] Sort the Matrix Diagonally
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    private static void DiagonalSort(int[][] mat, int m, int n, int i, int j) {
        int k = Math.Min(m - i, n - j);
        var sorted = Enumerable.Range(0, k).Select(d => mat[i + d][j + d]).OrderBy(x => x).ToArray();
        for (int d = 0; d < k; ++d) {
            mat[i + d][j + d] = sorted[d];
        }
    }

    public int[][] DiagonalSort(int[][] mat) {
        int m = mat.Length, n = mat[0].Length;
        for (int i = 0; i < m; ++i) {
            DiagonalSort(mat, m, n, i, 0);
        }
        for (int j = 1; j < n; ++j) {
            DiagonalSort(mat, m, n, 0, j);
        }
        return mat;
    }
}
// @lc code=end

