/*
 * @lc app=leetcode id=980 lang=java
 *
 * [980] Unique Paths III
 */

// @lc code=start
class Solution {
    public int uniquePathsIII(int[][] grid) {
        int m = grid.length, n = grid[0].length, state = 0, target = (1 << (m * n)) - 1, si = -1, sj = -1;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1) {
                    si = i;
                    sj = j;
                } else if (grid[i][j] == -1) {
                    state |= 1 << (i * n + j);
                }
            }
        }
        return helper(grid, state, target, si, sj);
    }

    private static int helper(int[][] grid, int state, int target, int i, int j) {
        int m = grid.length, n = grid[0].length;
        if (i < 0 || i >= m || j < 0 || j >= n) {
            return 0;
        }
        int nextState = state | (1 << (i * n + j));
        if (nextState == state) {
            return 0;
        }
        if (grid[i][j] == 2) {
            if (nextState == target) {
                return 1;
            }
            return 0;
        }
        return helper(grid, nextState, target, i - 1, j)
            + helper(grid, nextState, target, i + 1, j)
            + helper(grid, nextState, target, i, j - 1)
            + helper(grid, nextState, target, i, j + 1);
    }
}
// @lc code=end

