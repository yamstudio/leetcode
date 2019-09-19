/*
 * @lc app=leetcode id=435 lang=csharp
 *
 * [435] Non-overlapping Intervals
 */

using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int EraseOverlapIntervals(int[][] intervals) {
        if (intervals.Length == 0) {
            return 0;
        }
        int ret = 0;
        Array.Sort(intervals, Comparer<int[]>.Create((a, b) => ((a[0] == b[0]) ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0]))));
        int[] prev = intervals[0];
        foreach (int[] curr in intervals.Skip(1)) {
            if (curr[0] < prev[1]) {
                ++ret;
                if (curr[1] < prev[1]) {
                    prev = curr;
                }
            } else {
                prev = curr;
            }
        }
        return ret;
    }
}

