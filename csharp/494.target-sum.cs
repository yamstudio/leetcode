/*
 * @lc app=leetcode id=494 lang=csharp
 *
 * [494] Target Sum
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int FindTargetSumWaysRecurse(int[] nums, int sum, int start, IDictionary<(int, int), int> map) {
        if (start == nums.Length) {
            return sum == 0 ? 1 : 0;
        }
        var key = (sum, start);
        if (map.ContainsKey(key)) {
            return map[key];
        }
        return (map[key] = FindTargetSumWaysRecurse(nums, sum + nums[start], start + 1, map) + FindTargetSumWaysRecurse(nums, sum - nums[start], start + 1, map));
    }

    public int FindTargetSumWays(int[] nums, int S) {
        return FindTargetSumWaysRecurse(nums, S, 0, new Dictionary<(int, int), int>());
    }
}
// @lc code=end

