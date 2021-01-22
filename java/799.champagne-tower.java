/*
 * @lc app=leetcode id=799 lang=java
 *
 * [799] Champagne Tower
 */

// @lc code=start
class Solution {
    public double champagneTower(int poured, int query_row, int query_glass) {
        double[] row = new double[query_row + 2];
        row[0] = poured;
        for (int i = 1; i <= query_row; ++i) {
            for (int j = i; j >= 0; --j) {
                row[j] = Math.max(0, (row[j] - 1) / 2.0);
                row[j + 1] += row[j];
            }
        }
        return Math.min(1.0, row[query_glass]);
    }
}
// @lc code=end

