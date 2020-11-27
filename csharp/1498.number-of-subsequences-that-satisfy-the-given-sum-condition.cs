/*
 * @lc app=leetcode id=1498 lang=csharp
 *
 * [1498] Number of Subsequences That Satisfy the Given Sum Condition
 */

using System;

// @lc code=start
public class Solution {
    public int NumSubseq(int[] nums, int target) {
        int n = nums.Length, ret = 0, l = 0, r = n - 1;
        var powers = new int[n];
        powers[0] = 1;
        for (int i = 1; i < n; ++i) {
            powers[i] = (2 * powers[i - 1]) % 1000000007;
        }
        Array.Sort(nums);
        while (l <= r) {
            if (nums[l] + nums[r] > target) {
                --r;
            } else {
                ret = (ret + powers[r - l]) % 1000000007;
                ++l;
            }
        }
        return ret;
    }
}
// @lc code=end

