/*
 * @lc app=leetcode id=1568 lang=csharp
 *
 * [1568] Minimum Number of Days to Disconnect Island
 */

// @lc code=start
public class Solution {

    private static (int R, int C)[] Dirs = new (int R, int C)[] {
        (R: -1, C: 0),
        (R: 1, C: 0),
        (R: 0, C: -1),
        (R: 0, C: 1)
    };

    private static void Visit(int[][] grid, int m, int n, int i, int j, bool[,] visited) {
        visited[i, j] = true;
        foreach (var dir in Dirs) {
            int ni = i + dir.R, nj = j + dir.C;
            if (ni < 0 || ni >= m || nj < 0 || nj >= n || grid[ni][nj] != 1 || visited[ni, nj]) {
                continue;
            }
            Visit(grid, m, n, ni, nj, visited);
        }
    }

    private static int Count(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, ret = 0;
        bool[,] visited = new bool[m, n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1 && !visited[i, j]) {
                    ++ret;
                    Visit(grid, m, n, i, j, visited);
                }
            }
        }
        return ret;
    }

    public int MinDays(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        if (Count(grid) != 1) {
            return 0;
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1) {
                    grid[i][j] = 0;
                    if (Count(grid) != 1) {
                        return 1;
                    }
                    grid[i][j] = 1;
                }
            }
        }
        return 2;
    }
}
// @lc code=end

