/*
 * @lc app=leetcode id=1827 lang=java
 *
 * [1827] Minimum Operations to Make the Array Increasing
 */

// @lc code=start
class Solution {
    public int minOperations(int[] nums) {
        int acc = 0, p = 0;
        for (int x : nums) {
            if (x <= p) {
                acc += p + 1 - x;
                p++;
            } else {
                p = x;
            }
        }
        return acc;
    }
}
// @lc code=end

