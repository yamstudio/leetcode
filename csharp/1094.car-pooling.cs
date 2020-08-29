/*
 * @lc app=leetcode id=1094 lang=csharp
 *
 * [1094] Car Pooling
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public bool CarPooling(int[][] trips, int capacity) {
        var sorted = trips
            .SelectMany(trip => new (int Stop, int Delta)[] {
                (Stop: trip[1], Delta: -trip[0]),
                (Stop: trip[2], Delta: trip[0])
            })
            .GroupBy(t => t.Stop, (int stop, IEnumerable<(int Stop, int Delta)> all) => (Stop: stop, Delta: all.Sum(t => t.Delta)))
            .OrderBy(t => t.Stop)
            .Select(t => t.Delta);
        foreach (var stop in sorted) {
            capacity += stop;
            if (capacity < 0) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

