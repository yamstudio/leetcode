/*
 * @lc app=leetcode id=1021 lang=java
 *
 * [1021] Remove Outermost Parentheses
 */

// @lc code=start
class Solution {
    public String removeOuterParentheses(String s) {
        StringBuilder sb = new StringBuilder();
        int level = 0, n = s.length();
        for (int i = 0 ; i < n; ++i) {
            if (s.charAt(i) == '(') {
                if (level++ > 0) {
                    sb.append('(');
                }
            } else {
                if (--level > 0) {
                    sb.append(')');
                }
            }
        }
        return sb.toString();
    }
}
// @lc code=end

