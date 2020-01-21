/*
 * @lc app=leetcode id=767 lang=csharp
 *
 * [767] Reorganize String
 */

using System.Collections.Generic;
using System.Linq;
using System.Text;

// @lc code=start
public class Solution {
    public string ReorganizeString(string S) {
        var count = new Dictionary<char, int>();
        int n = S.Length;
        if (n < 3) {
            return S;
        }
        foreach (var c in S) {
            if (count.TryGetValue(c, out int val)) {
                if (val + 1 > (n + 1) / 2) {
                    return "";
                }
                count[c] = val + 1;
            } else {
                count[c] = 1;
            }
        }
        var sb = new StringBuilder();
        var sorted = new SortedSet<(char C, int V)>(count.Select(pair => (C: pair.Key, V: pair.Value)), Comparer<(char C, int V)>.Create((a, b) => a.V == b.V ? a.C.CompareTo(b.C) : a.V.CompareTo(b.V)));
        while (sorted.Count > 1) {
            var t1 = sorted.Max;
            sorted.Remove(t1);
            var t2 = sorted.Max;
            sorted.Remove(t2);
            sb.Append(t1.C);
            sb.Append(t2.C);
            if (t1.V > 1) {
                sorted.Add((C: t1.C, V: t1.V - 1));
            }
            if (t2.V > 1) {
                sorted.Add((C: t2.C, V: t2.V - 1));
            }
        }
        if (sorted.Count > 0) {
            sb.Append(sorted.Max.C);
        }
        return sb.ToString();
    }
}
// @lc code=end

