/*
 * @lc app=leetcode id=1591 lang=java
 *
 * [1591] Strange Printer II
 */

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

// @lc code=start

class Solution {
    public boolean isPrintable(int[][] targetGrid) {
        int m = targetGrid.length, n = targetGrid[0].length;
        Map<Integer, int[]> boundaries = new HashMap<>();
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                int[] boundary = boundaries.get(targetGrid[i][j]);
                if (boundary == null) {
                    boundary = new int[] { i, i, j, j };
                    boundaries.put(targetGrid[i][j], boundary);
                    continue;
                }
                boundary[1] = i;
                boundary[2] = Math.min(boundary[2], j);
                boundary[3] = Math.max(boundary[3], j);
            }
        }
        Map<Integer, Set<Integer>> deps = new HashMap<>(boundaries.size());
        for (var colorToBoundary : boundaries.entrySet()) {
            int c = colorToBoundary.getKey();
            int[] boundary = colorToBoundary.getValue();
            Set<Integer> dep = new HashSet<>();
            for (int i = boundary[0]; i <= boundary[1]; ++i) {
                for (int j = boundary[2]; j <= boundary[3]; ++j) {
                    if (targetGrid[i][j] == c) {
                        continue;
                    }
                    dep.add(targetGrid[i][j]);
                }
            }
            deps.put(c, dep);
        }
        Map<Integer, Boolean> visited = new HashMap<>(boundaries.size());
        for (var c : boundaries.keySet()) {
            if (hasCycle(c, deps, visited)) {
                return false;
            }
        }
        return true;
    }

    private static boolean hasCycle(int curr, Map<Integer, Set<Integer>> deps, Map<Integer, Boolean> visited) {
        visited.put(curr, false);
        for (int next : deps.get(curr)) {
            Boolean v = visited.get(next);
            if (v != null) {
                if (v) {
                    continue;
                }
                return true;
            }
            if (hasCycle(next, deps, visited)) {
                return true;
            }
        }
        visited.put(curr, true);
        return false;
    }
}
// @lc code=end

