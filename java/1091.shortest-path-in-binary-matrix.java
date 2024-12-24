/*
 * @lc app=leetcode id=1091 lang=java
 *
 * [1091] Shortest Path in Binary Matrix
 */

import java.util.ArrayDeque;
import java.util.Queue;

// @lc code=start
class Solution {
    public int shortestPathBinaryMatrix(int[][] grid) {
        int n = grid.length;
        if (grid[0][0] != 0 || grid[n - 1][n - 1] != 0) {
            return -1;
        }
        boolean[][] visited = new boolean[n][n];
        Queue<Pair> queue = new ArrayDeque<>();
        queue.offer(new Pair(0, 0, 1));
        while (!queue.isEmpty()) {
            Pair curr = queue.poll();
            if (visited[curr.r()][curr.c()]) {
                continue;
            }
            if (curr.r() == n - 1 && curr.c() == n - 1) {
                return curr.steps();
            }
            visited[curr.r()][curr.c()] = true;
            for (int dr = -1; dr <= 1; ++dr) {
                for (int dc = -1; dc <= 1; ++dc) {
                    int nr = dr + curr.r(), nc = dc + curr.c();
                    if (nr < 0 || nr >= n || nc < 0 || nc >= n || grid[nr][nc] != 0 || visited[nr][nc]) {
                        continue;
                    }
                    queue.offer(new Pair(nr, nc, curr.steps() + 1));
                }
            }
        }
        return -1;
    }

    private record Pair(int r, int c, int steps) {}
}
// @lc code=end

