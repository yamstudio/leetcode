/*
 * @lc app=leetcode id=1786 lang=java
 *
 * [1786] Number of Restricted Paths From First to Last Node
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.PriorityQueue;
import java.util.Queue;

// @lc code=start

import static java.util.Comparator.comparingLong;

class Solution {
    public int countRestrictedPaths(int n, int[][] edges) {
        List<List<NodeDist>> edgeList = new ArrayList<>(n);
        for (int i = 0; i < n; ++i) {
            edgeList.add(new ArrayList<>());
        }
        for (int[] edge : edges) {
            int a = edge[0] - 1, b = edge[1] - 1, dist = edge[2];
            edgeList.get(a).add(new NodeDist(b, dist));
            edgeList.get(b).add(new NodeDist(a, dist));
        }
        long[] dists = dijkstra(edgeList);
        List<Integer> indexes = new ArrayList<>(n);
        for (int i = 0; i < n; ++i) {
            indexes.add(i);
        }
        Collections.sort(indexes, comparingLong(i -> dists[i]));
        long[] dp = new long[n];
        dp[n - 1] = 1;
        for (int index : indexes) {
            long dist = dists[index];
            for (NodeDist neighborDist : edgeList.get(index)) {
                int nb = neighborDist.index();
                long d = dists[nb];
                if (dist > d) {
                    dp[index] = (dp[index] + dp[nb]) % 1000000007;
                }
            }
        }
        return (int)dp[0];
    }

    private static long[] dijkstra(List<List<NodeDist>> edges) {
        int n = edges.size();
        long[] ret = new long[n];
        for (int i = 0; i < n - 1; ++i) {
            ret[i] = Long.MAX_VALUE;
        }
        boolean[] seen = new boolean[n];
        Queue<NodeDist> queue = new PriorityQueue<>(comparingLong(NodeDist::dist));
        queue.add(new NodeDist(n - 1, 0L));
        while (!queue.isEmpty()) {
            NodeDist curr = queue.poll();
            int index = curr.index();
            long dist = curr.dist();
            if (seen[index]) {
                continue;
            }
            seen[index] = true;
            for (NodeDist neighborDist : edges.get(index)) {
                int nb = neighborDist.index();
                long d = neighborDist.dist();
                if (seen[nb]) {
                    continue;
                }
                if (ret[nb] <= d + dist) {
                    continue;
                }
                ret[nb] = d + dist;
                queue.add(new NodeDist(nb, dist + d));
            }
        }
        return ret;
    }

    private record NodeDist(int index, long dist) {}
}
// @lc code=end

