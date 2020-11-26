/*
 * @lc app=leetcode id=1493 lang=csharp
 *
 * [1493] Longest Subarray of 1's After Deleting One Element
 */

using System;

// @lc code=start
public class Solution {
    public int LongestSubarray(int[] nums) {
        int pi = -1, pc = 0, ret = 0, n = nums.Length;
        for (int i = 0; i < n;) {
            if (nums[i] != 1) {
                ++i;
                continue;
            }
            int ni = i + 1;
            while (ni < n && nums[ni] == 1) {
                ++ni;
            }
            if (i == 0 && ni == n) {
                return n - 1;
            }
            ret = Math.Max(ret, ni - i);
            if (pi + pc == i - 1) {
                ret = Math.Max(ret, ni - i + pc);
            }
            pi = i;
            pc = ni - i;
            i = ni;
        }
        return ret;
    }
}
// @lc code=end

