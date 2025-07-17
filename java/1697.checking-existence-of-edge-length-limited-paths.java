/*
 * @lc app=leetcode id=1697 lang=java
 *
 * [1697] Checking Existence of Edge Length Limited Paths
 */

// @lc code=start

import java.util.Arrays;

class Solution {
    public boolean[] distanceLimitedPathsExist(int n, int[][] edgeList, int[][] queries) {
        int k = queries.length;
        var indices = new Integer[k];
        var ret = new boolean[k];
        var roots = new int[n];
        for (int i = 1; i < n; ++i) {
            roots[i] = i;
        }
        for (int i = 0; i < k; ++i) {
            indices[i] = i;
        }
        Arrays.sort(indices, java.util.Comparator.comparing(i -> queries[i][2]));
        Arrays.sort(edgeList, java.util.Comparator.comparing(edge -> edge[2]));
        int j = 0;
        for (int i: indices) {
            var q = queries[i];
            int l = q[2];
            while (j < edgeList.length && edgeList[j][2] < l) {
                roots[find(roots, edgeList[j][0])] = find(roots, edgeList[j][1]); 
                ++j;
            }
            ret[i] = find(roots, q[0]) == find(roots, q[1]);
        }
        return ret;
    }

    private static int find(int[] roots, int i) {
        int r = roots[i];
        if (r == i) {
            return r;
        }
        r = find(roots, r);
        roots[i] = r;
        return r;
    }
}
// @lc code=end

