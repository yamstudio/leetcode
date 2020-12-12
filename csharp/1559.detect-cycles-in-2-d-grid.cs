/*
 * @lc app=leetcode id=1559 lang=csharp
 *
 * [1559] Detect Cycles in 2D Grid
 */

// @lc code=start
public class Solution {
    
    private static (int R, int C)[] Dirs = new (int R, int C)[] {
        (R: -1, C: 0),
        (R: 1, C: 0),
        (R: 0, C: -1),
        (R: 0, C: 1)
    };

    private static bool ContainsCycle(char[][] grid, int m, int n, int r, int c, int pr, int pc, bool[,] visited) {
        visited[r, c] = true;
        foreach (var dir in Dirs) {
            int nr = r + dir.R, nc = c + dir.C;
            if (nr < 0 || nr >= m || nc < 0 || nc >= n || pr == nr && pc == nc || grid[nr][nc] != grid[r][c]) {
                continue;
            }
            if (visited[nr, nc] || ContainsCycle(grid, m, n, nr, nc, r, c, visited)) {
                return true;
            }
        }
        return false;
    }

    public bool ContainsCycle(char[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        bool[,] visited = new bool[m, n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (!visited[i, j] && ContainsCycle(grid, m, n, i, j, -1, -1, visited)) {
                    return true;
                }
            }
        }
        return false;
    }
}
// @lc code=end

