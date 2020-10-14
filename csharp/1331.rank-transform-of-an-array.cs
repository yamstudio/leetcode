/*
 * @lc app=leetcode id=1331 lang=csharp
 *
 * [1331] Rank Transform of an Array
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[] ArrayRankTransform(int[] arr) {
        return arr
            .Select((x, i) => (Value: x, Index: i))
            .OrderBy(t => t.Value)
            .GroupBy(t => t.Value, (v, all) => all.Select(t => t.Index))
            .SelectMany((a, i) => a.Select(j => (Index: j, Rank: i + 1)))
            .OrderBy(t => t.Index)
            .Select(t => t.Rank)
            .ToArray();
    }
}
// @lc code=end

