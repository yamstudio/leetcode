/*
 * @lc app=leetcode id=856 lang=java
 *
 * [856] Score of Parentheses
 */

// @lc code=start
class Solution {
    public int scoreOfParentheses(String S) {
        Stack<Integer> stack = new Stack<Integer>();
        int n = S.length();
        for (int i = 0; i < n; ++i) {
            if (S.charAt(i) == '(') {
                stack.push(0);
                continue;
            }
            int acc = 0;
            while (true) {
                int v = stack.pop();
                if (v == 0) {
                    break;
                }
                acc += v;
            }
            if (acc == 0) {
                stack.push(1);
            } else {
                stack.push(2 * acc);
            }
        }
        int ret = 0;
        while (stack.size() > 0) {
            ret += stack.pop();
        }
        return ret;
    }
}
// @lc code=end

