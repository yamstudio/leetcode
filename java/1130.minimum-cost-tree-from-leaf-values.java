/*
 * @lc app=leetcode id=1130 lang=java
 *
 * [1130] Minimum Cost Tree From Leaf Values
 */

import java.util.Stack;

// @lc code=start
class Solution {
    public int mctFromLeafValues(int[] arr) {
        Stack<Integer> stack = new Stack<>();
        int ret = 0;
        for (int num : arr) {
            while (!stack.isEmpty() && stack.peek() <= num) {
                int pop = stack.pop();
                if (!stack.isEmpty() && stack.peek() <= num) {
                    ret += pop * stack.peek();
                } else {
                    ret += pop * num;
                    break;
                }
            }
            stack.push(num);
        }
        while (stack.size() > 1) {
            ret += stack.pop() * stack.peek();
        }
        return ret;
    }
}
// @lc code=end

