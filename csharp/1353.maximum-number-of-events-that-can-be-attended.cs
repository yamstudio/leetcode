/*
 * @lc app=leetcode id=1353 lang=csharp
 *
 * [1353] Maximum Number of Events That Can Be Attended
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MaxEvents(int[][] events) {
        int n = events.Length, ret = 0, i = 0, d = 1, md = events.Max(x => x[1]);
        var sortedEvents = events.Select((x, i) => (End: x[1], Start: x[0], Id: i)).OrderBy(x => x.Start).ToArray();
        var possible = new SortedSet<(int End, int Start, int Id)>(Comparer<(int End, int Start, int Id)>.Create((x, y) => {
            if (x.End != y.End) {
                return x.End.CompareTo(y.End);
            }
            if (x.Start != y.Start) {
                return x.Start.CompareTo(y.Start);
            }
            return x.Id.CompareTo(y.Id);
        }));
        while (d <= md) {
            if (i < n && possible.Count == 0) {
                d = sortedEvents[i].Start;
            }
            while (possible.Count > 0 && possible.Min.End < d) {
                possible.Remove(possible.Min);
            }
            while (i < n && sortedEvents[i].Start == d) {
                possible.Add(sortedEvents[i++]);
            }
            if (possible.Count > 0) {
                possible.Remove(possible.Min);
                ++ret;
            } else if (i >= n) {
                break;
            }
            ++d;
        }
        return ret;
    }
}
// @lc code=end

