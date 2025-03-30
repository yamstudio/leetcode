/*
 * @lc app=leetcode id=1514 lang=java
 *
 * [1514] Path with Maximum Probability
 */

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Queue;

// @lc code=start
class Solution {
    public double maxProbability(int n, int[][] edges, double[] succProb, int startNode, int endNode) {
        double[] probs = new double[n];
        Queue<Pair> queue = new ArrayDeque<>();
        Map<Integer, List<Pair>> neighbors = new HashMap<>();
        for (int i = edges.length - 1; i >= 0; --i) {
            double prob = succProb[i];
            int a = edges[i][0], b = edges[i][1];
            neighbors.computeIfAbsent(a, ignored -> new ArrayList<>()).add(new Pair(b, prob));
            neighbors.computeIfAbsent(b, ignored -> new ArrayList<>()).add(new Pair(a, prob));
        }
        queue.offer(new Pair(startNode, 1.0));
        while (!queue.isEmpty()) {
            Pair curr = queue.poll();
            List<Pair> nbs = neighbors.get(curr.index());
            if (nbs == null) {
                continue;
            }
            for (Pair nb : nbs) {
                double prob = nb.prob();
                int i = nb.index();
                if (probs[i] < prob * curr.prob()) {
                    probs[i] = prob * curr.prob();
                    queue.offer(new Pair(i, probs[i]));
                }
            }
        }
        return probs[endNode];
    }

    private record Pair(int index, double prob) {}
}
// @lc code=end

