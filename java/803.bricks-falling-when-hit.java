/*
 * @lc app=leetcode id=803 lang=java
 *
 * [803] Bricks Falling When Hit
 */

// @lc code=start
class Solution {

    private static void addBrick(int[][] grid, Set<String> bricks, int m, int n, int i, int j) {
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] != 1) {
            return;
        }
        String key = String.format("%d,%d", i, j);
        if (!bricks.add(key)) {
            return;
        }
        addBrick(grid, bricks, m, n, i - 1, j);
        addBrick(grid, bricks, m, n, i + 1, j);
        addBrick(grid, bricks, m, n, i, j - 1);
        addBrick(grid, bricks, m, n, i, j + 1);
    }

    public int[] hitBricks(int[][] grid, int[][] hits) {
        Set<String> bricks = new HashSet<String>();
        int m = grid.length, n = grid[0].length, k = hits.length;
        int[] ret = new int[k];
        for (int[] hit : hits) {
            --grid[hit[0]][hit[1]];
        }
        for (int j = 0; j < n; ++j) {
            addBrick(grid, bricks, m, n, 0, j);
        }
        for (int t = k - 1; t >= 0; --t) {
            int[] hit = hits[t];
            int i = hit[0], j = hit[1], oldSize = bricks.size();
            if (++grid[i][j] == 1 && (i == 0 || bricks.contains(String.format("%d,%d", i - 1, j)) || bricks.contains(String.format("%d,%d", i + 1, j)) || bricks.contains(String.format("%d,%d", i, j - 1)) || bricks.contains(String.format("%d,%d", i, j + 1)))) {
                addBrick(grid, bricks, m, n, i, j);
                ret[t] = bricks.size() - 1 - oldSize;
            }
        }
        return ret;
    }
}
// @lc code=end

