/*
 * @lc app=leetcode id=1377 lang=csharp
 *
 * [1377] Frog Position After T Seconds
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public double FrogPosition(int n, int[][] edges, int t, int target) {
        if (n == 1) {
            return 1.0;
        }
        double p = -1;
        int depth = -1;
        bool hasChild = false;
        var queue = new Queue<(double Probability, int Index)>();
        var map = new Dictionary<int, HashSet<int>>();
        foreach (var edge in edges) {
            int a = edge[0], b = edge[1];
            if (!map.TryGetValue(a, out var ha)) {
                ha = new HashSet<int>();
                map[a] = ha;
            }
            if (!map.TryGetValue(b, out var hb)) {
                hb = new HashSet<int>();
                map[b] = hb; 
            }
            ha.Add(b);
            hb.Add(a);
        }
        queue.Enqueue((Probability: 1.0, Index: 1));
        foreach (int next in map[1]) {
            map[next].Remove(1);
        }
        while (queue.Count > 0 && p < 0) {
            ++depth;
            for (int i = queue.Count; i > 0; --i) {
                var curr = queue.Dequeue();
                double np = map[curr.Index].Count > 0 ? 1.0 / (double)map[curr.Index].Count * curr.Probability : -1;
                if (curr.Index == target) {
                    p = curr.Probability;
                    hasChild = np >= 0;
                    break;
                }
                foreach (int next in map[curr.Index]) {
                    queue.Enqueue((Probability: np, Index: next));
                    map[next].Remove(curr.Index);
                }
            }
        }
        if (t < depth) {
            return 0;
        }
        if (t > depth) {
            return hasChild ? 0 : p;
        }
        return p;
    }
}
// @lc code=end

