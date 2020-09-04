/*
 * @lc app=leetcode id=1129 lang=csharp
 *
 * [1129] Shortest Path with Alternating Colors
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges) {
        var edges = new Dictionary<(int Node, bool IsRed), HashSet<int>>();
        var visited = new HashSet<(int Node, bool IsRed)>();
        var queue = new Queue<(int Node, bool IsRed)>();
        var ret = Enumerable.Repeat(-1, n).ToArray();
        int acc = 0, updated = 0;
        foreach (var edge in red_edges) {
            int s = edge[0], t = edge[1];
            var key = (Node: s, IsRed: true);
            if (!edges.TryGetValue(key, out var ts)) {
                ts = new HashSet<int>();
                edges[key] = ts;
            }
            ts.Add(t);
        }
        foreach (var edge in blue_edges) {
            int s = edge[0], t = edge[1];
            var key = (Node: s, IsRed: false);
            if (!edges.TryGetValue(key, out var ts)) {
                ts = new HashSet<int>();
                edges[key] = ts;
            }
            ts.Add(t);
        }
        visited.Add((Node: 0, IsRed: true));
        visited.Add((Node: 0, IsRed: false));
        queue.Enqueue((Node: 0, IsRed: true));
        queue.Enqueue((Node: 0, IsRed: false));
        while (queue.Count > 0 && updated < n) {
            for (int i = queue.Count; i > 0; --i) {
                var curr = queue.Dequeue();
                if (ret[curr.Node] == -1) {
                    ++updated;
                    ret[curr.Node] = acc;
                }
                if (!edges.TryGetValue(curr, out var ts)) {
                    continue;
                }
                foreach (var t in ts) {
                    var key = (Node: t, IsRed: !curr.IsRed);
                    if (!visited.Add(key)) {
                        continue;
                    }
                    queue.Enqueue(key);
                }
            }
            ++acc;
        }
        return ret;
    }
}
// @lc code=end

