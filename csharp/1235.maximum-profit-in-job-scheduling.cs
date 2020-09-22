/*
 * @lc app=leetcode id=1235 lang=csharp
 *
 * [1235] Maximum Profit in Job Scheduling
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit) {
        var sorted = new SortedList<int, int>();
        sorted[0] = 0;
        foreach (var job in startTime
            .Zip(endTime, (int s, int e) => (Start: s, End: e))
            .Zip(profit, ((int Start, int End) t, int p) => (Start: t.Start, End: t.End, Profit: p))
            .OrderBy(t => t.End)) {
            int start = job.Start, end = job.End, p, l = 0, r = sorted.Count - 1;
            var keys = sorted.Keys;
            while (l < r - 1) {
                int m = l + (r - l) / 2;
                if (keys[m] > start) {
                    r = m - 1;
                } else {
                    l = m;
                }
            }
            while (keys[r] > start) {
                --r;
            }
            p = job.Profit + sorted[keys[r]];
            if (p > sorted.Values[sorted.Count - 1]) {
                sorted[end] = p;
            }
        }
        return sorted.Values[sorted.Count - 1];
    }
}
// @lc code=end

