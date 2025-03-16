/*
 * @lc app=leetcode id=1463 lang=java
 *
 * [1463] Cherry Pickup II
 */

// @lc code=start
class Solution {
    public int cherryPickup(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        return cherryPickup(grid, 0, 0, n - 1, new Integer[m][n][n]);
    }

    private static int cherryPickup(int[][] grid, int r, int c1, int c2, Integer[][][] memo) {
        int m = grid.length, n = grid[0].length;
        if (m == r || c1 < 0 || c1 >= n || c2 < 0 || c2 >= n) {
            return 0;
        }
        Integer existing = memo[r][c1][c2];
        if (existing != null) {
            return existing;
        }
        int ret = cherryPickup(grid, r + 1, c1 - 1, c2 - 1, memo);
        ret = Math.max(ret, cherryPickup(grid, r + 1, c1 - 1, c2, memo));
        ret = Math.max(ret, cherryPickup(grid, r + 1, c1 - 1, c2 + 1, memo));
        ret = Math.max(ret, cherryPickup(grid, r + 1, c1, c2 - 1, memo));
        ret = Math.max(ret, cherryPickup(grid, r + 1, c1, c2, memo));
        ret = Math.max(ret, cherryPickup(grid, r + 1, c1, c2 + 1, memo));
        ret = Math.max(ret, cherryPickup(grid, r + 1, c1 + 1, c2 - 1, memo));
        ret = Math.max(ret, cherryPickup(grid, r + 1, c1 + 1, c2, memo));
        ret = Math.max(ret, cherryPickup(grid, r + 1, c1 + 1, c2 + 1, memo));
        ret += grid[r][c1];
        if (c1 != c2) {
            ret += grid[r][c2];
        }
        memo[r][c1][c2] = ret;
        return ret;
    }
}
// @lc code=end

