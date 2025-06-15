/*
 * @lc app=leetcode id=1685 lang=java
 *
 * [1685] Sum of Absolute Differences in a Sorted Array
 */

// @lc code=start
class Solution {
    public int[] getSumAbsoluteDifferences(int[] nums) {
        int acc = 0, n = nums.length, sum = 0;
        int[] ret = new int[n];
        for (int x : nums) {
            sum += x;
        }
        for (int i = 0; i < n; ++i) {
            ret[i] = nums[i] * i - acc + (sum - acc) - (n - i) * nums[i];
            acc += nums[i];
        }
        return ret;
    }
}
// @lc code=end

