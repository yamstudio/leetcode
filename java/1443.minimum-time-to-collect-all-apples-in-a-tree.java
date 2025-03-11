/*
 * @lc app=leetcode id=1443 lang=java
 *
 * [1443] Minimum Time to Collect All Apples in a Tree
 */

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;

// @lc code=start
class Solution {
    public int minTime(int n, int[][] edges, List<Boolean> hasApple) {
        Map<Integer, Set<Integer>> edgesMap = new HashMap<>();
        for (int[] edge : edges) {
            int a = edge[0], b = edge[1];
            if (b != 0) {
                edgesMap.computeIfAbsent(a, ignored -> new HashSet<>()).add(b);
            }
            if (a != 0) {
                edgesMap.computeIfAbsent(b, ignored -> new HashSet<>()).add(a);
            }
        }
        return Math.max(0, minTime(0, edgesMap, hasApple));
    }

    private static int minTime(int curr, Map<Integer, Set<Integer>> edgesMap, List<Boolean> hasApple) {
        Set<Integer> nbs = edgesMap.get(curr);
        boolean has = hasApple.get(curr);
        if (nbs == null) {
            return has ? 0 : -2;
        }
        int ret = 0;
        for (int nb : nbs) {
            var nbm = edgesMap.get(nb);
            if (nbm != null) {
                nbm.remove(curr);
            }
            ret += 2 + minTime(nb, edgesMap, hasApple);
        }
        return (ret == 0 && !has) ? -2 : ret;
    }
}
// @lc code=end

