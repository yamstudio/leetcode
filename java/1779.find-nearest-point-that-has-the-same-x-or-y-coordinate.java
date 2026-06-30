/*
 * @lc app=leetcode id=1779 lang=java
 *
 * [1779] Find Nearest Point That Has the Same X or Y Coordinate
 */

// @lc code=start
class Solution {
    public int nearestValidPoint(int x, int y, int[][] points) {
        int n = points.length, ret = -1, md = Integer.MAX_VALUE;
        for (int i = 0; i < n; ++i) {
            int[] p = points[i];
            int xp = p[0], yp = p[1];
            if (x != xp && y != yp) {
                continue;
            }
            int d = Math.abs(x - xp) + Math.abs(y - yp);
            if (d >= md) {
                continue;
            }
            md = d;
            ret = i;
        }
        return ret;
    }
}
// @lc code=end

