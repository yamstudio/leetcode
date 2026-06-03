/*
 * @lc app=leetcode id=1761 lang=java
 *
 * [1761] Minimum Degree of a Connected Trio in a Graph
 */

import java.util.Map;
import java.util.HashMap;
import java.util.Set;
import java.util.HashSet;

// @lc code=start
class Solution {
    public int minTrioDegree(int n, int[][] edges) {
        Map<Integer, Set<Integer>> neighbors = new HashMap<>(n);
        for (int[] edge : edges) {
            int a = edge[0], b = edge[1];
            neighbors.computeIfAbsent(a, ignored -> new HashSet<>()).add(b);
            neighbors.computeIfAbsent(b, ignored -> new HashSet<>()).add(a);
        }
        int ret = Integer.MAX_VALUE;
        for (var entry : neighbors.entrySet()) {
            int a = entry.getKey();
            Set<Integer> nbs = entry.getValue();
            for (int b : nbs) {
                if (b < a) {
                    continue;
                }
                for (int c : nbs) {
                    if (c <= b || !neighbors.get(b).contains(c)) {
                        continue;
                    }
                    ret = Math.min(
                        ret,
                        nbs.size() + neighbors.get(b).size() + neighbors.get(c).size() - 6
                    );
                }
            }
        }
        return ret == Integer.MAX_VALUE ? -1 : ret;
    }
}
// @lc code=end

