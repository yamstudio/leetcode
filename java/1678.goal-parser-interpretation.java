/*
 * @lc app=leetcode id=1678 lang=java
 *
 * [1678] Goal Parser Interpretation
 */

// @lc code=start
class Solution {
    public String interpret(String command) {
        char prev = ')';
        StringBuilder sb = new StringBuilder();
        int n = command.length();
        for (int i = 0; i < n; ++i) {
            char c = command.charAt(i);
            if (c == 'G') {
                sb.append('G');
            } else if (c == ')') {
                if (prev == '(') {
                    sb.append('o');
                } else {
                    sb.append("al");
                }
            }
            prev = c;
        }
        return sb.toString();
    }
}
// @lc code=end

