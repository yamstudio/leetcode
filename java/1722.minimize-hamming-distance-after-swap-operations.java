/*
 * @lc app=leetcode id=1722 lang=java
 *
 * [1722] Minimize Hamming Distance After Swap Operations
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int minimumHammingDistance(int[] source, int[] target, int[][] allowedSwaps) {
        int n = source.length;
        int[] parents = new int[n];
        for (int i = 1; i < n; ++i) {
            parents[i] = i;
        }
        for (int[] swap : allowedSwaps) {
            int ap = find(parents, swap[0]), bp = find(parents, swap[1]);
            parents[ap] = bp;
        }
        Map<Integer, Map<Integer, Integer>> counts = new HashMap<>();
        for (int i = 0; i < n; ++i) {
            int x = source[i], y = target[i];
            Map<Integer, Integer> count = counts.computeIfAbsent(find(parents, i), ignored -> new HashMap<>());
            count.put(x, count.getOrDefault(x, 0) - 1);
            count.put(y, count.getOrDefault(y, 0) + 1);
        }
        int ret = 0;
        for (var count : counts.values()) {
            for (int v : count.values()) {
                ret += Math.abs(v);
            }
        }
        return ret / 2;
    }

    private static int find(int[] parents, int x) {
        int p = parents[x];
        if (p == x) {
            return p;
        }
        p = find(parents, p);
        parents[x] = p;
        return p;
    }
}
// @lc code=end

