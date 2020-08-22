/*
 * @lc app=leetcode id=1047 lang=csharp
 *
 * [1047] Remove All Adjacent Duplicates In String
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string RemoveDuplicates(string S) {
        var stack = new Stack<char>();
        foreach (char c in S) {
            if (stack.TryPeek(out char t) && t == c) {
                stack.Pop();
            } else {
                stack.Push(c);
            }
        }
        return new string(stack.Reverse().ToArray());
    }
}
// @lc code=end

