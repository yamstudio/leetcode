/*
 * @lc app=leetcode id=304 lang=csharp
 *
 * [304] Range Sum Query 2D - Immutable
 */
public class NumMatrix {

    private int[,] sum = null;

    public NumMatrix(int[][] matrix) {
        int m = matrix.Length;
        if (m == 0) {
            return;
        }
        int n = matrix[0].Length;
        sum = new int[m + 1, n + 1];
        sum[1, 1] = matrix[0][0];
        for (int j = 1; j < n; ++j) {
            sum[1, j + 1] = matrix[0][j] + sum[1, j];
        }
        for (int i = 1; i < m; ++i) {
            sum[i + 1, 1] = matrix[i][0] + sum[i, 1];
            for (int j = 1; j < n; ++j) {
                sum[i + 1, j + 1] = sum[i, j + 1] + sum[i + 1, j] - sum[i, j] + matrix[i][j];
            }
        }
    }
    
    public int SumRegion(int row1, int col1, int row2, int col2) {
        return sum == null ? 0 : (sum[row2 + 1, col2 + 1] + sum[row1, col1] - sum[row1, col2 + 1] - sum[row2 + 1, col1]);
    }
}

/**
 * Your NumMatrix object will be instantiated and called as such:
 * NumMatrix obj = new NumMatrix(matrix);
 * int param_1 = obj.SumRegion(row1,col1,row2,col2);
 */

