/*
 * @lc app=leetcode id=757 lang=csharp
 *
 * [757] Set Intersection Size At Least Two
 */

using System.Collections.Generic;
using System;

// @lc code=start
public class Solution {
    public int IntersectionSizeTwo(int[][] intervals) {
        int ret = 0, pp = -1, p = -1;
        Array.Sort(intervals, Comparer<int[]>.Create((a, b) => a[1] == b[1] ? b[0].CompareTo(a[0]) : a[1].CompareTo(b[1])));
        foreach (var interval in intervals) {
            if (interval[0] <= pp) {
                continue;
            }
            if (interval[0] > p) {
                ret += 2;
                pp = interval[1] - 1;
                p = interval[1];
            } else {
                ++ret;
                pp = p;
                p = interval[1];
            }
        }
        return ret;
    }
}
// @lc code=end

