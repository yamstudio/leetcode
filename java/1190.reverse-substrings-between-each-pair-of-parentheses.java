/*
 * @lc app=leetcode id=1190 lang=java
 *
 * [1190] Reverse Substrings Between Each Pair of Parentheses
 */

// @lc code=start
class Solution {
    public String reverseParentheses(String s) {
        var stack = new java.util.Stack<Integer>();
        int n = s.length(), m = 0;
        int[] paren = new int[n];
        for (int i = 0; i < n; ++i) {
            char c = s.charAt(i);
            if (c == '(') {
                stack.push(i);
            } else if (c == ')') {
                int open = stack.pop();
                paren[open] = i;
                paren[i] = open;
            } else {
                ++m;
            }
        }
        StringBuilder sb = new StringBuilder(m);
        for (int i = 0, d = 1; i < n; i += d) {
            char c = s.charAt(i);
            if (c == '(' || c == ')') {
                d = -d;
                i = paren[i];
            } else {
                sb.append(c);
            }
        }
        return sb.toString();
    }
}
// @lc code=end

