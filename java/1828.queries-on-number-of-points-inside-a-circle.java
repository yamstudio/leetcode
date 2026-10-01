/*
 * @lc app=leetcode id=1828 lang=java
 *
 * [1828] Queries on Number of Points Inside a Circle
 */

// @lc code=start
class Solution {
    public int[] countPoints(int[][] points, int[][] queries) {
        int n = queries.length;
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            int[] q = queries[i];
            int cx = q[0], cy = q[1], r = q[2], d = r * r;
            for (int[] p : points) {
                int x = p[0], y = p[1];
                if (d >= (cx - x) * (cx - x) + (cy - y) * (cy - y)) {
                    ++ret[i];
                }
            }
        }
        return ret;
    }
}
// @lc code=end

