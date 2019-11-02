/*
 * @lc app=leetcode id=611 lang=csharp
 *
 * [611] Valid Triangle Number
 */

using System;

// @lc code=start
public class Solution {
    public int TriangleNumber(int[] nums) {
        int ret = 0, n = nums.Length;
        Array.Sort(nums);
        for (int i = n - 1; i >= 2; --i) {
            int left = 0, right = i - 1, curr = nums[i];
            while (left < right) {
                if (nums[left] + nums[right] > curr) {
                    ret += right - left;
                    --right;
                } else {
                    ++left;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

