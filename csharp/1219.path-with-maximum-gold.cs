/*
 * @lc app=leetcode id=1219 lang=csharp
 *
 * [1219] Path with Maximum Gold
 */

using System;

// @lc code=start
public class Solution {

    private static int GetMaximumGoldRecurse(int[][] grid, int m, int n, int i, int j) {
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == 0) {
            return 0;
        }
        int ret = grid[i][j];
        grid[i][j] = 0;
        int delta = Math.Max(Math.Max(GetMaximumGoldRecurse(grid, m, n, i - 1, j), GetMaximumGoldRecurse(grid, m, n, i + 1, j)), Math.Max(GetMaximumGoldRecurse(grid, m, n, i, j - 1), GetMaximumGoldRecurse(grid, m, n, i, j + 1)));
        grid[i][j] = ret;
        return ret + delta;
    }

    public int GetMaximumGold(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, ret = 0;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                ret = Math.Max(ret, GetMaximumGoldRecurse(grid, m, n, i, j));
            }
        }
        return ret;
    }
}
// @lc code=end

