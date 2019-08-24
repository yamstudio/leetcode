/*
 * @lc app=leetcode id=301 lang=csharp
 *
 * [301] Remove Invalid Parentheses
 */

using System.Collections.Generic;

public class Solution {
    public IList<string> RemoveInvalidParentheses(string s) {
        IList<string> ret = new List<string>();
        int left = 0, right = 0;
        foreach (char c in s) {
            if (c == '(') {
                ++left;
            } else if (c == ')') {
                if (left == 0) {
                    ++right;
                } else {
                    --left;
                }
            }
        }
        RemoveInvalidParenthesesRecurse(s, left, right, 0, ret);
        return ret;
    }

    private static bool IsValid(string s) {
        int count = 0;
        foreach (char c in s) {
            if (c == '(') {
                ++count;
            } else if (c == ')') {
                --count;
                if (count < 0) {
                    return false;
                }
            }
        }
        return count == 0;
    }

    private static void RemoveInvalidParenthesesRecurse(string s, int left, int right, int start, IList<string> ret) {
        if (left == 0 && right == 0) {
            if (IsValid(s)) {
                ret.Add(s);
            }
            return;
        }
        for (int i = start; i < s.Length; ++i) {
            if (i > start && s[i] == s[i - 1]) {
                continue;
            }
            if (left > 0 && s[i] == '(') {
                RemoveInvalidParenthesesRecurse($"{s.Substring(0, i)}{s.Substring(i + 1)}", left - 1, right, i, ret);
            }
            if (right > 0 && s[i] == ')') {
                RemoveInvalidParenthesesRecurse($"{s.Substring(0, i)}{s.Substring(i + 1)}", left, right - 1, i, ret);
            }
        }
    }
}

