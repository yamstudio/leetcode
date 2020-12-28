/*
 * @lc app=leetcode id=1637 lang=csharp
 *
 * [1637] Widest Vertical Area Between Two Points Containing No Points
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MaxWidthOfVerticalArea(int[][] points) {
        int ret = 0, n = points.Length;
        points = points
            .OrderBy(t => t[0])
            .ToArray();
        for (int i = 1; i < n; ++i) {
            ret = Math.Max(points[i][0] - points[i - 1][0], ret);
        }
        return ret;
    }
}
// @lc code=end

