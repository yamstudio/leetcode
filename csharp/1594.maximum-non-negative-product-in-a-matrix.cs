/*
 * @lc app=leetcode id=1594 lang=csharp
 *
 * [1594] Maximum Non Negative Product in a Matrix
 */

using System;

// @lc code=start
public class Solution {
    public int MaxProductPath(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        long acc = 1;
        bool hasZero = false;
        long[,] p = new long[n + 1, 2];
        for (int j = 0; j < n; ++j) {
            acc *= (long)grid[0][j];
            if (acc > 0) {
                p[j + 1, 1] = acc;
            } else {
                p[j + 1, 0] = acc;
            }
            hasZero = hasZero || acc == 0;
        }
        for (int i = 1; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                hasZero = hasZero || grid[i][j] == 0;
                if (grid[i][j] > 0) {
                    p[j + 1, 1] = (long)grid[i][j] * Math.Max(p[j + 1, 1], p[j, 1]);
                    p[j + 1, 0] = (long)grid[i][j] * Math.Min(p[j + 1, 0], p[j, 0]);
                } else {
                    long np = (long)grid[i][j] * Math.Min(p[j + 1, 0], p[j, 0]), nn = (long)grid[i][j] * Math.Max(p[j + 1, 1], p[j, 1]);
                    p[j + 1, 1] = np;
                    p[j + 1, 0] = nn;
                }
            }
        }
        return (p[n, 1] == 0 && !hasZero) ? -1 : (int)(p[n, 1] % 1000000007);
    }
}
// @lc code=end

