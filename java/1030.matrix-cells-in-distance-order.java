/*
 * @lc app=leetcode id=1030 lang=java
 *
 * [1030] Matrix Cells in Distance Order
 */

import java.util.ArrayDeque;
import java.util.Queue;

// @lc code=start
class Solution {
    public int[][] allCellsDistOrder(int rows, int cols, int rCenter, int cCenter) {
        Queue<Pair> queue = new ArrayDeque<>();
        boolean[][] visited = new boolean[rows][cols];
        int[][] ret = new int[rows * cols][2];
        int i = 0;
        queue.offer(new Pair(rCenter, cCenter));
        while (!queue.isEmpty()) {
            Pair curr = queue.poll();
            if (curr.r < 0 || curr.r >= rows || curr.c < 0 || curr.c >= cols) {
                continue;
            }
            if (visited[curr.r][curr.c]) {
                continue;
            }
            visited[curr.r][curr.c] = true;
            ret[i][0] = curr.r;
            ret[i][1] = curr.c;
            ++i;
            queue.offer(new Pair(curr.r, curr.c - 1));
            queue.offer(new Pair(curr.r, curr.c + 1));
            queue.offer(new Pair(curr.r - 1, curr.c));
            queue.offer(new Pair(curr.r + 1, curr.c));
        }
        return ret;
    }

    private record Pair(int r, int c) {}
}
// @lc code=end

