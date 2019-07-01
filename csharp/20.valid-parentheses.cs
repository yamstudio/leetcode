/*
 * @lc app=leetcode id=20 lang=csharp
 *
 * [20] Valid Parentheses
 */

using System.Collections.Generic;

public class Solution {
    public bool IsValid(string s) {
        List<char> stack = new List<char>();
        foreach (char c in s) {
            if (c == '(' || c == '[' || c == '{') {
                stack.Add(c);
                continue;
            }
            if (stack.Count == 0) {
                return false;
            } else {
                char top = stack[stack.Count - 1];
                if ((top == '(' && c != ')') || (top == '[' && c != ']') || (top == '{' && c != '}')) {
                    return false;
                }
                stack.RemoveAt(stack.Count - 1);
            }
        }
        return stack.Count == 0;
    }
}

