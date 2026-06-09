/*
 * @lc app=leetcode id=1766 lang=java
 *
 * [1766] Tree of Coprimes
 */

import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

// @lc code=start

class Solution {
    public int[] getCoprimes(int[] nums, int[][] edges) {
        int n = nums.length;
        Map<Integer, Set<Integer>> neighbors = new HashMap<>(n);
        for (int[] edge : edges) {
            int a = edge[0], b = edge[1];
            neighbors.computeIfAbsent(a, ignored -> new HashSet<>()).add(b);
            neighbors.computeIfAbsent(b, ignored -> new HashSet<>()).add(a);
        }
        int[] ret = new int[n];
        getCoprimes(nums, 0, 0, neighbors, new Pair[51], new HashSet<>(n), ret);
        return ret;
    }

    private static void getCoprimes(int[] nums, int i, int d, Map<Integer, Set<Integer>> neighbors, Pair[] closest, Set<Integer> visited, int[] ret) {
        if (!visited.add(i)) {
            return;
        }
        int v = nums[i], md = -1;
        ret[i] = -1;
        for (int pv = 1; pv <= 50; ++pv) {
            Pair p = closest[pv];
            if (p == null || p.depth() < md || gcd(pv, v) != 1) {
                continue;
            }
            ret[i] = p.index();
            md = p.depth();
        }
        Pair prev = closest[v];
        closest[v] = new Pair(i, d);
        for (int nb : neighbors.getOrDefault(i, Collections.emptySet())) {
            getCoprimes(nums, nb, d + 1, neighbors, closest, visited, ret);
        }
        closest[v] = prev;
    }

    private static int gcd(int a, int b) {
        if (b == 0) {
            return a;
        }
        return gcd(b, a % b);
    }

    private static record Pair(int index, int depth) {}
}
// @lc code=end

