/*
 * @lc app=leetcode id=1249 lang=java
 *
 * [1249] Minimum Remove to Make Valid Parentheses
 */

import java.util.HashSet;
import java.util.Set;
import java.util.Stack;

// @lc code=start

class Solution {
    public String minRemoveToMakeValid(String s) {
        int n = s.length();
        Stack<Integer> lefts = new Stack<>();
        Set<Integer> unmatched = new HashSet<>();
        for (int i = 0; i < s.length(); ++i) {
            char c = s.charAt(i);
            if (c == '(') {
                lefts.push(i);
            } else if (c == ')') {
                if (lefts.isEmpty()) {
                    unmatched.add(i);
                } else {
                    lefts.pop();
                }
            }
        }
        while (!lefts.isEmpty()) {
            unmatched.add(lefts.pop());
        }
        StringBuilder sb = new StringBuilder(n - unmatched.size());
        for (int i = 0; i < n; ++i) {
            if (unmatched.contains(i)) {
                continue;
            }
            sb.append(s.charAt(i));
        }
        return sb.toString();
    }
}
// @lc code=end

