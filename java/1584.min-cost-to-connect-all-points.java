/*
 * @lc app=leetcode id=1584 lang=java
 *
 * [1584] Min Cost to Connect All Points
 */

import java.util.HashSet;
import java.util.Set;

// @lc code=start

class Solution {
    public int minCostConnectPoints(int[][] points) {
        int curr = 0, n = points.length, ret = 0;
        Set<Integer> unused = new HashSet<>(n);
        int[] dists = new int[n];
        for (int i = 0; i < n; ++i) {
            unused.add(i);
            dists[i] = Integer.MAX_VALUE;
        }
        while (--n > 0) {
            unused.remove(curr);
            int[] p = points[curr];
            int minDist = Integer.MAX_VALUE, next = -1;
            for (int x : unused) {
                int d = Math.abs(p[0] - points[x][0]) + Math.abs(p[1] - points[x][1]);
                dists[x] = Math.min(dists[x], d);
                if (dists[x] < minDist) {
                    minDist = dists[x];
                    next = x;
                }
            }
            ret += minDist;
            curr = next;
        }
        return ret;
    }
}
// @lc code=end

