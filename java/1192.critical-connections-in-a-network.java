/*
 * @lc app=leetcode id=1192 lang=java
 *
 * [1192] Critical Connections in a Network
 */

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

// @lc code=start
class Solution {
    public List<List<Integer>> criticalConnections(int n, List<List<Integer>> connections) {
        Set<Connection> ret = new HashSet<>(connections.size());
        Map<Integer, Set<Integer>> edges = new HashMap<>();
        for (var c : connections) {
            int l = c.get(0), r = c.get(1);
            edges.computeIfAbsent(l, ignored -> new HashSet<>()).add(r);
            edges.computeIfAbsent(r, ignored -> new HashSet<>()).add(l);
            ret.add(Connection.fromList(l, r));
        }
        dfs(edges, ret, 0, new int[n], 10);
        return ret.stream().map(Connection::toList).toList();
    }

    private static int dfs(Map<Integer, Set<Integer>> edges, Set<Connection> ret, int curr, int[] depths, int newDepth) {
        if (depths[curr] != 0) {
            return depths[curr];
        }
        int minNeighborDepth = Integer.MAX_VALUE;
        depths[curr] = newDepth;
        for (var next : edges.get(curr)) {
            if (depths[next] == newDepth - 1) {
                continue;
            }
            int neighborDepth = dfs(edges, ret, next, depths, newDepth + 1);
            if (neighborDepth <= newDepth) {
                ret.remove(Connection.fromList(curr, next));
            }
            minNeighborDepth = Integer.min(minNeighborDepth, neighborDepth);
        }
        return minNeighborDepth;
    }

    private record Connection(int l, int r) {
        private List<Integer> toList() {
            return List.of(l, r);
        }

        private static Connection fromList(int l, int r) {
            return new Connection(Math.min(l, r), Math.max(l, r));
        }
    }
}
// @lc code=end

