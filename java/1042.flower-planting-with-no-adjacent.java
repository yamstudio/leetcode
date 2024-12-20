/*
 * @lc app=leetcode id=1042 lang=java
 *
 * [1042] Flower Planting With No Adjacent
 */

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

// @lc code=start

import static java.util.stream.Collectors.toUnmodifiableSet;

class Solution {
    public int[] gardenNoAdj(int n, int[][] paths) {
        Map<Integer, Set<Integer>> map =  new HashMap<>();
        for (int[] path : paths) {
            int x = path[0] - 1, y = path[1] - 1;
            map.computeIfAbsent(x, ignored -> new HashSet<>()).add(y);
            map.computeIfAbsent(y, ignored -> new HashSet<>()).add(x);
        }
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            Set<Integer> neighbors = map.get(i);
            if (neighbors == null) {
                ret[i] = 1;
                continue;
            }
            Set<Integer> used = neighbors.stream().map(j -> ret[j]).collect(toUnmodifiableSet());
            for (int c = 1; c <= 4; ++c) {
                if (!used.contains(c)) {
                    ret[i] = c;
                    break;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

