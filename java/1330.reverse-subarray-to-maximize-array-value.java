/*
 * @lc app=leetcode id=1330 lang=java
 *
 * [1330] Reverse Subarray To Maximize Array Value
 */

// @lc code=start
class Solution {
    public int maxValueAfterReverse(int[] nums) {
        int sum = 0, n = nums.length, minmax = Integer.MAX_VALUE, maxmin = Integer.MIN_VALUE;
        for (int i = 1; i < n; ++i) {
            int p = nums[i - 1], c = nums[i];
            minmax = Math.min(minmax, Math.max(c, p));
            maxmin = Math.max(maxmin, Math.min(c, p));
            sum += Math.abs(c - p);
        }
        int delta = 2 * (maxmin - minmax);
        for (int i = 1; i < n; ++i) {
            delta = Math.max(
                delta,
                Math.max(
                    Math.abs(nums[i] - nums[0]),
                    Math.abs(nums[i - 1] - nums[n - 1])
                ) - Math.abs(nums[i] - nums[i - 1]));
        }
        return sum + delta;
    }
}
// @lc code=end

