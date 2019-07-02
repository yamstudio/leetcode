/*
 * @lc app=leetcode id=22 lang=csharp
 *
 * [22] Generate Parentheses
 */

using System.Collections.Generic;

public class Solution {

    private void generate(IList<string> ret, int n, int left, int right, string prefix) {
        if (right == n) {
            ret.Add(prefix);
            return;
        }
        if (left < n) {
            generate(ret, n, left + 1, right, prefix + "(");
        }
        if (right < left) {
            generate(ret, n, left, right + 1, prefix + ")");
        }
    }

    public IList<string> GenerateParenthesis(int n) {
        IList<string> ret = new List<string>();
        generate(ret, n, 0, 0, "");
        return ret;
    }
}

