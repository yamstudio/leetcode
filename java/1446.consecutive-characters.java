/*
 * @lc app=leetcode id=1446 lang=java
 *
 * [1446] Consecutive Characters
 */

// @lc code=start
class Solution {
    public int maxPower(String s) {
        char c = '\n';
        int acc = 0, ret = 0, n = s.length();
        for (int i = 0; i < n; ++i) {
            char t = s.charAt(i);
            if (t == c) {
                ++acc;
            } else {
                acc = 1;
                c = t;
            }
            ret = Math.max(ret, acc);
        }
        return ret;
    }
}
// @lc code=end

