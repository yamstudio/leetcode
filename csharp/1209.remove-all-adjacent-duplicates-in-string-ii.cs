/*
 * @lc app=leetcode id=1209 lang=csharp
 *
 * [1209] Remove All Adjacent Duplicates in String II
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string RemoveDuplicates(string s, int k) {
        if (k == 1) {
            return "";
        }
        var stack = new Stack<(char Value, int Count)>();
        foreach (var c in s) {
            if (stack.TryPeek(out var top) && top.Value == c) {
                stack.Pop();
                if (top.Count < k - 1) {
                    stack.Push((Value: c, Count: top.Count + 1));
                }
            } else {
                stack.Push((Value: c, Count: 1));
            }
        }
        return new string(stack
            .SelectMany(t => Enumerable.Repeat(t.Value, t.Count))
            .Reverse()
            .ToArray());
    }
}
// @lc code=end

