/*
 * @lc app=leetcode id=1003 lang=csharp
 *
 * [1003] Check If Word Is Valid After Substitutions
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public bool IsValid(string S) {
        var stack = new Stack<int>();
        foreach (char c in S) {
            if (c == 'a') {
                stack.Push(0);
            } else if (c == 'b') {
                if (!stack.TryPeek(out int t) || t != 0) {
                    return false;
                }
                stack.Push(1);
            } else {
                if (!stack.TryPeek(out int t) || t != 1) {
                    return false;
                }
                stack.Pop();
                stack.Pop();
            }
        }
        return stack.Count == 0;
    }
}
// @lc code=end

