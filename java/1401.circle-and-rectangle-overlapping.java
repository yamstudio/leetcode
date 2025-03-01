/*
 * @lc app=leetcode id=1401 lang=java
 *
 * [1401] Circle and Rectangle Overlapping
 */

// @lc code=start
class Solution {
    public boolean checkOverlap(int radius, int xCenter, int yCenter, int x1, int y1, int x2, int y2) {
        x1 -= xCenter;
        x2 -= xCenter;
        y1 -= yCenter;
        y2 -= yCenter;
        return radius * radius >=
            (
                x1 * x2 > 0
                ? Math.min(x1 * x1, x2 * x2)
                : 0
            )
            +
            (
                y1 * y2 > 0
                ? Math.min(y1 * y1, y2 * y2)
                : 0
            );
    }
}
// @lc code=end

