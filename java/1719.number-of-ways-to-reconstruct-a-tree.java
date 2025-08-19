/*
 * @lc app=leetcode id=1719 lang=java
 *
 * [1719] Number Of Ways To Reconstruct A Tree
 */

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.PriorityQueue;
import java.util.Queue;
import java.util.Set;

// @lc code=start

class Solution {
    public int checkWays(int[][] pairs) {
        Map<Integer, Set<Integer>> group = new HashMap<>();
        for (int[] p : pairs) {
            int a = p[0], b = p[1];
            group.computeIfAbsent(a, ignored -> new HashSet<>()).add(b);
            group.computeIfAbsent(b, ignored -> new HashSet<>()).add(a);
        }
        int n = group.size();
        Set<Integer> visited = new HashSet<>(n);
        Queue<Integer> queue = new PriorityQueue<>(n, java.util.Comparator.comparing(i -> -group.get(i).size()));
        for (int x : group.keySet()) {
            queue.offer(x);
        }
        boolean mult = false;
        while (!queue.isEmpty()) {
            int x = queue.poll();
            visited.add(x);
            var g = group.get(x);
            if (queue.size() == n - 1) {
                if (g.size() != n - 1) {
                    return 0;
                }
                continue;
            }
            int minSize = n, p = -1;
            for (int y : g) {
                int size = group.get(y).size();
                if (size < minSize && visited.contains(y)) {
                    p = y;
                    minSize = size;
                }
            }
            for (int y : g) {
                if (y == p) {
                    continue;
                }
                if (!group.get(y).contains(p)) {
                    return 0;
                }
            }
            if (minSize == g.size()) {
                mult = true;
            }
        }
        return mult ? 2 : 1;
    }
}
// @lc code=end

