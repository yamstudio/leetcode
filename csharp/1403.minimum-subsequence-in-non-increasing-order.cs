/*
 * @lc app=leetcode id=1403 lang=csharp
 *
 * [1403] Minimum Subsequence in Non-Increasing Order
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> MinSubsequence(int[] nums) {
        int n = nums.Length, sum = nums.Sum(), acc = 0;
        var ret = new List<int>();
        Array.Sort(nums);
        for (int i = n - 1; i >= 0 && acc * 2 <= sum; --i) {
            acc += nums[i];
            ret.Add(nums[i]);
        }
        return ret;
    }
}
// @lc code=end

