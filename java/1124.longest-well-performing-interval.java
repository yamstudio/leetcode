/*
 * @lc app=leetcode id=1124 lang=java
 *
 * [1124] Longest Well-Performing Interval
 */

// @lc code=start
class Solution {
    public int longestWPI(int[] hours) {
        int n = hours.length, acc = n + 1, ret = 0;
        int[] countToIndex = new int[2 * n + 2];
        for (int i = 0; i < n; ++i) {
            if (hours[i] <= 8) {
                --acc;
            } else {
                ++acc;
            }
            if (countToIndex[acc] == 0) {
                countToIndex[acc] = i + 1;
            }
            if (acc > n + 1) {
                ret = Math.max(ret, i + 1);
            } else if (countToIndex[acc - 1] != 0) {
                ret = Math.max(ret, i + 1 - countToIndex[acc - 1]);
            }
        }
        return ret;
    }
}
// @lc code=end

