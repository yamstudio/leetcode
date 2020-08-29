/*
 * @lc app=leetcode id=1096 lang=csharp
 *
 * [1096] Brace Expansion II
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// @lc code=start
public class Solution {

    private static void Merge(IList<HashSet<string>> all, HashSet<string> ret, StringBuilder sb, int level) {
        if (level == all.Count) {
            ret.Add(sb.ToString());
            return;
        }
        foreach (string s in all[level]) {
            sb.Append(s);
            Merge(all, ret, sb, level + 1);
            sb.Remove(sb.Length - s.Length, s.Length);
        }
    }

    private static HashSet<string> BraceExpansionIIRecurse(string expression, int n, ref int i) {
        var sb = new StringBuilder();
        if (expression[i] != '{') {
            while (i < n && Char.IsLetter(expression[i])) {
                sb.Append(expression[i++]);
            }
            return new HashSet<string>() { sb.ToString() };
        }
        ++i;
        var ret = new HashSet<string>();
        while (i < n && expression[i] != '}') {
            var all = new List<HashSet<string>>();
            while (i < n && expression[i] != ',' && expression[i] != '}') {
                all.Add(BraceExpansionIIRecurse(expression, n, ref i));
            }
            Merge(all, ret, sb, 0);
            if (i < n && expression[i] == ',') {
                ++i;
            }
        }
        ++i;
        return ret;
    }

    public IList<string> BraceExpansionII(string expression) {
        int i = 0;
        return BraceExpansionIIRecurse($"{{{expression}}}", 2 + expression.Length, ref i).OrderBy(s => s).ToList();
    }
}
// @lc code=end

