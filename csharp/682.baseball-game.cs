/*
 * @lc app=leetcode id=682 lang=csharp
 *
 * [682] Baseball Game
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int CalPoints(string[] ops) {
        IList<int> stack = new List<int>();
        foreach (var op in ops) {
            if (op == "C") {
                stack.RemoveAt(stack.Count - 1);
            } else if (op == "D") {
                stack.Add(2 * stack[stack.Count - 1]);
            } else if (op == "+") {
                stack.Add(stack[stack.Count - 1] + stack[stack.Count - 2]);
            } else {
                stack.Add(int.Parse(op));
            }
        }
        return stack.Sum();
    }
}
// @lc code=end

