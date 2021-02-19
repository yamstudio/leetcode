/*
 * @lc app=leetcode id=880 lang=java
 *
 * [880] Decoded String at Index
 */

// @lc code=start
class Solution {
    public String decodeAtIndex(String S, int K) {
        long len = 0, r = (long)K;
        int i, n = S.length();
        for (i = 0; len < r; ++i) {
            char c = S.charAt(i);
            if (c <= 'z' && c >= 'a') {
                len++;
            } else {
                len *= (long)c - (long)'0';
            }
        }
        for (--i; i >= 0; --i) {
            char c = S.charAt(i);
            if (c <= 'z' && c >= 'a') {
                if (r % len == 0) {
                    return Character.toString(c);
                }
                --len;
            } else {
                len /= (long)c - (long)'0';
                r %= len;
            }
        }
        return "";
    }
}
// @lc code=end

