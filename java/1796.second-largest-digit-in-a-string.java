/*
 * @lc app=leetcode id=1796 lang=java
 *
 * [1796] Second Largest Digit in a String
 */

// @lc code=start
class Solution {
    public int secondHighest(String s) {
        int a = '\0', b = '\0', n = s.length();
        for (int i = 0; i < n; ++i) {
            char c = s.charAt(i);
            if (c < '0' || c > '9') {
                continue;
            }
            if (c > a) {
                b = a;
                a = c;
            } else if (c != a && c > b) {
                b = c;
            }
        }
        return b == '\0' ? -1 : (b - '0');
    }
}
// @lc code=end

