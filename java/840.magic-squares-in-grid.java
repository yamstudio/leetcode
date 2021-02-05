/*
 * @lc app=leetcode id=840 lang=java
 *
 * [840] Magic Squares In Grid
 */

// @lc code=start
class Solution {
    public int numMagicSquaresInside(int[][] grid) {
        int ret = 0, m = grid.length, n = grid[0].length;
        for (int i = 0; i < m - 2; ++i) {
            for (int j = 0; j < n - 2; ++j) {
                if (grid[i + 1][j + 1] != 5) {
                    continue;
                }
                int mask = 0;
                for (int a = 0; a < 3 && mask >= 0; ++a) {
                    int rs = 0, cs = 0;
                    for (int b = 0; b < 3 && mask >= 0; ++b) {
                        int v = grid[i + a][j + b];
                        if (v <= 0 || v >= 10 || (mask & (1 << v)) != 0) {
                            mask = -1;
                        } else {
                            mask |= 1 << v;
                        }
                        rs += v;
                        cs += grid[i + b][j + a];
                    }
                    if (rs != 15 || cs != 15) {
                        mask = -1;
                    }
                }
                if (mask < 0) {
                    continue;
                }
                if (grid[i][j] + grid[i + 2][j + 2] == grid[i + 2][j] + grid[i][j + 2]) {
                    ++ret;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

