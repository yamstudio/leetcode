/*
 * @lc app=leetcode id=1210 lang=java
 *
 * [1210] Minimum Moves to Reach Target with Rotations
 */

import java.util.Queue;
import java.util.ArrayDeque;

// @lc code=start
class Solution {
    public int minimumMoves(int[][] grid) {
        int n = grid.length, ret = 0;
        Queue<Pos> queue = new ArrayDeque<>();
        boolean[][][] visited = new boolean[n][n][2];
        add(new Pos(0, 0, true), visited, queue);
        while (!queue.isEmpty()) {
            for (int i = queue.size(); i > 0; --i) {
                Pos curr = queue.poll();
                int r = curr.r(), c = curr.c();
                boolean h = curr.horizontal();
                if (r == n - 1 && c == n - 2 && h) {
                    return ret;
                }
                Pos right = new Pos(r, c + 1, h);
                if (isEmpty(right, grid)) {
                    add(right, visited, queue);
                }
                Pos down = new Pos(r + 1, c, h);
                if (isEmpty(down, grid)) {
                    add(down, visited, queue);
                }
                if (h) {
                    if (isEmpty(new Pos(r + 1, c, h), grid)) {
                        add(new Pos(r, c, !h), visited, queue);
                    }
                } else {
                    if (isEmpty(new Pos(r, c + 1, h), grid)) {
                        add(new Pos(r, c, !h), visited, queue);
                    }
                }
            }
            ++ret;
        }
        return -1;
    }

    private static boolean isEmpty(Pos pos, int[][] grid) {
        return isEmpty(pos.r(), pos.c(), grid) && (pos.horizontal() ? isEmpty(pos.r(), pos.c() + 1, grid) : isEmpty(pos.r() + 1, pos.c(), grid));
    }

    private static boolean isEmpty(int r, int c, int[][] grid) {
        int n = grid.length;
        return (r >= 0 && r < n && c >= 0 && c < n && grid[r][c] == 0);
    }

    private static void add(Pos pos, boolean[][][] visited, Queue<Pos> queue) {
        if (visited[pos.r()][pos.c()][pos.horizontal() ? 1 : 0]) {
            return;
        }
        visited[pos.r()][pos.c()][pos.horizontal() ? 1 : 0] = true;
        queue.offer(pos);
    }

    private record Pos(int r, int c, boolean horizontal) {}
}
// @lc code=end

