/*
 * @lc app=leetcode id=1375 lang=java
 *
 * [1375] Number of Times Binary String Is Prefix-Aligned
 */

// @lc code=start
class Solution {
    public int numTimesAllBlue(int[] flips) {
        int ret = 0, n = flips.length, max = -1;
        for (int i = 0; i < n; ++i) {
            max = Math.max(flips[i] - 1, max);
            if (max == i) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

