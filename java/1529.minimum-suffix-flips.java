/*
 * @lc app=leetcode id=1529 lang=java
 *
 * [1529] Minimum Suffix Flips
 */

// @lc code=start
class Solution {
    public int minFlips(String target) {
        int ret = 0, n = target.length();
        char t = '0';
        for (int i = 0; i < n; ++i) {
            char c = target.charAt(i);
            if (t != c) {
                ++ret;
            }
            t = c;
        }
        return ret;
    }
}
// @lc code=end

