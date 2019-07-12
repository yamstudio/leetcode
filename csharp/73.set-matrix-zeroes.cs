/*
 * @lc app=leetcode id=73 lang=csharp
 *
 * [73] Set Matrix Zeroes
 */
public class Solution {

    private void zeroRow(int[][] matrix, int row) {
        for (int i = 0; i < matrix[row].Length; ++i) {
            matrix[row][i] = 0;
        }
    }

    private void zeroCol(int[][] matrix, int col) {
        for (int i = 0; i < matrix.Length; ++i) {
            matrix[i][col] = 0;
        }
    }

    public void SetZeroes(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        bool zeroFirstRow = false, zeroFirstCol = false;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (matrix[i][j] == 0) {
                    if (i == 0) {
                        zeroFirstRow = true;
                    } else {
                        matrix[i][0] = 0;
                    }
                    if (j == 0) {
                        zeroFirstCol = true;
                    } else {
                        matrix[0][j] = 0;
                    }
                }
            }
        }
        for (int i = 1; i < m; ++i) {
            if (matrix[i][0] == 0) {
                zeroRow(matrix, i);
            }
        }
        for (int j = 1; j < n; ++j) {
            if (matrix[0][j] == 0) {
                zeroCol(matrix, j);
            }
        }
        if (zeroFirstRow) {
            zeroRow(matrix, 0);
        }
        if (zeroFirstCol) {
            zeroCol(matrix, 0);
        }
    }
}

