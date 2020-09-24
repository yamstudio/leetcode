/*
 * @lc app=leetcode id=1249 lang=csharp
 *
 * [1249] Minimum Remove to Make Valid Parentheses
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string MinRemoveToMakeValid(string s) {
        int n = s.Length;
        var stack = new Stack<int>();
        var invalid = new HashSet<int>();
        for (int i = 0; i < n; ++i) {
            if (s[i] == '(') {
                stack.Push(i);
            } else if (s[i] == ')') {
                if (!stack.TryPop(out int x)) {
                    invalid.Add(i);
                }
            }
        }
        invalid.UnionWith(stack);
        return new string(
            s.Where((char c, int i) => !invalid.Contains(i)).ToArray()
        );
    }
}
// @lc code=end

