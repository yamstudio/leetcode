/*
 * @lc app=leetcode id=1697 lang=csharp
 *
 * [1697] Checking Existence of Edge Length Limited Paths
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int FindRoot(int[] roots, int i) {
        return roots[i] == i ? i : roots[i] = FindRoot(roots, roots[i]);
    }

    public bool[] DistanceLimitedPathsExist(int n, int[][] edgeList, int[][] queries) {
        var ret = new bool[queries.Length];
        int k = edgeList.Length, i = 0;
        var roots = Enumerable.Range(0, n).ToArray();
        Array.Sort(edgeList, Comparer<int[]>.Create((a, b) => a[2].CompareTo(b[2])));
        foreach (var tuple in queries
            .Select((q, i) => (Index: i, Query: q))
            .OrderBy(t => t.Query[2])) {
            var query = tuple.Query;
            int from = query[0], to = query[1], limit = query[2];
            for (; i < k && edgeList[i][2] < limit; ++i) {
                int a = edgeList[i][0], b = edgeList[i][1];
                roots[FindRoot(roots, a)] = FindRoot(roots, b);
            }
            ret[tuple.Index] = FindRoot(roots, from) == FindRoot(roots, to);
        }
        return ret;
    }
}
// @lc code=end

