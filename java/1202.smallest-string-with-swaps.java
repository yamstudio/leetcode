/*
 * @lc app=leetcode id=1202 lang=java
 *
 * [1202] Smallest String With Swaps
 */

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

// @lc code=start
class Solution {
    public String smallestStringWithSwaps(String s, List<List<Integer>> pairs) {
        int n = s.length();
        int[] parent = new int[n];
        for (int i = 1; i < n; ++i) {
            parent[i] = i;
        }
        for (var pair : pairs) {
            int a = pair.get(0), b = pair.get(1);
            parent[findRoot(parent, a)] = findRoot(parent, b);
        }
        Map<Integer, List<Character>> rootToChars = new HashMap<>();
        for (int i = 0; i < n; ++i) {
            rootToChars.computeIfAbsent(findRoot(parent, i), ignored -> new ArrayList<>()).add(s.charAt(i));
        }
        Map<Integer, Integer> rootToIndex = new HashMap<>();
        for (var rootChars : rootToChars.entrySet()) {
            Collections.sort(rootChars.getValue());
            rootToIndex.put(rootChars.getKey(), 0);
        }
        StringBuilder sb = new StringBuilder(n);
        for (int i = 0; i < n; ++i) {
            int r = findRoot(parent, i);
            int ni = rootToIndex.get(r);
            sb.append(rootToChars.get(r).get(ni));
            rootToIndex.put(r, ni + 1);
        }
        return sb.toString();
    }

    private static int findRoot(int[] parent, int c) {
        if (parent[c] == c) {
            return c;
        }
        int p = findRoot(parent, parent[c]);
        parent[c] = p;
        return p;
    }
}
// @lc code=end

