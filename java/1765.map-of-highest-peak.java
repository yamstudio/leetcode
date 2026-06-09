/*
 * @lc app=leetcode id=1765 lang=java
 *
 * [1765] Map of Highest Peak
 */

// @lc code=start
class Solution {
    public int[][] highestPeak(int[][] isWater) {
        int m = isWater.length, n = isWater[0].length;
        int[][] ret = new int[m][n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (isWater[i][j] == 1) {
                    continue;
                }
                ret[i][j] = 1_000_000;
                if (i > 0) {
                    ret[i][j] = Math.min(ret[i][j], ret[i - 1][j] + 1);
                }
                if (j > 0) {
                    ret[i][j] = Math.min(ret[i][j], ret[i][j - 1] + 1);
                }
            }
        }
        for (int i = m - 1; i >= 0; --i) {
            for (int j = n - 1; j >= 0; --j) {
                if (i < m - 1) {
                    ret[i][j] = Math.min(ret[i][j], ret[i + 1][j] + 1);
                }
                if (j < n - 1) {
                    ret[i][j] = Math.min(ret[i][j], ret[i][j + 1] + 1);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

