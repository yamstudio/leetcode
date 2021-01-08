/*
 * @lc app=leetcode id=1679 lang=csharp
 *
 * [1679] Max Number of K-Sum Pairs
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MaxOperations(int[] nums, int k) {
        var count = nums
            .GroupBy(x => x, (x, a) => (Value: x, Count: a.Count()))
            .ToDictionary(t => t.Value, t => t.Count);
        int ret = 0;
        foreach (var tuple in count.Where(t => t.Key * 2 < k)) {
            if (count.TryGetValue(k - tuple.Key, out var o)) {
                ret += Math.Min(tuple.Value, o);
            }
        }
        if (k % 2 == 0 && count.TryGetValue(k / 2, out var c)) {
            ret += c / 2;
        }
        return ret;
    }
}
// @lc code=end

