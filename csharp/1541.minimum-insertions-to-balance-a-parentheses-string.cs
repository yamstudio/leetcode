/*
 * @lc app=leetcode id=1541 lang=csharp
 *
 * [1541] Minimum Insertions to Balance a Parentheses String
 */

// @lc code=start
public class Solution {
    public int MinInsertions(string s) {
        int l = 0, n = s.Length, i = 0, ret = 0;
        while (i < s.Length) {
            while (i < s.Length && s[i] == '(') {
                ++i;
                ++l;
            }
            int r = 0;
            while (i < s.Length && s[i] == ')') {
                ++i;
                ++r;
            }
            while (r > 1) {
                r -= 2;
                if (l > 0) {
                    --l;
                } else {
                    ret += 1;
                }
            }
            if (r == 1) {
                if (l == 0) {
                    ret += 2;
                } else {
                    ++ret;
                    --l;
                }
            }
        }
        return ret + 2 * l;
    }
}
// @lc code=end

