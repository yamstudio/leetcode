/*
 * @lc app=leetcode id=1514 lang=csharp
 *
 * [1514] Path with Maximum Probability
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public double MaxProbability(int n, int[][] edges, double[] succProb, int start, int end) {
        var queue = new Queue<int>();
        var probs = new double[n];
        var neighbors = new IList<(int Index, double Probability)>[n];
        int k = edges.Length;
        for (int i = 0; i < k; ++i) {
            int a = edges[i][0], b = edges[i][1];
            double p = succProb[i];
            if (neighbors[a] == null) {
                neighbors[a] = new List<(int Index, double Probability)>();
            }
            if (neighbors[b] == null) {
                neighbors[b] = new List<(int Index, double Probability)>();
            }
            neighbors[a].Add((Index: b, Probability: p));
            neighbors[b].Add((Index: a, Probability: p));
        }
        probs[start] = 1.0;
        queue.Enqueue(start);
        while (queue.Count > 0) {
            var curr = queue.Dequeue();
            if (neighbors[curr] == null) {
                continue;
            }
            foreach (var next in neighbors[curr]) {
                if (next.Probability * probs[curr] > probs[next.Index]) {
                    probs[next.Index] = next.Probability * probs[curr];
                    queue.Enqueue(next.Index);
                }
            }
        }
        return probs[end];
    }
}
// @lc code=end

