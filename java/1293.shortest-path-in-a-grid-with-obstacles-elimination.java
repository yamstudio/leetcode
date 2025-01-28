/*
 * @lc app=leetcode id=1293 lang=java
 *
 * [1293] Shortest Path in a Grid with Obstacles Elimination
 */

import java.util.ArrayDeque;
import java.util.HashMap;
import java.util.Map;
import java.util.Queue;

// @lc code=start

class Solution {

    private static final Pair[] DIRS = new Pair[] {
        new Pair(-1, 0),
        new Pair(1, 0),
        new Pair(0, -1),
        new Pair(0, 1)
    };

    public int shortestPath(int[][] grid, int k) {
        int ret = 0, m = grid.length, n = grid[0].length;
        Map<Pair, Integer> pairToRemaining = new HashMap<>();
        Queue<State> queue = new ArrayDeque<>();
        pairToRemaining.put(new Pair(0, 0), k);
        queue.offer(new State(new Pair(0, 0), k));
        while (!queue.isEmpty()) {
            for (int i = queue.size(); i > 0; --i) {
                State curr = queue.poll();
                int r = curr.pair().r(), c = curr.pair().c();
                if (r == m - 1 && c == n - 1) {
                    return ret;
                }
                for (Pair dir : DIRS) {
                    int nr = r + dir.r(), nc = c + dir.c();
                    if (nr < 0 || nr >= m || nc < 0 || nc >= n) {
                        continue;
                    }
                    int nk = curr.remaining();
                    if (grid[nr][nc] == 1) {
                        if (nk == 0) {
                            continue;
                        }
                        --nk;
                    }
                    Pair np = new Pair(nr, nc);
                    Integer rem = pairToRemaining.get(np);
                    if (rem != null && rem >= nk) {
                        continue;
                    }
                    pairToRemaining.put(np, nk);
                    queue.offer(new State(np, nk));
                }
            }
            ++ret;
        }
        return -1;
    }

    private record Pair(int r, int c) {}
    private record State(Pair pair, int remaining) {}
}
// @lc code=end

