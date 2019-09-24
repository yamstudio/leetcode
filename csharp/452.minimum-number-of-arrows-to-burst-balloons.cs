/*
 * @lc app=leetcode id=452 lang=csharp
 *
 * [452] Minimum Number of Arrows to Burst Balloons
 */

using System;
using System.Collections.Generic;

public class Solution {
    public int FindMinArrowShots(int[][] points) {
        int n = points.Length;
        if (n == 0) {
            return 0;
        }
        int arrow, ret = 1;
        Array.Sort(points, Comparer<int[]>.Create((a, b) => a[0] == b[0] ? a[1].CompareTo(b[1]) : a[0].CompareTo(b[0])));
        arrow = points[0][1];
        for (int i = 1; i < n; ++i) {
            var curr = points[i];
            if (curr[0] > arrow) {
                ++ret;
                arrow = curr[1];
            } else {
                arrow = Math.Min(arrow, curr[1]);
            }
        }
        return ret;
    }
}

