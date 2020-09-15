/*
 * @lc app=leetcode id=1190 lang=csharp
 *
 * [1190] Reverse Substrings Between Each Pair of Parentheses
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string ReverseParentheses(string s) {
        var stack = new Stack<string>();
        stack.Push("");
        foreach (var c in s) {
            if (c == '(') {
                stack.Push("");
            } else if (c == ')') {
                string t = stack.Pop();
                stack.Push($"{stack.Pop()}{new string(t.Reverse().ToArray())}");
            } else {
                stack.Push($"{stack.Pop()}{c}");
            }
        }
        return stack.Pop();
    }
}
// @lc code=end

