/*
 * @lc app=leetcode id=1020 lang=java
 *
 * [1020] Number of Enclaves
 */

// @lc code=start
class Solution {
    public int numEnclaves(int[][] grid) {
        int m = grid.length, n = grid[0].length, ret = 0;
        boolean[][] visited = new boolean[m][n];
        for (int i = 0; i < m; ++i) {
            visit(grid, i, 0, visited);
            visit(grid, i, n - 1, visited);
        }
        for (int i = 0; i < n; ++i) {
            visit(grid, 0, i, visited);
            visit(grid, m - 1, i, visited);
        }
        for (int i = 1; i < m - 1; ++i) {
            for (int j = 1; j < n - 1; ++j) {
                if (grid[i][j] == 1 && !visited[i][j]) {
                    ret += visit(grid, i, j, visited);
                }
            }
        }
        return ret;
    }

    private static int visit(int[][] grid, int i, int j, boolean[][] visited) {
        if (i < 0 || i >= visited.length || j < 0 || j >= visited[0].length) {
            return 0;
        }
        if (grid[i][j] == 0) {
            return 0;
        }
        if (visited[i][j]) {
            return 0;
        }
        visited[i][j] = true;
        return 1 + visit(grid, i - 1, j, visited) + visit(grid, i + 1, j, visited) + visit(grid, i, j - 1, visited) + visit(grid, i, j + 1, visited);
    }
}
// @lc code=end

