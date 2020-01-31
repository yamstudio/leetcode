/*
 * @lc app=leetcode id=802 lang=csharp
 *
 * [802] Find Eventual Safe States
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) {
        int n = graph.Length;
        bool[] ret = new bool[n];
        var queue = new Queue<int>();
        var rev = new HashSet<int>[n];
        var p = new HashSet<int>[n];
        for (int i = 0; i < n; ++i) {
            rev[i] = new HashSet<int>();
            p[i] = new HashSet<int>();
        }
        for (int i = 0; i < n; ++i) {
            var nb = graph[i];
            if (nb.Length == 0) {
                queue.Enqueue(i);
                continue;
            }
            foreach (var j in nb) {
                rev[j].Add(i);
                p[i].Add(j);
            }
        }
        while (queue.Count > 0) {
            int curr = queue.Dequeue();
            ret[curr] = true;
            foreach (var next in rev[curr]) {
                p[next].Remove(curr);
                if (p[next].Count == 0) {
                    queue.Enqueue(next);
                }
            }
        }
        return ret.Select((v, i) => (v, i)).Where(t => t.v).Select(t => t.i).ToList();
    }
}
// @lc code=end

