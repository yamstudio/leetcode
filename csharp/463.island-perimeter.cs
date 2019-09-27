/*
 * @lc app=leetcode id=463 lang=csharp
 *
 * [463] Island Perimeter
 */
public class Solution {
    public int IslandPerimeter(int[][] grid) {
        int m = grid.Length, n, ret = 0;
        if (m == 0) {
            return ret;
        }
        n = grid[0].Length;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1) {
                    if (i == 0 || grid[i - 1][j] == 0) {
                        ++ret;
                    }
                    if (i == m - 1 || grid[i + 1][j] == 0) {
                        ++ret;
                    }
                    if (j == 0 || grid[i][j - 1] == 0) {
                        ++ret;
                    }
                    if (j == n - 1 || grid[i][j + 1] == 0) {
                        ++ret;
                    }
                }
            }
        }
        return ret;
    }
}

