/*
 * @lc app=leetcode id=1579 lang=java
 *
 * [1579] Remove Max Number of Edges to Keep Graph Fully Traversable
 */

import java.util.Arrays;

// @lc code=start

class Solution {
    public int maxNumEdgesToRemove(int n, int[][] edges) {
        int[] roots = new int[n + 1];
        int aCount = 0, bCount = 0, ret = 0;
        for (int i = 1; i <= n; ++i) {
            roots[i] = i;
        }
        for (int[] edge : edges) {
            if (edge[0] != 3) {
                continue;
            }
            if (union(roots, edge[1], edge[2])) {
                ++aCount;
                ++bCount;
            } else {
                ++ret;
            }
        }
        int[] aRoots = Arrays.copyOf(roots, n + 1);
        for (int[] edge : edges) {
            if (edge[0] != 1) {
                continue;
            }
            if (union(aRoots, edge[1], edge[2])) {
                ++aCount;
            } else {
                ++ret;
            }
        }
        if (aCount != n - 1) {
            return -1;
        }
        int[] bRoots = Arrays.copyOf(roots, n + 1);
        for (int[] edge : edges) {
            if (edge[0] != 2) {
                continue;
            }
            if (union(bRoots, edge[1], edge[2])) {
                ++bCount;
            } else {
                ++ret;
            }
        }
        if (bCount != n - 1) {
            return -1;
        }
        return ret;
    }

    private static boolean union(int[] roots, int a, int b) {
        int ra = find(roots, a), rb = find(roots, b);
        if (ra == rb) {
            return false;
        }
        roots[ra] = rb;
        return true;
    }

    private static int find(int[] roots, int x) {
        int r = roots[x];
        if (r == x) {
            return r;
        }
        int rr = find(roots, r);
        roots[x] = rr;
        return rr;
    }
}
// @lc code=end

