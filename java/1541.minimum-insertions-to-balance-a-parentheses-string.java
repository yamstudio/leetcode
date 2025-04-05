/*
 * @lc app=leetcode id=1541 lang=java
 *
 * [1541] Minimum Insertions to Balance a Parentheses String
 */

// @lc code=start

class Solution {
    public int minInsertions(String s) {
        int n = s.length(), ret = 0, l = 0, i = 0;
        while (i < n) {
            while (i < n && s.charAt(i) == '(') {
                ++i;
                ++l;
            }
            int r = 0;
            while (i < n && s.charAt(i) == ')') {
                ++i;
                ++r;
            }
            while (r > 1) {
                r -= 2;
                if (l > 0) {
                    --l;
                } else {
                    ++ret;
                }
            }
            if (r == 1) {
                if (l == 0) {
                    ret += 2;
                } else {
                    --l;
                    ++ret;
                }
            }
        }
        return ret + 2 * l;
    }
}
// @lc code=end

