/*
 * @lc app=leetcode id=329 lang=csharp
 *
 * [329] Longest Increasing Path in a Matrix
 */
public class Solution {

    private (int, int)[] Dirs = new (int, int)[] {
        (-1, 0), (1, 0), (0, -1), (0, 1),
    };

    private int LongestIncreasingPathRecurse(int[][] matrix, int[,] dp, int m, int n, int i, int j) {
        if (dp[i, j] > 0) {
            return dp[i, j];
        }
        int ret = 1;
        foreach ((int, int) dir in Dirs) {
            int ni = i + dir.Item1, nj = j + dir.Item2;
            if (ni < 0 || ni >= m || nj < 0 || nj >= n || matrix[ni][nj] <= matrix[i][j]) {
                continue;
            }
            ret = Math.Max(ret, 1 + LongestIncreasingPathRecurse(matrix, dp, m, n, i + dir.Item1, j + dir.Item2));
        }
        dp[i, j] = ret;
        return ret;
    }
    public int LongestIncreasingPath(int[][] matrix) {
        int m = matrix.Length, n, ret = 0;
        if (m == 0) {
            return 0;
        }
        n = matrix[0].Length;
        int[,] dp = new int[m, n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                ret = Math.Max(ret, LongestIncreasingPathRecurse(matrix, dp, m, n, i, j));
            }
        }
        return ret;
    }
}

