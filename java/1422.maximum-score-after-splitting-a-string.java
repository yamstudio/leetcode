/*
 * @lc app=leetcode id=1422 lang=java
 *
 * [1422] Maximum Score After Splitting a String
 */

// @lc code=start
class Solution {
    public int maxScore(String s) {
        int n = s.length(), ones = 0;
        for (int i = 0; i < n; ++i) {
            if (s.charAt(i) == '1') {
                ++ones;
            }
        }
        int ret = 0, zeroes = 0;
        for (int i = 0; i + 1 < n; ++i) {
            if (s.charAt(i) == '0') {
                ++zeroes;
            } else {
                --ones;
            }
            ret = Math.max(ret, zeroes + ones);
        }
        return ret;
    }
}
// @lc code=end

