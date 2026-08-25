/*
 * @lc app=leetcode id=1800 lang=java
 *
 * [1800] Maximum Ascending Subarray Sum
 */

// @lc code=start
class Solution {
    public int maxAscendingSum(int[] nums) {
        int acc = 0, ret = 0, p = 0;
        for (int x : nums) {
            if (x > p) {
                acc += x;
            } else {
                acc = x;
            }
            ret = Math.max(ret, acc);
            p = x;
        }
        return ret;
    }
}
// @lc code=end

