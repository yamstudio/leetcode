/*
 * @lc app=leetcode id=1266 lang=java
 *
 * [1266] Minimum Time Visiting All Points
 */

// @lc code=start
class Solution {
    public int minTimeToVisitAllPoints(int[][] points) {
        int ret = 0;
        for (int i = points.length - 1; i > 0; --i) {
            int dx = Math.abs(points[i][0] - points[i - 1][0]), dy = Math.abs(points[i][1] - points[i - 1][1]);
            ret += Math.max(dx, dy);
        }
        return ret;
    }
}
// @lc code=end

