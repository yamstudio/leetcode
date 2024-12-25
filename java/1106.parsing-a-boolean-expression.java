/*
 * @lc app=leetcode id=1106 lang=java
 *
 * [1106] Parsing A Boolean Expression
 */

import java.util.Stack;

// @lc code=start
class Solution {
    public boolean parseBoolExpr(String expression) {
        Stack<Character> stack = new Stack<>();
        int n = expression.length();
        for (int i = 0; i < n; ++i) {
            char c = expression.charAt(i);
            if (c == '(' || c == ',') {
                continue;
            }
            if (c != ')') {
                stack.push(c);
                continue;
            }
            boolean and = true, or = false, last = false;
            char t;
            do {
                t = stack.pop();
                if (t == 't') {
                    or = true;
                    last = true;
                } else if (t == 'f') {
                    and = false;
                    last = false;
                } else {
                    break;
                }
            } while (true);
            if (t == '!') {
                stack.push(last ? 'f' : 't');
            } else if (t == '|') {
                stack.push(or ? 't' : 'f');
            } else {
                stack.push(and ? 't' : 'f');
            }
        }
        return stack.pop() == 't';
    }
}
// @lc code=end

