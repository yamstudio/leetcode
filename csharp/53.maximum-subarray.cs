/*
 * @lc app=leetcode id=53 lang=csharp
 *
 * [53] Maximum Subarray
 */
public class Solution {
    public int MaxSubArray(int[] nums) {
        if (nums.Length == 0) {
            return 0;
        }
        int ret = nums[0], sum = -1;
        for (int i = 0; i < nums.Length; ++i) {
            sum = Math.Max(sum, 0) + nums[i];
            ret = Math.Max(ret, sum);
        }
        return ret;
    }
}

