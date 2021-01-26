/*
 * @lc app=leetcode id=812 lang=java
 *
 * [812] Largest Triangle Area
 */

// @lc code=start
class Solution {
    public double largestTriangleArea(int[][] points) {
        double ret = 0;
        int n = points.length;
        for (int i = 0; i < n - 2; ++i) {
            int x1 = points[i][0], y1 = points[i][1];
            for (int j = i + 1; j < n - 1; ++j) {
                int x2 = points[j][0], y2 = points[j][1];
                for (int k = j + 1; k < n; ++k) {
                    int x3 = points[k][0], y3 = points[k][1];
                    ret = Math.max(ret, Math.abs(x1 * y2 + x2 * y3 + x3 * y1 - x2 * y1 - x3 * y2 - x1 * y3));
                }
            }
        }
        return ret * 0.5;
    }
}
// @lc code=end

