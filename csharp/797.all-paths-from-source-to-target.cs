/*
 * @lc app=leetcode id=797 lang=csharp
 *
 * [797] All Paths From Source to Target
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static void AllPathsSourceTargetRecurse(IList<IList<int>> ret, IList<int> path, int[][] graph, int target) {
        int n = path.Count, curr = path[n - 1];
        if (curr == target) {
            ret.Add(new List<int>(path));
            return;
        }
        foreach (var next in graph[curr]) {
            path.Add(next);
            AllPathsSourceTargetRecurse(ret, path, graph, target);
            path.RemoveAt(n);
        }
    }

    public IList<IList<int>> AllPathsSourceTarget(int[][] graph) {
        var ret = new List<IList<int>>();
        AllPathsSourceTargetRecurse(ret, new List<int>{ 0 }, graph, graph.Length - 1);
        return ret;
    }
}
// @lc code=end

