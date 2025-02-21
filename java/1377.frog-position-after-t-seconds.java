/*
 * @lc app=leetcode id=1377 lang=java
 *
 * [1377] Frog Position After T Seconds
 */

import java.util.ArrayDeque;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Queue;
import java.util.Set;

// @lc code=start
class Solution {
    public double frogPosition(int n, int[][] edges, int t, int target) {
        if (n == 1) {
            return 1.0;
        }
        Map<Integer, Set<Integer>> neighbors = new HashMap<>(n);
        Queue<Pair> queue = new ArrayDeque<>();
        --target;
        for (int[] edge: edges) {
            int l = edge[0] - 1, r = edge[1] - 1;
            neighbors.computeIfAbsent(l, ignored -> new HashSet<>()).add(r);
            neighbors.computeIfAbsent(r, ignored -> new HashSet<>()).add(l);
        }
        for (int nb : neighbors.get(0)) {
            neighbors.get(nb).remove(0);
        }
        queue.offer(new Pair(1.0, 0));
        int depth = 0;
        double p = -1;
        while (!queue.isEmpty() && p < 0) {
            for (int k = queue.size(); k > 0; --k) {
                Pair curr = queue.poll();
                if (curr.i() == target) {
                    if (t < depth || (t > depth && !neighbors.get(target).isEmpty())) {
                        return 0;
                    }
                    return curr.p();
                }
                var nbs = neighbors.get(curr.i());
                if (nbs.isEmpty()) {
                    continue;
                }
                double np = 1.0 / (double)nbs.size() * curr.p();
                for (int nb : nbs) {
                    queue.offer(new Pair(np, nb));
                    var nbnbs = neighbors.get(nb);
                    nbnbs.remove(curr.i());
                }
            }
            ++depth;
        }
        throw new IllegalStateException();
    }

    private record Pair(double p, int i) {}
}
// @lc code=end

