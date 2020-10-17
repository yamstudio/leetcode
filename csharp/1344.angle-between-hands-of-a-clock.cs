/*
 * @lc app=leetcode id=1344 lang=csharp
 *
 * [1344] Angle Between Hands of a Clock
 */

using System;

// @lc code=start
public class Solution {
    public double AngleClock(int hour, int minutes) {
        double ret = Math.Abs(((double)(hour % 12) + (double)minutes / 60) * 30 - (double)minutes * 6);
        if (ret > 180) {
            return 360 - ret;
        }
        return ret;
    }
}
// @lc code=end

