/*
 * @lc app=leetcode id=1162 lang=csharp
 *
 * [1162] As Far from Land as Possible
 */

using System;

// @lc code=start
public class Solution {

    private static void UpdateDistance(int[,] dist, int[][] grid, int m, int n, int i, int j, int d) {
        if (i < 0 || i >= m || j < 0 || j >= n || (d == 0 && grid[i][j] != 1) || (d > 0 && (grid[i][j] != 0 || dist[i, j] <= d))) {
            return;
        }
        dist[i, j] = d;
        UpdateDistance(dist, grid, m, n, i - 1, j, d + 1);
        UpdateDistance(dist, grid, m, n, i + 1, j, d + 1);
        UpdateDistance(dist, grid, m, n, i, j - 1, d + 1);
        UpdateDistance(dist, grid, m, n, i, j + 1, d + 1);
    }

    public int MaxDistance(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, acc = 0;
        var dist = new int[m, n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                dist[i, j] = int.MaxValue;
                acc += grid[i][j];
            }
        }
        if (acc == 0 || acc == m * n) {
            return -1;
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                UpdateDistance(dist, grid, m, n, i, j, 0);
            }
        }
        int ret = -1;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) {
                    ret = Math.Max(ret, dist[i, j]);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

