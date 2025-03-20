/*
 * @lc app=leetcode id=1480 lang=java
 *
 * [1480] Running Sum of 1d Array
 */

// @lc code=start
class Solution {
    public int[] runningSum(int[] nums) {
        int n = nums.length;
        int[] ret = new int[n];
        ret[0] = nums[0];
        for (int i = 1; i < n; ++i) {
            ret[i] = nums[i] + ret[i - 1];
        }
        return ret;
    }
}
// @lc code=end

