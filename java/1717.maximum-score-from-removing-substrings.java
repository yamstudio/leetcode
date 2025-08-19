/*
 * @lc app=leetcode id=1717 lang=java
 *
 * [1717] Maximum Score From Removing Substrings
 */

// @lc code=start
class Solution {
    public int maximumGain(String s, int x, int y) {
        int m = Math.min(x, y), n = s.length(), ret = 0, a = 0, b = 0;
        for (int i = 0; i < n; ++i) {
            char c = s.charAt(i);
            if (c == 'a') {
                if (y > x && b > 0) {
                    --b;
                    ret += y;
                } else {
                    ++a;
                }
            } else if (c == 'b') {
                if (x > y && a > 0) {
                    --a;
                    ret += x;
                } else {
                    ++b;
                }
            } else {
                ret += Math.min(a, b) * m;
                a = 0;
                b = 0;
            }
        }
        ret += Math.min(a, b) * m;
        return ret;
    }
}
// @lc code=end

