/*
 * @lc app=leetcode id=882 lang=csharp
 *
 * [882] Reachable Nodes In Subdivided Graph
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int ReachableNodes(int[][] edges, int M, int N) {
        var edgeMap = new Dictionary<int, IDictionary<int, int>>();
        var sorted = new SortedSet<(int Steps, int Index)>();
        var visited = new HashSet<int>();
        int ret = 0;
        foreach (var edge in edges) {
            int a = edge[0], b = edge[1], count = edge[2];
            if (!edgeMap.TryGetValue(a, out var ma)) {
                ma = new Dictionary<int, int>();
                edgeMap[a] = ma;
            }
            if (!edgeMap.TryGetValue(b, out var mb)) {
                mb = new Dictionary<int, int>();
                edgeMap[b] = mb;
            }
            ma[b] = count;
            mb[a] = count;
        }
        sorted.Add((Steps: M, Index: 0));
        while (sorted.Count > 0) {
            var curr = sorted.Max;
            sorted.Remove(curr);
            int steps = curr.Steps, index = curr.Index;
            if (visited.Contains(index)) {
                continue;
            }
            visited.Add(index);
            ++ret;
            if (edgeMap.TryGetValue(index, out var map)) {
                foreach (var next in map) {
                    int delta;
                    if (steps > next.Value) {
                        delta = next.Value;
                        if (!visited.Contains(next.Key)) {
                            sorted.Add((Steps: steps - next.Value - 1, Index: next.Key));
                        }
                    } else {
                        delta = steps;
                    }
                    ret += delta;
                    edgeMap[next.Key][index] -= delta;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

