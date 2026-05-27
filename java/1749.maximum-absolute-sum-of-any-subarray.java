/*
 * @lc app=leetcode id=1749 lang=java
 *
 * [1749] Maximum Absolute Sum of Any Subarray
 */

// @lc code=start
class Solution {
    public int maxAbsoluteSum(int[] nums) {
        int ret = 0, sum = 0, minSum = 0, maxSum = 0;
        for (int x : nums) {
            sum += x;
            ret = Math.max(
                ret,
                Math.max(
                    Math.abs(sum - maxSum),
                    Math.abs(sum - minSum)
                )
            );
            maxSum = Math.max(maxSum, sum);
            minSum = Math.min(minSum, sum);
        }
        return ret;
    }
}
// @lc code=end

