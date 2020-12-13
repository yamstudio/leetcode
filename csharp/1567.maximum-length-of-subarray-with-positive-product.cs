/*
 * @lc app=leetcode id=1567 lang=csharp
 *
 * [1567] Maximum Length of Subarray With Positive Product
 */

using System;

// @lc code=start
public class Solution {
    public int GetMaxLen(int[] nums) {
        int ret = 0, n = nums.Length, pz = -1, pn = -1;
        bool isNegative = false;
        for (int i = 0; i < n; ++i) {
            if (nums[i] == 0) {
                pz = i;
                pn = -1;
                isNegative = false;
                continue;
            }
            isNegative ^= nums[i] < 0;
            if (isNegative) {
                if (pn >= 0) {
                    ret = Math.Max(ret, i - pn);
                } else {
                    pn = i;
                }
            } else {
                ret = Math.Max(i - pz, ret);
            }
        }
        return ret;
    }
}
// @lc code=end

