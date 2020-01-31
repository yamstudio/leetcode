/*
 * @lc app=leetcode id=799 lang=csharp
 *
 * [799] Champagne Tower
 */

using System;

// @lc code=start
public class Solution {
    public double ChampagneTower(int poured, int query_row, int query_glass) {
        double[] val = new double[query_row + 2];
        val[0] = poured;
        for (int i = 1; i <= query_row; ++i) {
            for (int j = i; j >= 0; --j) {
                val[j] = Math.Max(0.0, (val[j] - 1) / 2.0);
                val[j + 1] += val[j];
            }
        }
        return Math.Min(1.0, val[query_glass]);
    }
}
// @lc code=end

