/*
 * @lc app=leetcode id=1391 lang=java
 *
 * [1391] Check if There is a Valid Path in a Grid
 */

import java.util.ArrayDeque;
import java.util.Queue;

// @lc code=start

class Solution {

    private static int[] INBOUNDS = new int[] {
        0b0011,
        0b1100,
        0b0110,
        0b0101,
        0b1010,
        0b1001,
    };

    private static int[] OUTBOUNDS = new int[] {
        0b0011,
        0b1100,
        0b1001,
        0b1010,
        0b0101,
        0b0110,
    };

    private static int[][] DIRS = new int[][] {
        new int[] { 0, -1, 0b0001, },
        new int[] { 0, 1, 0b0010, },
        new int[] { -1, 0, 0b0100, },
        new int[] { 1, 0, 0b1000, },
    };

    public boolean hasValidPath(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        boolean[][] visited = new boolean[m][n];
        Queue<Pair> queue = new ArrayDeque<>();
        queue.offer(new Pair(0, 0));
        while (!queue.isEmpty()) {
            Pair curr = queue.poll();
            int r = curr.r(), c = curr.c();
            if (r == m - 1 && c == n - 1) {
                return true;
            }
            visited[r][c] = true;
            for (int[] dir : DIRS) {
                if ((OUTBOUNDS[grid[r][c] - 1] & dir[2]) == 0) {
                    continue;
                }
                int nr = r + dir[0], nc = c + dir[1];
                if (nr < 0 || nr >= m || nc < 0 || nc >= n || visited[nr][nc] || (INBOUNDS[grid[nr][nc] - 1] & dir[2]) == 0) {
                    continue;
                }
                queue.offer(new Pair(nr, nc));
            }
        }
        return false;
    }

    private record Pair(int r, int c) {};
}
// @lc code=end

