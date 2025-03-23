/*
 * @lc app=leetcode id=1493 lang=java
 *
 * [1493] Longest Subarray of 1's After Deleting One Element
 */

// @lc code=start
class Solution {
    public int longestSubarray(int[] nums) {
        int n = nums.length, acc = 0, max = 0, ret = 0, prevAcc = 0;
        for (int i = 0; i <= n; ++i) {
            if (i < n && nums[i] == 1) {
                ++acc;
                continue;
            }
            if (i > 0 && nums[i - 1] == 1) {
                ret = Math.max(acc + prevAcc, ret);
                max = Math.max(acc, max);
                prevAcc = acc;
                acc = 0;
            } else {
                prevAcc = 0;
            }
        }
        if (max == n) {
            return n - 1;
        }
        return Math.max(max, ret);
    }
}
// @lc code=end

