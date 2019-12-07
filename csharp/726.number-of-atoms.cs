/*
 * @lc app=leetcode id=726 lang=csharp
 *
 * [726] Number of Atoms
 */

using System.Collections.Generic;
using System.Linq;
using System;

// @lc code=start
public class Solution {

    private (IDictionary<string, int> atoms, int index) CountOfAtomsRecurse(string formula, int i) {
        IDictionary<string, int> ret = new Dictionary<string, int>();
        int n = formula.Length;
        while (i < n) {
            char c = formula[i];
            if (c == '(') {
                var inner = CountOfAtomsRecurse(formula, i + 1);
                foreach (var tuple in inner.atoms) {
                    ret.TryGetValue(tuple.Key, out int count);
                    count += tuple.Value;
                    ret[tuple.Key] = count;
                }
                i = inner.index;
            } else if (c == ')') {
                ++i;
                int j = i;
                while (j < n && formula[j] >= '0' && formula[j] <= '9') {
                    ++j;
                }
                if (j > i) {
                    int mul = int.Parse(formula.Substring(i, j - i));
                    foreach (var name in ret.Keys.ToArray()) {
                        ret[name] *= mul;
                    }
                    i = j;
                }
                break;
            } else {
                int j = i + 1;
                if (j < n && formula[j] >= 'a' && formula[j] <= 'z') {
                    ++j;
                }
                string name = formula.Substring(i, j - i);
                ret.TryGetValue(name, out int count);
                i = j;
                while (j < n && formula[j] >= '0' && formula[j] <= '9') {
                    ++j;
                }
                count += i == j ? 1 : int.Parse(formula.Substring(i, j - i));
                ret[name] = count;
                i = j;
            }
        }
        return (atoms: ret, index: i);
    }

    public string CountOfAtoms(string formula) {
        return string.Concat(CountOfAtomsRecurse(formula, 0).atoms.Select(tuple => tuple.Value > 1 ? $"{tuple.Key}{tuple.Value}" : tuple.Key).OrderBy(s => s, StringComparer.Ordinal));
    }
}
// @lc code=end

