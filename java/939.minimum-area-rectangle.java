/*
 * @lc app=leetcode id=939 lang=java
 *
 * [939] Minimum Area Rectangle
 */

import java.util.Set;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;

// @lc code=start
class Solution {
    public int minAreaRect(int[][] points) {
        Map<Integer, Set<Integer>> xToY = new HashMap<>();
        for (var p : points) {
            xToY.computeIfAbsent(p[0], x -> new HashSet<>()).add(p[1]);
        }
        int ret = Integer.MAX_VALUE;
        for (int i = 0; i < points.length; ++i) {
            var p1 = points[i];
            var s1 = xToY.get(p1[0]);
            for (int j = i + 1; j < points.length; ++j) {
                var p2 = points[j];
                if (p1[0] == p2[0] || p1[1] == p2[1]) {
                    continue;
                }
                var s2 = xToY.get(p2[0]);
                if (s1.contains(p2[1]) && s2.contains(p1[1])) {
                    ret = Math.min(ret, Math.abs(p1[0] - p2[0]) * Math.abs(p1[1] - p2[1]));
                }
            }
        }
        return ret == Integer.MAX_VALUE ? 0 : ret;
    }
}
// @lc code=end

