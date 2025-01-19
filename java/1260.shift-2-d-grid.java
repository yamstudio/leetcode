/*
 * @lc app=leetcode id=1260 lang=java
 *
 * [1260] Shift 2D Grid
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<List<Integer>> shiftGrid(int[][] grid, int k) {
        int m = grid.length, n = grid[0].length, total = m * n;
        List<List<Integer>> ret = new ArrayList<>(m);
        for (int i = 0; i < m; ++i) {
            List<Integer> row = new ArrayList<>(n);
            ret.add(row);
            for (int j = 0; j < n; ++j) {
                int o = (i * n + j - (k % total) + total) % total, oi = o / n, oj = o % n;
                row.add(grid[oi][oj]);
            }
        }
        return ret;
    }
}
// @lc code=end

