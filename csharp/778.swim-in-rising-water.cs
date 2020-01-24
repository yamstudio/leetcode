/*
 * @lc app=leetcode id=778 lang=csharp
 *
 * [778] Swim in Rising Water
 */

using System;

// @lc code=start
public class Solution {

    private static (int DX, int DY)[] Dirs = new (int DX, int DY)[] {
        (DX: 0, DY: -1),
        (DX: 0, DY: 1),
        (DX: -1, DY: 0),
        (DX: 1, DY: 0)
    };

    private static void SwimInWaterRecurse(int[][] grid, int n, int r, int c, int curr, int[,] dp) {
        dp[r, c] = Math.Max(curr, grid[r][c]);
        foreach (var dir in Dirs) {
            int nr = r + dir.DX, nc = c + dir.DY;
            if (nr < 0 || nr >= n || nc < 0 || nc >= n || dp[nr, nc] <= Math.Max(grid[nr][nc], dp[r, c])) {
                continue;
            }
            SwimInWaterRecurse(grid, n, nr, nc, dp[r, c], dp);
        }
    }

    public int SwimInWater(int[][] grid) {
        int n = grid.Length;
        var dp = new int[n, n];
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                dp[i, j] = int.MaxValue;
            }
        }
        SwimInWaterRecurse(grid, n, 0, 0, grid[0][0], dp);
        return dp[n - 1, n - 1];
    }
}
// @lc code=end

