/*
 * @lc app=leetcode id=1732 lang=java
 *
 * [1732] Find the Highest Altitude
 */

// @lc code=start
class Solution {
    public int largestAltitude(int[] gain) {
        int acc = 0, ret = 0;
        for (int d : gain) {
            acc += d;
            ret = Math.max(ret, acc);
        }
        return ret;
    }
}
// @lc code=end

