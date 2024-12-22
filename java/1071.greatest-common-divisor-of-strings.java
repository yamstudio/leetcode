/*
 * @lc app=leetcode id=1071 lang=java
 *
 * [1071] Greatest Common Divisor of Strings
 */

// @lc code=start
class Solution {
    public String gcdOfStrings(String str1, String str2) {
        String l, r;
        if (str1.length() > str2.length()) {
            l = str1;
            r = str2;
        } else {
            l = str2;
            r = str1;
        }
        int rl = r.length();
        for (int i = 0; i < rl; ++i) {
            if (l.charAt(i) != r.charAt(i)) {
                return "";
            }
        }
        if (l.length() == rl) {
            return l;
        }
        return gcdOfStrings(r, l.substring(rl));
    }
}
// @lc code=end

