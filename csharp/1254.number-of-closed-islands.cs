/*
 * @lc app=leetcode id=1254 lang=csharp
 *
 * [1254] Number of Closed Islands
 */

// @lc code=start
public class Solution {

    private static void Submerge(int[][] grid, int m, int n, int i, int j) {
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] != 0) {
            return;
        }
        grid[i][j] = 1;
        Submerge(grid, m, n, i - 1, j);
        Submerge(grid, m, n, i + 1, j);
        Submerge(grid, m, n, i, j - 1);
        Submerge(grid, m, n, i, j + 1);
    }

    public int ClosedIsland(int[][] grid) {
        int ret = 0, m = grid.Length, n = grid[0].Length;
        for (int i = 0; i < m; ++i) {
            Submerge(grid, m, n, i, 0);
            Submerge(grid, m, n, i, n - 1);
        }
        for (int j = 0; j < n; ++j) {
            Submerge(grid, m, n, 0, j);
            Submerge(grid, m, n, m - 1, j);
        }
        for (int i = 1; i < m - 1; ++i) {
            for (int j = 1; j < n - 1; ++j) {
                if (grid[i][j] == 0) {
                    Submerge(grid, m, n, i, j);
                    ++ret;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

