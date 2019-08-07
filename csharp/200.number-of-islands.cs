/*
 * @lc app=leetcode id=200 lang=csharp
 *
 * [200] Number of Islands
 */
public class Solution {

    private static void VisitIslandRecurse(char[][] grid, int m, int n, int i, int j) {
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] != '1') {
            return;
        }
        grid[i][j] = '2';
        VisitIslandRecurse(grid, m, n, i - 1, j);
        VisitIslandRecurse(grid, m, n, i + 1, j);
        VisitIslandRecurse(grid, m, n, i, j - 1);
        VisitIslandRecurse(grid, m, n, i, j + 1);
    }

    public int NumIslands(char[][] grid) {
        int m = grid.Length, n, ret = 0;
        if (m == 0) {
            return 0;
        }
        n = grid[0].Length;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == '1') {
                    ++ret;
                    VisitIslandRecurse(grid, m, n, i, j);
                }
            }
        }
        return ret;
    }
}

