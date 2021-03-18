/*
 * @lc app=leetcode id=921 lang=java
 *
 * [921] Minimum Add to Make Parentheses Valid
 */

// @lc code=start
class Solution {
    public int minAddToMakeValid(String S) {
        int ret = 0, l = 0;
        for (char c : S.toCharArray()) {
            if (c == '(') {
                ++l;
            } else {
                if (l > 0) {
                    --l;
                } else {
                    ++ret;
                }
            }
        }
        return l + ret;
    }
}
// @lc code=end

