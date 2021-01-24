/*
 * @lc app=leetcode id=807 lang=java
 *
 * [807] Max Increase to Keep City Skyline
 */

// @lc code=start
class Solution {
    public int maxIncreaseKeepingSkyline(int[][] grid) {
        int m = grid.length, n = grid[0].length, ret = 0;
        int[] rmax = new int[m], cmax = new int[n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                rmax[i] = Math.max(rmax[i], grid[i][j]);
                cmax[j] = Math.max(cmax[j], grid[i][j]);
            }
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                ret += Math.min(rmax[i], cmax[j]) - grid[i][j];
            }
        }
        return ret;
    }
}
// @lc code=end

