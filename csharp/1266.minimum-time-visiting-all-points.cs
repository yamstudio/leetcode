/*
 * @lc app=leetcode id=1266 lang=csharp
 *
 * [1266] Minimum Time Visiting All Points
 */

using System;

// @lc code=start
public class Solution {
    public int MinTimeToVisitAllPoints(int[][] points) {
        int ret = 0, n = points.Length;
        for (int i = 1; i < n; ++i) {
            int[] prev = points[i - 1], curr = points[i];
            int x = Math.Abs(prev[0] - curr[0]), y = Math.Abs(prev[1] - curr[1]);
            ret += Math.Max(x, y);
        }
        return ret;
    }
}
// @lc code=end

