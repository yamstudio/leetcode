/*
 * @lc app=leetcode id=1329 lang=java
 *
 * [1329] Sort the Matrix Diagonally
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int[][] diagonalSort(int[][] mat) {
        int m = mat.length, n = mat[0].length;
        for (int r = 0; r < m; ++r) {
            sort(mat, r, 0);
        }
        for (int c = 1; c < n; ++c) {
            sort(mat,0, c);
        }
        return mat;
    }

    private static void sort(int[][] mat, int r, int c) {
        int m = mat.length, n = mat[0].length, k = Math.min(m - r, n - c);
        int[] vals = new int[k];
        for (int i = 0; i < k; ++i) {
            vals[i] = mat[r + i][c + i];
        }
        Arrays.sort(vals);
        for (int i = 0; i < k; ++i) {
            mat[r + i][c + i] = vals[i];
        }
    }
}
// @lc code=end

