/*
 * @lc app=leetcode id=1263 lang=java
 *
 * [1263] Minimum Moves to Move a Box to Their Target Location
 */

import java.util.ArrayDeque;
import java.util.HashMap;
import java.util.Map;
import java.util.Queue;

// @lc code=start
class Solution {

    private static final Pos[] DIRS = new Pos[] {
        new Pos(-1, 0),
        new Pos(1, 0),
        new Pos(0, -1),
        new Pos(0, 1)
    };

    public int minPushBox(char[][] grid) {
        Pos target = null, box = null, start = null;
        int m = grid.length, n = grid[0].length;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                char c = grid[i][j];
                if (c == '.' || c == '#') {
                    continue;
                }
                if (c == 'S') {
                    start = new Pos(i, j);
                } else if (c == 'B') {
                    box = new Pos(i, j);
                } else {
                    target = new Pos(i, j);
                }
            }
        }
        Queue<State> queue = new ArrayDeque<>();
        State init = new State(box, start);
        queue.offer(init);
        Map<State, Integer> pushes = new HashMap<>();
        pushes.put(init, 0);
        int ret = Integer.MAX_VALUE;
        while (!queue.isEmpty()) {
            State curr = queue.poll();
            int currPushes = pushes.get(curr);
            if (currPushes >= ret) {
                continue;
            }
            if (curr.box().equals(target)) {
                ret = currPushes;
                continue;
            }
            for (Pos dir : DIRS) {
                Pos nextKeeper = new Pos(curr.keeper().r() + dir.r(), curr.keeper().c() + dir.c());
                if (nextKeeper.r() < 0 || nextKeeper.r() >= m || nextKeeper.c() < 0 || nextKeeper.c() >= n || grid[nextKeeper.r()][nextKeeper.c()] == '#') {
                    continue;
                }
                Pos nextBox;
                int nextPushes;
                if (nextKeeper.equals(curr.box())) {
                    nextPushes = currPushes + 1;
                    nextBox = new Pos(curr.box().r() + dir.r(), curr.box().c() + dir.c());
                    if (nextBox.r() < 0 || nextBox.r() >= m || nextBox.c() < 0 || nextBox.c() >= n || grid[nextBox.r()][nextBox.c()] == '#') {
                        continue;
                    }
                } else {
                    nextBox = curr.box();
                    nextPushes = currPushes;
                }
                State nextState = new State(nextBox, nextKeeper);
                Integer existingNextPushes = pushes.get(nextState);
                if (existingNextPushes != null && existingNextPushes <= nextPushes) {
                    continue;
                }
                pushes.put(nextState, nextPushes);
                queue.offer(nextState);
            }
        }
        return ret == Integer.MAX_VALUE ? -1 : ret;
    }

    private record Pos(int r, int c) {}
    private record State(Pos box, Pos keeper) {}
}
// @lc code=end

