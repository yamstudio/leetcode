/*
 * @lc app=leetcode id=963 lang=java
 *
 * [963] Minimum Area Rectangle II
 */

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

// @lc code=start
class Solution {
    public double minAreaFreeRect(int[][] points) {
        var diagonalToPairs = new HashMap<Diagonal, List<Pair>>();
        int n = points.length;
        double ret = Double.MAX_VALUE;
        for (int i = 0; i < n; ++i) {
            int[] p1 = points[i];
            for (int j = i + 1; j < n; ++j) {
                int[] p2 = points[j];
                diagonalToPairs.computeIfAbsent(Diagonal.fromPoints(p1, p2), ignored -> new ArrayList<>())
                    .add(new Pair(i, j));
            }
        }
        for (var pairs : diagonalToPairs.values()) {
            int m = pairs.size();
            for (int i = 0; i < m; ++i) {
                var pair1 = pairs.get(i);
                for (int j = i + 1; j < m; ++j) {
                    var pair2 = pairs.get(j);
                    ret = Math.min(
                        ret,
                        dist(points[pair1.i], points[pair2.i]) * dist(points[pair1.i], points[pair2.j])
                    );
                }
            }
        }
        return ret == Double.MAX_VALUE ? 0 : ret;
    }

    private static double dist(int[] p1, int[] p2) {
        return Math.sqrt(Math.pow(p1[0] - p2[0], 2) + Math.pow(p1[1] - p2[1], 2));
    }

    private record Diagonal(double midX, double midY, double length) {
        private static Diagonal fromPoints(int[] p1, int[] p2) {
            double midX = (p1[0] + p2[0]) / 2.0;
            double midY = (p1[1] + p2[1]) / 2.0;
            double length = dist(p1, p2);
            return new Diagonal(midX, midY, length);
        }
    }
    private record Pair(int i, int j) {}
}
// @lc code=end

