/*
 * @lc app=leetcode id=1631 lang=java
 *
 * [1631] Path With Minimum Effort
 */

import java.util.SortedSet;
import java.util.TreeSet;

// @lc code=start

class Solution {

    private static final int[][] DIRS = new int[][] {
        new int[] { -1, 0 },
        new int[] { 1, 0 },
        new int[] { 0, -1 },
        new int[] { 0, 1 }
    };

    public int minimumEffortPath(int[][] heights) {
        int m = heights.length, n = heights[0].length;
        int[][] efforts = new int[m][n];
        SortedSet<Pair> sorted = new TreeSet<>(java.util.Comparator.comparingInt(Pair::effort).thenComparingInt(Pair::r).thenComparingInt(Pair::c));
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                efforts[i][j] = Integer.MAX_VALUE;
            }
        }
        sorted.add(new Pair(0, 0, 0));
        efforts[0][0] = 0;
        while (!sorted.isEmpty()) {
            Pair p = sorted.removeFirst();
            int r = p.r(), c = p.c(), effort = p.effort();
            if (efforts[r][c] < effort) {
                continue;
            }
            if (r == m - 1 && c == n - 1) {
                return effort;
            }
            for (int[] dir : DIRS) {
                int nr = r + dir[0], nc = c + dir[1];
                if (nr < 0 || nr >= m || nc < 0 || nc >= n) {
                    continue;
                }
                int newEffort = Math.max(effort, Math.abs(heights[r][c] - heights[nr][nc]));
                if (newEffort >= efforts[nr][nc]) {
                    continue;
                }
                efforts[nr][nc] = newEffort;
                sorted.add(new Pair(nr, nc, newEffort));
            }
        }
        return -1;
    }

    private record Pair(int r, int c, int effort) {}
}
// @lc code=end

