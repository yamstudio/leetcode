/*
 * @lc app=leetcode id=1129 lang=java
 *
 * [1129] Shortest Path with Alternating Colors
 */

import java.util.ArrayDeque;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Queue;
import java.util.Set;

// @lc code=start

class Solution {
    public int[] shortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges) {
        Map<Integer, List<List<Integer>>> edges = new HashMap<>();
        for (int[] edge: redEdges) {
            edges.computeIfAbsent(edge[0], ignored -> List.of(new ArrayList<>(), new ArrayList<>())).get(0).add(edge[1]);
        }
        for (int[] edge: blueEdges) {
            edges.computeIfAbsent(edge[0], ignored -> List.of(new ArrayList<>(), new ArrayList<>())).get(1).add(edge[1]);
        }
        Set<String> visited = new HashSet<>();
        Queue<Pair> queue = new ArrayDeque<>();
        queue.offer(new Pair(0, 0, 0));
        queue.offer(new Pair(0, 0, 1));
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            ret[i] = Integer.MAX_VALUE;
        }
        while (!queue.isEmpty()) {
            Pair curr = queue.poll();
            if (!visited.add("%d,%d".formatted(curr.index(), curr.edge()))) {
                continue;
            }
            ret[curr.index()] = Math.min(curr.length(), ret[curr.index()]);
            var neighbors = edges.get(curr.index());
            if (neighbors == null) {
                continue;
            }
            for (int next : neighbors.get(1 - curr.edge())) {
                queue.offer(new Pair(next, curr.length() + 1, 1 - curr.edge()));
            }
        }
        for (int i = 0; i < n; ++i) {
            if (ret[i] == Integer.MAX_VALUE) {
                ret[i] = -1;
            }
        }
        return ret;
    }

    private record Pair(int index, int length, int edge) {}
}
// @lc code=end

