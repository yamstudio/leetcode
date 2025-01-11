/*
 * @lc app=leetcode id=1221 lang=java
 *
 * [1221] Split a String in Balanced Strings
 */

// @lc code=start
class Solution {
    public int balancedStringSplit(String s) {
        int n = s.length(), ret = 0, c = 0;
        for (int i = 0; i < n; ++i) {
            c += s.charAt(i) == 'L' ? -1 : 1;
            if (c == 0) {
                ++ret;
            }
        }
        return ret;
    }
}
// @lc code=end

