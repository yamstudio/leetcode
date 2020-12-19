/*
 * @lc app=leetcode id=1590 lang=csharp
 *
 * [1590] Make Sum Divisible by P
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MinSubarray(int[] nums, int p) {
        int acc = 0, curr = 0, n = nums.Length, ret = n;
        var indices = new Dictionary<int, int>();
        foreach (var x in nums) {
            acc = (acc + x) % p;
        }
        indices[0] = -1;
        for (int i = 0; i < n; ++i) {
            curr  = (curr + nums[i]) % p;
            indices[curr] = i;
            if (indices.TryGetValue((-acc + p + curr) % p, out var j)) {
                ret = Math.Min(ret, i - j);
            }
        }
        return ret == n ? -1 : ret;
    }
}
// @lc code=end

