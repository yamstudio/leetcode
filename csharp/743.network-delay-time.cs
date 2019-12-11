/*
 * @lc app=leetcode id=743 lang=csharp
 *
 * [743] Network Delay Time
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int NetworkDelayTime(int[][] times, int N, int K) {
        Queue<int> queue = new Queue<int>();
        var edges = new Dictionary<int, HashSet<(int Target, int Time)>>();
        int[] dists = new int[N];
        var set = new HashSet<int>();
        foreach (var tuple in times) {
            int source = tuple[0] - 1;
            HashSet<(int Target, int Time)> s;
            if (!edges.TryGetValue(source, out s)) {
                s = new HashSet<(int Target, int Time)>();
                edges[source] = s;
            }
            s.Add((Target: tuple[1] - 1, Time: tuple[2]));
        }
        for (int i = 0; i < N; ++i) {
            dists[i] = int.MaxValue;
        }
        dists[K - 1] = 0;
        queue.Enqueue(K - 1);
        while (queue.Count > 0) {
            set.Clear();
            int count = queue.Count;
            while (count-- > 0) {
                int u = queue.Dequeue();
                if (edges.TryGetValue(u, out var s)) {
                    foreach (var nb in s) {
                        int v = nb.Target, t = nb.Time;
                        if (dists[u] + t < dists[v]) {
                            if (!set.Contains(v)) {
                                set.Add(v);
                                queue.Enqueue(v);
                            }
                            dists[v] = dists[u] + t;
                        }
                    }
                }
            }
        }
        int ret = dists.Max();
        return ret == int.MaxValue ? -1 : ret;
    }
}
// @lc code=end

