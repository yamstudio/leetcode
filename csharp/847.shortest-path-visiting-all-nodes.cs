/*
 * @lc app=leetcode id=847 lang=csharp
 *
 * [847] Shortest Path Visiting All Nodes
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int ShortestPathLength(int[][] graph) {
        int n = graph.Length, target = (1 << n) - 1, ret = 0;
        var visited = new HashSet<(int State, int Node)>();
        var queue = new Queue<(int State, int Node)>();
        for (int i = 0; i < n; ++i) {
            var curr = (State: 1 << i, Node: i);
            visited.Add(curr);
            queue.Enqueue(curr);
        }
        while (queue.Count > 0) {
            int count = queue.Count;
            while (count-- > 0) {
                var curr = queue.Dequeue();
                if (curr.State == target) {
                    return ret;
                }
                foreach (var node in graph[curr.Node]) {
                    var next = (State: curr.State | (1 << node), Node: node);
                    if (visited.Contains(next)) {
                        continue;
                    }
                    visited.Add(next);
                    queue.Enqueue(next);
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

