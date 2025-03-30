/*
 * @lc app=leetcode id=1515 lang=java
 *
 * [1515] Best Position for a Service Centre
 */

// @lc code=start
class Solution {
    public double getMinDistSum(int[][] positions) {
        int n = positions.length;
        if (n == 1) {
            return 0;
        }
        double prevX = -100, prevY = -100, currX = 0, currY = 0;
        for (int[] position : positions) {
            currX += position[0];
            currY += position[1];
        }
        currX /= n;
        currY /= n;
        while (dist(prevX, prevY, currX, currY) > 1e-7) {
            double nextX = 0, nextY = 0, denom = 0;
            for (int[] position : positions) {
                double dist = dist(currX, currY, position[0], position[1]) + 1e-20;
                nextX += position[0] / dist;
                nextY += position[1] / dist;
                denom += 1 / dist;
            }
            prevX = currX;
            prevY = currY;
            currX = nextX / denom;
            currY = nextY / denom;
        }
        double ret = 0;
        for (int[] position : positions) {
            ret += dist(currX, currY, position[0], position[1]);
        }
        return ret;
    }

    private static double dist(double x1, double y1, double x2, double y2) {
        return Math.sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
    }
}
// @lc code=end

