/*
 * @lc app=leetcode id=310 lang=csharp
 *
 * [310] Minimum Height Trees
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> FindMinHeightTrees(int n, int[][] edges) {
        if (n == 1) {
            return new List<int> { 0 };
        }
        Queue<int> queue = new Queue<int>(n);
        IDictionary<int, ISet<int>> nb = new Dictionary<int, ISet<int>>();
        foreach (int[] edge in edges) {
            int v1 = edge[0], v2 = edge[1];
            if (!nb.ContainsKey(v1)) {
                nb[v1] = new HashSet<int> { v2 };
            } else {
                nb[v1].Add(v2);
            }
            if (!nb.ContainsKey(v2)) {
                nb[v2] = new HashSet<int> { v1 };
            } else {
                nb[v2].Add(v1);
            }
        }
        foreach (var entry in nb) {
            if (entry.Value.Count == 1) {
                queue.Enqueue(entry.Key);
            }
        }
        while (n > 2) {
            int size = queue.Count;
            for (int i = 0; i < size; ++i) {
                int rm = queue.Dequeue();
                foreach (int next in nb[rm]) {
                    nb[next].Remove(rm);
                    if (nb[next].Count == 1) {
                        queue.Enqueue(next);
                    }
                }
            }
            n -= size;
        }
        return new List<int>(queue);
    }
}

