/*
 * @lc app=leetcode id=539 lang=csharp
 *
 * [539] Minimum Time Difference
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int FindMinDifference(IList<string> timePoints) {
        int[] sorted = timePoints.Select(s => {
            var split = s.Split(':');
            return int.Parse(split[0]) * 60 + int.Parse(split[1]);
        }).OrderBy(x => x).ToArray();
        return sorted.Skip(1).Aggregate((24 * 60 + sorted[0] - sorted[sorted.Length - 1], sorted[0]), (ret, curr) => (Math.Min(ret.Item1, curr - ret.Item2), curr)).Item1;
    }
}
// @lc code=end

