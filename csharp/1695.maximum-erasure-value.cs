/*
 * @lc app=leetcode id=1695 lang=csharp
 *
 * [1695] Maximum Erasure Value
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MaximumUniqueSubarray(int[] nums) {
        int acc = 0, p = 0, ret = 0, n = nums.Length;
        var seen = new HashSet<int>();
        for (int i = 0; i < n; ++i) {
            int curr = nums[i];
            if (!seen.Add(curr)) {
                while (nums[p] != curr) {
                    seen.Remove(nums[p]);
                    acc -= nums[p++];
                }
                ++p;
            } else {
                acc += curr;
            }
            ret = Math.Max(acc, ret);
        }
        return ret;
    }
}
// @lc code=end

