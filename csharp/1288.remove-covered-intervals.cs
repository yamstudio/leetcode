/*
 * @lc app=leetcode id=1288 lang=csharp
 *
 * [1288] Remove Covered Intervals
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int RemoveCoveredIntervals(int[][] intervals) {
        int ret = 0, r = -1;
        foreach (var curr in intervals.OrderBy(interval => interval[0]).ThenByDescending(interval => interval[1])) {
            if (curr[1] > r) {
                ++ret;
                r = curr[1];
            }
        }
        return ret;
    }
}
// @lc code=end

