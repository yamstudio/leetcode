/*
 * @lc app=leetcode id=1706 lang=java
 *
 * [1706] Where Will the Ball Fall
 */

// @lc code=start
class Solution {
    public int[] findBall(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            int c = i;
            for (int r = 0; r < m; ++r) {
                int nc = c + grid[r][c];
                if (nc < 0 || nc >= n || grid[r][nc] != grid[r][c]) {
                    c = -1;
                    break;
                }
                c = nc;
            }
            ret[i] = c;
        }
        return ret;
    }
}
// @lc code=end

