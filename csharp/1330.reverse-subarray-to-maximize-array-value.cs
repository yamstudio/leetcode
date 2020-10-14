/*
 * @lc app=leetcode id=1330 lang=csharp
 *
 * [1330] Reverse Subarray To Maximize Array Value
 */

using System;

// @lc code=start
public class Solution {
    public int MaxValueAfterReverse(int[] nums) {
        int n = nums.Length, diff = 0, ret = 0;
        for (int i = 1; i < n; ++i) {
            ret += Math.Abs(nums[i] - nums[i - 1]);
            diff = Math.Max(diff, Math.Max(-Math.Abs(nums[i] - nums[i - 1]) + Math.Abs(nums[i] - nums[0]), -Math.Abs(nums[i - 1] - nums[i]) + Math.Abs(nums[i - 1] - nums[n - 1])));
        }
        int maxd = int.MinValue, mind = int.MaxValue;
        for (int i = 1; i < n; ++i) {
            maxd = Math.Max(maxd, Math.Min(nums[i], nums[i - 1]));
            mind = Math.Min(mind, Math.Max(nums[i], nums[i - 1]));
        }
        diff = Math.Max(diff, 2 * (maxd - mind));
        return ret + diff;
    }
}
// @lc code=end

