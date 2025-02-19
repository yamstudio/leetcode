/*
 * @lc app=leetcode id=1368 lang=java
 *
 * [1368] Minimum Cost to Make at Least One Valid Path in a Grid
 */

import java.util.ArrayDeque;
import java.util.Queue;

// @lc code=start
class Solution {

    private static final Pair[] DIRS = new Pair[] {
        new Pair(0, 1),
        new Pair(0, -1),
        new Pair(1, 0),
        new Pair(-1, 0),
    };

    public int minCost(int[][] grid) {
        int m = grid.length, n = grid[0].length, cost = 1;
        int[][] costs = new int[m][n];
        Queue<Pair> queue = new ArrayDeque<>();
        add(grid, 0, 0, 1, costs, queue);
        while (costs[m - 1][n - 1] == 0) {
            ++cost;
            for (int i = queue.size(); i > 0; --i) {
                Pair curr = queue.poll();
                for (Pair dir : DIRS) {
                    add(grid, curr.r() + dir.r(), curr.c() + dir.c(), cost, costs, queue);
                }
            }
        }
        return costs[m - 1][n - 1] - 1;
    }

    private static void add(int[][] grid, int r, int c, int cost, int[][] costs, Queue<Pair> queue) {
        int m = grid.length, n = grid[0].length;
        while (r >= 0 && r < m && c >= 0 && c < n && costs[r][c] == 0) {
            costs[r][c] = cost;
            queue.offer(new Pair(r, c));
            Pair dir = DIRS[grid[r][c] - 1];
            r = dir.r() + r;
            c = dir.c() + c;
        }
    }

    private record Pair(int r, int c) {}
}
// @lc code=end

