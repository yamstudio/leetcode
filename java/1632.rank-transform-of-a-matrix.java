/*
 * @lc app=leetcode id=1632 lang=java
 *
 * [1632] Rank Transform of a Matrix
 */

import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.TreeMap;

// @lc code=start
import java.util.SortedMap;

class Solution {
    public int[][] matrixRankTransform(int[][] matrix) {
        Map<Integer, List<Pair>> map = new HashMap<>();
        int m = matrix.length, n = matrix[0].length;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                map.computeIfAbsent(matrix[i][j], ignored -> new ArrayList<>()).add(new Pair(i, j));
            }
        }
        SortedMap<Integer, List<Pair>> sorted = new TreeMap<>(map);
        int[][] ret = new int[m][n];
        int[] ranks = new int[m + n];
        for (List<Pair> pairs : sorted.values()) {
            int[] roots = new int[m + n], maxRanks = Arrays.copyOf(ranks, ranks.length);
            for (int i = 1; i < m + n; ++i) {
                roots[i] = i;
            }
            for (Pair p : pairs) {
                int rr = findRoot(roots, p.r()), rc = findRoot(roots, p.c() + m);
                maxRanks[rc] = Math.max(maxRanks[rr], maxRanks[rc]);
                roots[rr] = rc;
            }
            for (Pair p : pairs) {
                int rank = 1 + maxRanks[findRoot(roots, p.r())];
                ret[p.r()][p.c()] = rank;
                ranks[p.r()] = rank;
                ranks[p.c() + m] = rank;
            }
        }
        return ret;
    }

    private static int findRoot(int[] roots, int x) {
        int r = roots[x];
        if (r != x) {
            r = findRoot(roots, r);
            roots[x] = r;
        }
        return r;
    }

    private record Pair(int r, int c) {}
}
// @lc code=end

