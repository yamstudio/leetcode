/*
 * @lc app=leetcode id=1568 lang=java
 *
 * [1568] Minimum Number of Days to Disconnect Island
 */

// @lc code=start
class Solution {

    private static final int[][] DIRS = new int[][] {
        new int[] { 0, -1 },
        new int[] { 0, 1 },
        new int[] { -1, 0 },
        new int[] { 1, 0 }
    };

    public int minDays(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        if (count(grid) != 1) {
            return 0;
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1) {
                    grid[i][j] = 0;
                    if (count(grid) != 1) {
                        return 1;
                    }
                    grid[i][j] = 1;
                }
            }
        }
        return 2;
    }

    private static int count(int[][] grid) {
        int ret = 0, m = grid.length, n = grid[0].length;
        boolean[][] visited = new boolean[m][n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (!visited[i][j] && grid[i][j] == 1) {
                    visit(grid, i, j, visited);
                    ++ret;
                }
            }
        }
        return ret;
    }

    private static void visit(int[][] grid, int i, int j, boolean[][] visited) {
        int m = grid.length, n = grid[0].length;
        if (i < 0 || i >= m || j < 0 || j >= n || visited[i][j] || grid[i][j] == 0) {
            return;
        }
        visited[i][j] = true;
        for (int[] dir : DIRS) {
            int ni = i + dir[0], nj = j + dir[1];
            visit(grid, ni, nj, visited);
        }
    }
}
// @lc code=end

