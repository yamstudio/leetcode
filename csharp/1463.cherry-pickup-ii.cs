/*
 * @lc app=leetcode id=1463 lang=csharp
 *
 * [1463] Cherry Pickup II
 */

using System;

// @lc code=start
public class Solution {

    private static int CherryPickup(int[][] grid, int m, int n, int r, int ca, int cb, int?[,,] memo) {
        if (m == r) {
            return 0;
        }
        if (memo[r, ca, cb].HasValue) {
            return memo[r, ca, cb].Value;
        }
        int ret = 0;
        for (int i = -1; i < 2; ++i) {
            int na = ca + i;
            if (na < 0 || na >= n) {
                continue;
            }
            for (int j = -1; j < 2; ++j) {
                int nb = cb + j;
                if (nb < 0 || nb >= n) {
                    continue;
                }
                ret = Math.Max(ret, CherryPickup(grid, m, n, r + 1, na, nb, memo));
            }
        }
        ret += grid[r][ca];
        if (cb != ca) {
            ret += grid[r][cb];
        }
        memo[r, ca, cb] = ret;
        return ret;
    }

    public int CherryPickup(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        return CherryPickup(grid, m, n, 0, 0, n - 1, new int?[m, n, n]);
    }
}
// @lc code=end

