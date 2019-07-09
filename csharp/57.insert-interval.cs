/*
 * @lc app=leetcode id=57 lang=csharp
 *
 * [57] Insert Interval
 */

using System.Collections.Generic;

public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        IList<int[]> ret = new List<int[]>();
        int left = newInterval[0], right = newInterval[1];
        bool put = false;
        foreach (int[] interval in intervals) {
            if (interval[1] < left) {
                ret.Add(interval);
                continue;
            }
            if (interval[0] > right) {
                if (!put) {
                    put = true;
                    ret.Add(new int[] { left, right });
                }
                ret.Add(interval);
                continue;
            }
            left = Math.Min(left, interval[0]);
            right = Math.Max(right, interval[1]);
        }
        if (!put) {
            ret.Add(new int[] { left, right });
        }
        return ret.ToArray();
    }
}

