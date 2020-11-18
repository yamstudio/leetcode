/*
 * @lc app=leetcode id=1460 lang=csharp
 *
 * [1460] Make Two Arrays Equal by Reversing Sub-arrays
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public bool CanBeEqual(int[] target, int[] arr) {
        var count = target
            .GroupBy(x => x, (x, a) => (Value: x, Count: a.Count()))
            .ToDictionary(t => t.Value, t => t.Count);
        foreach (var x in arr) {
            if (!count.TryGetValue(x, out var c) || c == 0) {
                return false;
            }
            count[x] = c - 1;
        }
        return true;
    }
}
// @lc code=end

