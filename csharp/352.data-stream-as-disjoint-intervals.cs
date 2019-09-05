/*
 * @lc app=leetcode id=352 lang=csharp
 *
 * [352] Data Stream as Disjoint Intervals
 */

using System.Collections.Generic;

public class SummaryRanges {

    private List<int[]> Intervals;

    /** Initialize your data structure here. */
    public SummaryRanges() {
        Intervals = new List<int[]>();
    }
    
    public void AddNum(int val) {
        int i, count = 0, n = Intervals.Count;
        int[] interval = new int[] { val, val };
        for (i = 0; i < n; ++i) {
            int[] curr = Intervals[i];
            if (curr[0] > interval[1] + 1) {
                break;
            }
            if (curr[1] + 1 >= interval[0]) {
                ++count;
                interval[0] = Math.Min(interval[0], curr[0]);
                interval[1] = Math.Max(interval[1], curr[1]);
            }
        }
        if (count > 0) {
            Intervals.RemoveRange(i - count, count);
        }
        Intervals.Insert(i - count, interval);
    }
    
    public int[][] GetIntervals() {
        return Intervals.ToArray();
    }
}

/**
 * Your SummaryRanges object will be instantiated and called as such:
 * SummaryRanges obj = new SummaryRanges();
 * obj.AddNum(val);
 * int[][] param_2 = obj.GetIntervals();
 */

