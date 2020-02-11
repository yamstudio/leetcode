/*
 * @lc app=leetcode id=833 lang=csharp
 *
 * [833] Find And Replace in String
 */

using System.Text;
using System.Linq;

// @lc code=start
public class Solution {
    public string FindReplaceString(string S, int[] indexes, string[] sources, string[] targets) {
        int n = S.Length, k = indexes.Length, pi = 0, j = 0;
        var sb = new StringBuilder();
        foreach (var tuple in indexes
            .Zip(sources, (index, source) => (Index: index, Source: source))
            .Zip(targets, (tuple, target) => (Index: tuple.Index, Source: tuple.Source, Target: target))
            .OrderBy(tuple => tuple.Index)
            .Append((Index: n, Source: "$", Target: ""))) {
            sb.Append(S.Substring(pi, tuple.Index - pi));
            if (tuple.Index + tuple.Source.Length <= n && S.Substring(tuple.Index, tuple.Source.Length) == tuple.Source) {
                sb.Append(tuple.Target);
                pi = tuple.Index + tuple.Source.Length;
            } else {
                pi = tuple.Index;
            }
            if (pi >= n) {
                break;
            }
        }
        return sb.ToString();
    }
}
// @lc code=end

