/*
 * @lc app=leetcode id=1636 lang=csharp
 *
 * [1636] Sort Array by Increasing Frequency
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[] FrequencySort(int[] nums) {
        return nums
            .GroupBy(x => x, (x, a) => (Value: x, Count: a.Count()))
            .OrderBy(t => t.Count)
            .ThenByDescending(t => t.Value)
            .SelectMany(t => Enumerable.Repeat(t.Value, t.Count))
            .ToArray();
    }
}
// @lc code=end

