/*
 * @lc app=leetcode id=883 lang=csharp
 *
 * [883] Projection Area of 3D Shapes
 */

using System;

// @lc code=start
public class Solution {
    public int ProjectionArea(int[][] grid) {
        int n = grid.Length, ret = 0;
        for (int i = 0; i < n; ++i) {
            int r = 0, c = 0;
            for (int j = 0; j < n; ++j) {
                r = Math.Max(r, grid[i][j]);
                c = Math.Max(c, grid[j][i]);
                if (grid[i][j] > 0) {
                    ++ret;
                }
            }
            ret += r + c;
        }
        return ret;
    }
}
// @lc code=end

