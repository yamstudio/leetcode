/*
 * @lc app=leetcode id=1375 lang=csharp
 *
 * [1375] Bulb Switcher III
 */

using System;

// @lc code=start
public class Solution {
    public int NumTimesAllBlue(int[] light) {
        int on = 0, max = 0, ret = 0;
        foreach (int l in light) {
            max = Math.Max(max, l);
            if (++on == max) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

