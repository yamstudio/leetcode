/*
 * @lc app=leetcode id=994 lang=java
 *
 * [994] Rotting Oranges
 */

import java.util.ArrayDeque;
import java.util.Queue;

// @lc code=start

class Solution {

    private static final Pair[] DIRS = new Pair[] {
        new Pair(-1, 0),
        new Pair(1, 0),
        new Pair(0, -1),
        new Pair(0, 1)
    };

    public int orangesRotting(int[][] grid) {
        int m = grid.length, n = grid[0].length, ret = 0;
        int[][] min = new int[m][n];
        Queue<Pair> queue = new ArrayDeque<>();
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 2) {
                    queue.offer(new Pair(i, j));
                }
            }
        }
        while (!queue.isEmpty()) {
            Pair p = queue.poll();
            for (Pair d : DIRS) {
                int x = p.x + d.x, y = p.y + d.y;
                if (x < 0 || x >= m || y < 0 || y >= n || grid[x][y] != 1 || min[x][y] > 0) {
                    continue;
                }
                min[x][y] = 1 + min[p.x][p.y];
                ret = Math.max(ret, min[x][y]);
                queue.offer(new Pair(x, y));
            }
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1 && min[i][j] == 0) {
                    return -1;
                }
            }
        }
        return ret;
    }

    private record Pair(int x, int y) {}
}
// @lc code=end

