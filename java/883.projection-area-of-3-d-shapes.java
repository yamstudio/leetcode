/*
 * @lc app=leetcode id=883 lang=java
 *
 * [883] Projection Area of 3D Shapes
 */

// @lc code=start
class Solution {
    public int projectionArea(int[][] grid) {
        int n = grid.length, ret = 0;
        for (int i = 0; i < n; ++i) {
            int rm = 0, cm = 0;
            for (int j = 0; j < n; ++j) {
                int v = grid[i][j];
                if (v > 0) {
                    ++ret;
                    rm = Math.max(rm, v);
                }
                cm = Math.max(cm, grid[j][i]);
            }
            ret += rm + cm;
        }
        return ret;
    }
}
// @lc code=end

