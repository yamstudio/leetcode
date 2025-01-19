/*
 * @lc app=leetcode id=1254 lang=java
 *
 * [1254] Number of Closed Islands
 */

// @lc code=start
class Solution {
    public int closedIsland(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        for (int i = 0; i < m; ++i) {
            clear(grid, i, 0);
            clear(grid, i, n - 1);
        }
        for (int j = 0; j < n; ++j) {
            clear(grid, 0, j);
            clear(grid, m - 1, j);
        }
        int ret = 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) {
                    ++ret;
                    clear(grid, i, j);
                }
            }
        }
        return ret;
    }

    private static void clear(int[][] grid, int i, int j) {
        int m = grid.length, n = grid[0].length;
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == 1) {
            return;
        }
        grid[i][j] = 1;
        clear(grid, i - 1, j);
        clear(grid, i + 1, j);
        clear(grid, i, j - 1);
        clear(grid, i, j + 1);
    }
}
// @lc code=end

