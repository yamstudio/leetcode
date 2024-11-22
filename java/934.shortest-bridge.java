/*
 * @lc app=leetcode id=934 lang=java
 *
 * [934] Shortest Bridge
 */

import java.util.ArrayDeque;
import java.util.HashSet;
import java.util.Queue;
import java.util.Set;

// @lc code=start
class Solution {

    private static final Set<Pair> DIRS = Set.of(
        new Pair(-1, 0),
        new Pair(1, 0),
        new Pair(0, -1),
        new Pair(0, 1)
    );

    public int shortestBridge(int[][] grid) {
        int n = grid.length;
        Pair island = findIsland(grid, n);
        Set<Pair> visited = new HashSet<>();
        Queue<Pair> queue = new ArrayDeque<>();
        addIsland(grid, island.r, island.c, n, visited, queue);
        int ret = 0;
        while (!queue.isEmpty()) {
            for (int l = queue.size(); l > 0; --l) {
                Pair curr = queue.poll();
                for (Pair dir : DIRS) {
                    Pair next = new Pair(curr.r + dir.r, curr.c + dir.c);
                    if (next.r < 0 || next.r >= n || next.c < 0 || next.c >= n || visited.contains(next)) {
                        continue;
                    }
                    visited.add(next);
                    if (grid[next.r][next.c] == 1) {
                        return ret;
                    }
                    queue.offer(next);
                }
            }
            ++ret;
        }
        throw new IllegalArgumentException();
    }

    private static Pair findIsland(int[][] grid, int n) {
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) {
                    continue;
                }
                return new Pair(i, j);
            }
        }
        throw new IllegalArgumentException();
    }

    private static void addIsland(int[][] grid, int i, int j, int n, Set<Pair> visited, Queue<Pair> queue) {
        if (i < 0 || i >= n || j < 0 || j >= n || grid[i][j] == 0) {
            return;
        }
        Pair pair = new Pair(i, j);
        if (visited.contains(pair)) {
            return;
        }
        visited.add(pair);
        queue.offer(pair);
        for (Pair dir : DIRS) {
            addIsland(grid, i + dir.r, j + dir.c, n, visited, queue);
        }
    }

    private record Pair(int r, int c) {}
}
// @lc code=end

