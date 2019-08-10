/*
 * @lc app=leetcode id=209 lang=csharp
 *
 * [209] Minimum Size Subarray Sum
 */
public class Solution {
    public int MinSubArrayLen(int s, int[] nums) {
        int sum = 0, left = 0, right = 0, len = nums.Length, ret = 0;
        while (right < len) {
            while (sum < s && right < len) {
                sum += nums[right++];
            }
            while (sum >= s) {
                ret = ret == 0 || ret > (right - left) ? right - left : ret;
                sum -= nums[left++];
            }
        }
        return ret;
    }
}

