/*
 * @lc app=leetcode id=56 lang=csharp
 *
 * [56] Merge Intervals
 */

using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int[][] Merge(int[][] intervals) {
        if (intervals.Length == 0) {
            return intervals;
        }
        var sorted = intervals.OrderBy(i => i[0]).ThenBy(i => i[1]).ToArray();
        IList<int[]> ret = new List<int[]> {};
        int left = sorted[0][0], right = sorted[0][1];
        foreach (int[] interval in sorted) {
            if (interval[0] > right) {
                ret.Add(new int[] { left, right });
                left = interval[0];
                right = interval[1];
            } else {
                right = Math.Max(interval[1], right);
            }
        }
        ret.Add(new int[] { left, right });
        return ret.ToArray();
    }
}

