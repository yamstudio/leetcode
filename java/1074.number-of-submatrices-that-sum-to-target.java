/*
 * @lc app=leetcode id=1074 lang=java
 *
 * [1074] Number of Submatrices That Sum to Target
 */

import java.util.HashMap;
import java.util.Map;

// @lc code=start

class Solution {
    public int numSubmatrixSumTarget(int[][] matrix, int target) {
        int m = matrix.length, n = matrix[0].length;
        int[][] prefixSums = new int[m][n + 1];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                prefixSums[i][j + 1] = matrix[i][j] + prefixSums[i][j];
            }
        }
        int ret = 0;
        Map<Integer, Integer> count = new HashMap<>();
        for (int c1 = 0; c1 < n; ++c1) {
            for (int c2 = c1; c2 < n; ++c2) {
                int currSum = 0;
                count.put(0, 1);
                for (int r = 0; r < m; ++r) {
                    currSum += prefixSums[r][c2 + 1] - prefixSums[r][c1];
                    ret += count.getOrDefault(currSum - target, 0);
                    count.put(currSum, count.getOrDefault(currSum, 0) + 1);
                }
                count.clear();
            }
        }
        return ret;
    }
}
// @lc code=end

