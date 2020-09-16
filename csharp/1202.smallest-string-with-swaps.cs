/*
 * @lc app=leetcode id=1202 lang=csharp
 *
 * [1202] Smallest String With Swaps
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int FindRoot(int[] roots, int curr) {
        int root = roots[curr];
        if (root == curr) {
            return root;
        }
        return roots[curr] = FindRoot(roots, root);
    }

    public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs) {
        int n = s.Length;
        int[] roots = Enumerable.Range(0, n).ToArray();
        var all = new IList<int>[n];
        var ret = s.ToArray();
        foreach (var pair in pairs) {
            roots[FindRoot(roots, pair[0])] = FindRoot(roots, pair[1]);
        }
        for (int i = 0; i < n; ++i) {
            int root = FindRoot(roots, i);
            if (all[root] == null) {
                all[root] = new List<int>();
            }
            all[root].Add(i);
        }
        foreach (var l in all) {
            if (l == null) {
                continue;
            }
            var zipped = l
                .OrderBy(i => i)
                .Zip(l.OrderBy(i => s[i]), (int index, int swap) => (Index: index, Value: s[swap]));
            foreach (var t in zipped) {
                ret[t.Index] = t.Value;
            }
        }
        return new string(ret);
    }
}
// @lc code=end

