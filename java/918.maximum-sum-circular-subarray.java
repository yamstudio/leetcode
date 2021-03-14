/*
 * @lc app=leetcode id=918 lang=java
 *
 * [918] Maximum Sum Circular Subarray
 */

// @lc code=start
class Solution {
    public int maxSubarraySumCircular(int[] A) {
        int sum = 0, currMax = 0, currMin = 0, max = Integer.MIN_VALUE, min = Integer.MAX_VALUE;
        for (int x : A) {
            currMax = Math.max(currMax + x, x);
            max = Math.max(max, currMax);
            currMin = Math.min(currMin + x, x);
            min = Math.min(min, currMin);
            sum += x;
        }
        if (sum == min) {
            return max;
        }
        return Math.max(sum - min, max);
    }
}
// @lc code=end

