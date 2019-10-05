/*
 * @lc app=leetcode id=495 lang=csharp
 *
 * [495] Teemo Attacking
 */

// @lc code=start
public class Solution {
    public int FindPoisonedDuration(int[] timeSeries, int duration) {
        int ret = 0, end = 0, prev = 0;
        foreach (int time in timeSeries) {
            ret += Math.Min(time, end) - prev;
            prev = time;
            end = time + duration;
        }
        ret += end - prev;
        return ret;
    }
}
// @lc code=end

