/*
 * @lc app=leetcode id=1034 lang=java
 *
 * [1034] Coloring A Border
 */

import java.util.ArrayDeque;
import java.util.HashSet;
import java.util.Queue;
import java.util.Set;


// @lc code=start

class Solution {
    private static final Pair[] DIRS = new Pair[] {
        new Pair(-1, 0),
        new Pair(1, 0),
        new Pair(0, 1),
        new Pair(0, -1)
    };

    public int[][] colorBorder(int[][] grid, int row, int col, int color) {
        int original = grid[row][col];
        if (color == original) {
            return grid;
        }
        int m = grid.length, n = grid[0].length;
        int[][] ret = new int[m][n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                ret[i][j] = grid[i][j];
            }
        }
        Queue<Pair> queue = new ArrayDeque<>();
        Set<Pair> visited = new HashSet<>();
        queue.offer(new Pair(row, col));
        while (!queue.isEmpty()) {
            Pair curr = queue.poll();
            if (!visited.add(curr)) {
                continue;
            }
            int same = 0;
            for (Pair dir : DIRS) {
                int r = curr.r + dir.r, c = curr.c + dir.c;
                if (r < 0 || r >= m || c < 0 || c >= n) {
                    continue;
                }
                if (original == grid[r][c]) {
                    ++same;
                    queue.offer(new Pair(r, c));
                }
            }
            if (same < 4) {
                ret[curr.r][curr.c] = color;
            }
        }
        return ret;
    }

    private record Pair(int r, int c) {}
}
// @lc code=end

