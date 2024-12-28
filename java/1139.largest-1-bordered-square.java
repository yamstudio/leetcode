/*
 * @lc app=leetcode id=1139 lang=java
 *
 * [1139] Largest 1-Bordered Square
 */

// @lc code=start
class Solution {
    public int largest1BorderedSquare(int[][] grid) {
        int m = grid.length, n = grid[0].length;
        int[][] lcount = new int[m][n], tcount = new int[m][n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) {
                    continue;
                }
                lcount[i][j] = 1 + (i > 0 ? lcount[i - 1][j] : 0);
                tcount[i][j] = 1 + (j > 0 ? tcount[i][j - 1] : 0);
            }
        }
        for (int len = Math.min(m, n); len > 0; --len) {
            for (int mx = len - 1; mx < m; ++mx) {
                for (int my = len - 1; my < n; ++my) {
                    if (lcount[mx][my] >= len && tcount[mx][my] >= len && tcount[mx - len + 1][my] >= len && lcount[mx][my - len + 1] >= len) {
                        return len * len;
                    }
                }
            }
        }
        return 0;
    }
}
// @lc code=end

