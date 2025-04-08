/*
 * @lc app=leetcode id=1559 lang=java
 *
 * [1559] Detect Cycles in 2D Grid
 */

// @lc code=start
class Solution {

    private static final int[][] DIRS = new int[][] {
        new int[] { -1, 0 },
        new int[] { 1, 0 },
        new int[] { 0, -1 },
        new int[] { 0, 1 }
    };

    public boolean containsCycle(char[][] grid) {
        int m = grid.length, n = grid[0].length;
        boolean[][] visited = new boolean[m][n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (!visited[i][j] && containsCycle(grid, visited, i, j, -1, -1)) {
                    return true;
                }
            }
        }
        return false;
    }

    private static boolean containsCycle(char[][] grid, boolean[][] visited, int r, int c, int pr, int pc) {
        int m = grid.length, n = grid[0].length;
        char val = grid[r][c];
        visited[r][c] = true;
        for (int[] dir : DIRS) {
            int nr = r + dir[0], nc = c + dir[1];
            if (nr < 0 || nr >= m || nc < 0 || nc >= n || (nr == pr && nc == pc) || val != grid[nr][nc]) {
                continue;
            }
            if (visited[nr][nc] || containsCycle(grid, visited, nr, nc, r, c)) {
                return true;
            }
        }
        return false;
    }
}
// @lc code=end

