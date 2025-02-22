/*
 * @lc app=leetcode id=1380 lang=java
 *
 * [1380] Lucky Numbers in a Matrix
 */

import java.util.ArrayList;
import java.util.List;

// @lc code=start
class Solution {
    public List<Integer> luckyNumbers(int[][] matrix) {
        List<Integer> ret = new ArrayList<>();
        int m = matrix.length, n = matrix[0].length;
        int[] rowMin = new int[m];
        for (int r = 0; r < m; ++r) {
            int[] row = matrix[r];
            rowMin[r] = Integer.MAX_VALUE;
            for (int c = 0; c < n; ++c) {
                rowMin[r] = Math.min(rowMin[r], row[c]);
            }
        }
        for (int c = 0; c < n; ++c) {
            int mr = 0;
            for (int r = 1; r < m; ++r) {
                if (matrix[r][c] > matrix[mr][c]) {
                    mr = r;
                }
            }
            if (rowMin[mr] == matrix[mr][c]) {
                ret.add(rowMin[mr]);
            }
        }
        return ret;
    }
}
// @lc code=end

