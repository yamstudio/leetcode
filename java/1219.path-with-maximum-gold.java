/*
 * @lc app=leetcode id=1219 lang=java
 *
 * [1219] Path with Maximum Gold
 */

// @lc code=start
class Solution {
    public int getMaximumGold(int[][] grid) {
        int ret = 0, m = grid.length, n = grid[0].length;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                ret = Math.max(ret, collect(grid, i, j));
            }
        }
        return ret;
    }

    private static int collect(int[][] grid, int r, int c) {
        int m = grid.length, n = grid[0].length;
        if (r < 0 || r >= m || c < 0 || c >= n) {
            return 0;
        }
        int g = grid[r][c];
        if (g == 0) {
            return 0;
        }
        grid[r][c] = 0;
        int d = Math.max(collect(grid, r - 1, c), Math.max(collect(grid, r + 1, c), Math.max(collect(grid, r, c - 1), collect(grid, r, c + 1))));
        grid[r][c] = g;
        return g + d;
    }
}
// @lc code=end

