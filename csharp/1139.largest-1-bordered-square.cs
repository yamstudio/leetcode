/*
 * @lc app=leetcode id=1139 lang=csharp
 *
 * [1139] Largest 1-Bordered Square
 */

using System;

// @lc code=start
public class Solution {

    private static int GetArea(int[,] dp, int sx, int sy, int gx, int gy) {
        return dp[gx, gy] + dp[sx - 1, sy - 1] - dp[gx, sy - 1] - dp[sx - 1, gy];
    }

    public int Largest1BorderedSquare(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                dp[i, j] = -dp[i - 1, j - 1] + dp[i, j - 1] + dp[i - 1, j] + grid[i - 1][j - 1];
            }
        }
        for (int len = Math.Min(m, n); len > 0; --len) {
            for (int x = 1; x <= m; ++x) {
                int nx = x + len - 1;
                if (nx > m) {
                    break;
                }
                for (int y = 1; y <= n; ++y) {
                    int ny = y + len - 1;
                    if (ny > n) {
                        break;
                    }
                    if (GetArea(dp, x, y, nx, y) == len && GetArea(dp, x, y, x, ny) == len && GetArea(dp, nx, y, nx, ny) == len && GetArea(dp, x, ny, nx, ny) == len) {
                        return len * len;
                    }
                }
            }
        }
        return 0;
    }
}
// @lc code=end

