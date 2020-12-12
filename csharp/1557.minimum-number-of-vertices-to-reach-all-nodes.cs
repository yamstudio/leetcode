/*
 * @lc app=leetcode id=1557 lang=csharp
 *
 * [1557] Minimum Number of Vertices to Reach All Nodes
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> FindSmallestSetOfVertices(int n, IList<IList<int>> edges) {
        var excluded = edges.Select(e => e[1]).ToHashSet();
        return Enumerable
            .Range(0, n)
            .Where(x => !excluded.Contains(x))
            .ToList();
    }
}
// @lc code=end

