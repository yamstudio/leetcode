/*
 * @lc app=leetcode id=1036 lang=java
 *
 * [1036] Escape a Large Maze
 */

import java.util.HashSet;
import java.util.Set;

// @lc code=start
class Solution {

    private static final Pair[] DIRS = new Pair[] {
        new Pair(-1, 0),
        new Pair(1, 0),
        new Pair(0, -1),
        new Pair(0, 1)
    };

    public boolean isEscapePossible(int[][] blocked, int[] source, int[] target) {
        Set<Pair> blocks = new HashSet<>(blocked.length);
        for (int[] block : blocked) {
            blocks.add(new Pair(block[0], block[1]));
        }
        Set<Pair> visited = new HashSet<>();
        if (!isEscapePossible(blocks, source[0], source[1], target, visited)) {
            return false;
        }
        visited.clear();
        return isEscapePossible(blocks, target[0], target[1], source, visited);
    }

    private static boolean isEscapePossible(Set<Pair> blocks, int r, int c, int[] target, Set<Pair> visited) {
        if (r < 0 || r >= 1000000 || c < 0 || c >= 1000000) {
            return false;
        }
        Pair curr = new Pair(r, c);
        if (blocks.contains(curr)) {
            return false;
        }
        if (!visited.add(curr)) {
            return false;
        }
        if (visited.size() >= 20000 || (r == target[0] && c == target[1])) {
            return true;
        }
        for (Pair dir : DIRS) {
            if (isEscapePossible(blocks, r + dir.r, c + dir.c, target, visited)) {
                return true;
            }
        }
        return false;
    }

    private record Pair(int r, int c) {}
}
// @lc code=end

