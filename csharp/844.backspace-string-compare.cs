/*
 * @lc app=leetcode id=844 lang=csharp
 *
 * [844] Backspace String Compare
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static string GetResult(string s) {
        var stack = new List<char>();
        foreach (var c in s) {
            if (c == '#') {
                if (stack.Count > 0) {
                    stack.RemoveAt(stack.Count - 1);
                }
            } else {
                stack.Add(c);
            }
        }
        return string.Join("", stack);
    }

    public bool BackspaceCompare(string S, string T) {
        return GetResult(S) == GetResult(T);
    }
}
// @lc code=end

