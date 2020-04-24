/*
 * @lc app=leetcode id=892 lang=csharp
 *
 * [892] Surface Area of 3D Shapes
 */

using System;

// @lc code=start
public class Solution {
    public int SurfaceArea(int[][] grid) {
        int ret = 0, n = grid.Length;
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                int val = grid[i][j];
                if (val == 0) {
                    continue;
                }
                ret += 4 * val + 2;
                if (i > 0) {
                    ret -= 2 * Math.Min(val, grid[i - 1][j]);
                }
                if (j > 0) {
                    ret -= 2 * Math.Min(val, grid[i][j - 1]);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

