/*
 * @lc app=leetcode id=1413 lang=java
 *
 * [1413] Minimum Value to Get Positive Step by Step Sum
 */

// @lc code=start
class Solution {
    public int minStartValue(int[] nums) {
        int acc = 0, min = Integer.MAX_VALUE;
        for (int num : nums) {
            acc += num;
            min = Math.min(min, acc);
        }
        return min > 0 ? 1 : (-min + 1);
    }
}
// @lc code=end

