/*
 * @lc app=leetcode id=1793 lang=java
 *
 * [1793] Maximum Score of a Good Subarray
 */

// @lc code=start
class Solution {
    public int maximumScore(int[] nums, int k) {
        int n = nums.length, i = k, j = k, ret = nums[k], min = nums[k];
        while (i > 0 || j < n - 1) {
            if (i == 0 || (j != n - 1 && nums[i - 1] < nums[j + 1])) {
                ++j;
            } else {
                --i;
            }
            min = Math.min(min, Math.min(nums[i], nums[j]));
            ret = Math.max(ret, min * (j - i + 1));
        }
        return ret;
    }
}
// @lc code=end

