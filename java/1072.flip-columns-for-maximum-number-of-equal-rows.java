/*
 * @lc app=leetcode id=1072 lang=java
 *
 * [1072] Flip Columns For Maximum Number of Equal Rows
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int maxEqualRowsAfterFlips(int[][] matrix) {
        int ret = 0;
        Map<String, Integer> count = new HashMap<>();
        for (int[] row : matrix) {
            String p = pattern(row);
            int v = count.getOrDefault(p, 0) + 1;
            ret = Math.max(ret, v);
            count.put(p, v);
        }
        return ret;
    }

    private static String pattern(int[] row) {
        StringBuilder sb = new StringBuilder(row.length);
        boolean flip = row[0] == 1;
        for (int c : row) {
            sb.append(flip ? 1 - c : c);
        }
        return sb.toString();
    }
}
// @lc code=end

