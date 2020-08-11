/*
 * @lc app=leetcode id=1010 lang=csharp
 *
 * [1010] Pairs of Songs With Total Durations Divisible by 60
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int NumPairsDivisibleBy60(int[] time) {
        var mins = time
            .GroupBy(t => t % 60, (int t, IEnumerable<int> all) => (Time: t, Count: all.Count()))
            .ToDictionary(tuple => tuple.Time, tuple => tuple.Count);
        return mins
            .Where(p => p.Key <= 30)
            .Select(p => p.Key == 0 || p.Key == 30 ? p.Value * (p.Value - 1) / 2 : (mins.TryGetValue(60 - p.Key, out int o) ? o * p.Value : 0))
            .Sum();
    }
}
// @lc code=end

