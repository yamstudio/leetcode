/*
 * @lc app=leetcode id=1130 lang=csharp
 *
 * [1130] Minimum Cost Tree From Leaf Values
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MctFromLeafValues(int[] arr) {
        var stack = new Stack<int>();
        int ret = 0;
        foreach (var num in arr) {
            while (stack.TryPeek(out int top) && top <= num) {
                stack.Pop();
                if (stack.TryPeek(out int next) && next <= num) {
                    ret += top * next;
                } else {
                    ret += top * num;
                    break;
                }
            }
            stack.Push(num);
        }
        while (stack.Count >= 2) {
            ret += stack.Pop() * stack.Peek();
        }
        return ret;
    }
}
// @lc code=end

