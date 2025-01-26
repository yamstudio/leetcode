/*
 * @lc app=leetcode id=1289 lang=java
 *
 * [1289] Minimum Falling Path Sum II
 */

// @lc code=start
class Solution {
    public int minFallingPathSum(int[][] grid) {
        int n = grid.length, mi1 = -1, mv1 = 0, mv2 = 0;
        for (int i = 0; i < n; ++i) {
            int nmi1 = -1, nmv1 = Integer.MAX_VALUE, nmv2 = Integer.MAX_VALUE;
            for (int j = 0; j < n; ++j) {
                int v = grid[i][j] + (j == mi1 ? mv2 : mv1);
                if (v < nmv1) {
                    nmv2 = nmv1;
                    nmi1 = j;
                    nmv1 = v;
                } else if (v < nmv2) {
                    nmv2 = v;
                }
            }
            mi1 = nmi1;
            mv1 = nmv1;
            mv2 = nmv2;
        }
        return mv1;
    }
}
// @lc code=end

