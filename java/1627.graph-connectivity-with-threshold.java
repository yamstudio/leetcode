/*
 * @lc app=leetcode id=1627 lang=java
 *
 * [1627] Graph Connectivity With Threshold
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<Boolean> areConnected(int n, int threshold, int[][] queries) {
        int[] roots = new int[n + 1];
        for (int i = 1; i <= n; ++i) {
            roots[i] = i;
        }
        for (int fac = threshold + 1; fac < n; ++fac) {
            for (int j = 2; j * fac <= n; ++j) {
                int ra = find(roots, fac), rb = find(roots, j * fac);
                roots[rb] = ra;
            }
        }
        List<Boolean> ret = new ArrayList<>(queries.length);
        for (int[] q : queries) {
            ret.add(find(roots, q[0]) == find(roots, q[1]));
        }
        return ret;
    }

    private static int find(int[] roots, int x) {
        int r = roots[x];
        if (r != x) {
            r = find(roots, r);
            roots[x] = r;
        }
        return r;
    }
}
// @lc code=end

