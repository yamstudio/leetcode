/*
 * @lc app=leetcode id=1324 lang=csharp
 *
 * [1324] Print Words Vertically
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<string> PrintVertically(string s) {
        var split = s.Split(' ');
        int n = split.Max(t => t.Length);
        return split
            .SelectMany(t => t
                .Concat(Enumerable.Repeat(' ', n - t.Length))
                .Select((char c, int i) => (Index: i, Value: c)))
            .GroupBy(t => t.Index, (i, t) => new string(t.Select(k => k.Value).ToArray()).TrimEnd())
            .ToList();
    }
}
// @lc code=end

