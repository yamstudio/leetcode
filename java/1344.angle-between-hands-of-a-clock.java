/*
 * @lc app=leetcode id=1344 lang=java
 *
 * [1344] Angle Between Hands of a Clock
 */

// @lc code=start
class Solution {
    public double angleClock(int hour, int minutes) {
        double h = (double)(hour % 12) * 30 + (double)minutes * .5, m = (double)minutes * 6, d = (h - m + 360) % 360;
        return d > 180 ? 360 - d : d;
    }
}
// @lc code=end

