/*
 * @lc app=leetcode id=946 lang=java
 *
 * [946] Validate Stack Sequences
 */

import java.util.Stack;

// @lc code=start
class Solution {
    public boolean validateStackSequences(int[] pushed, int[] popped) {
        Stack<Integer> stack = new Stack<>();
        int i = 0;
        stack.push(-1);
        for (int pop : popped) {
            while (i < pushed.length && stack.peek() != pop) {
                stack.push(pushed[i++]);
            }
            if (stack.peek() == pop) {
                stack.pop();
            } else {
                return false;
            }
        }
        return i == pushed.length && stack.size() == 1;
    }
}
// @lc code=end

