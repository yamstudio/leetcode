/*
 * @lc app=leetcode id=1162 lang=java
 *
 * [1162] As Far from Land as Possible
 */

import java.util.ArrayDeque;
import java.util.Queue;

// @lc code=start
class Solution {
    public int maxDistance(int[][] grid) {
        int ret = -1, n = grid.length;
        boolean[][] visited = new boolean[n][n];
        Queue<Pair> queue = new ArrayDeque<>();
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1) {
                    queue.offer(new Pair(i, j, 0));
                }
            }
        }
        while (!queue.isEmpty()) {
            Pair curr = queue.poll();
            int r = curr.r(), c = curr.c();
            if (r < 0 || r >= n || c < 0 || c >= n || visited[r][c]) {
                continue;
            }
            int dist = curr.dist();
            visited[r][c] = true;
            if (grid[r][c] == 0) {
                ret = Math.max(ret, dist);
            }
            queue.offer(new Pair(r - 1, c, dist + 1));
            queue.offer(new Pair(r + 1, c, dist + 1));
            queue.offer(new Pair(r, c - 1, dist + 1));
            queue.offer(new Pair(r, c + 1, dist + 1));
        }
        return ret;
    }

    private record Pair(int r, int c, int dist) {}
}
// @lc code=end

