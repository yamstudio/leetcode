/*
 * @lc app=leetcode id=436 lang=csharp
 *
 * [436] Find Right Interval
 */

using System;
using System.Collections.Generic;

public class Solution {
    public int[] FindRightInterval(int[][] intervals) {
        int n = intervals.Length;
        IDictionary<int, int> map = new Dictionary<int, int>(n);
        int[] sorted = new int[n], ret = new int[n];
        for (int i = 0; i < n; ++i) {
            int curr = intervals[i][0];
            map[curr] = i;
            sorted[i] = curr;
        }
        Array.Sort(sorted);
        for (int i = 0; i < n; ++i) {
            int last = intervals[i][1], left = 0, right = n;
            while (left < right) {
                int mid = left + (right - left) / 2;
                if (sorted[mid] < last) {
                    left = mid + 1;
                } else {
                    right = mid;
                }
            }
            ret[i] = left == n ? -1 : map[sorted[left]];
        }
        return ret;
    }
}

