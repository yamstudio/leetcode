/*
 * @lc app=leetcode id=1074 lang=csharp
 *
 * [1074] Number of Submatrices That Sum to Target
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int NumSubmatrixSumTarget(int[][] matrix, int target) {
        int m = matrix.Length, n = matrix[0].Length, ret = 0;
        var sums = new int[m, n];
        for (int i = 0; i < m; ++i) {
            int sum = 0;
            for (int j = 0; j < n; ++j) {
                sum += matrix[i][j];
                sums[i, j] = sum;
            }
        }
        for (int c1 = 0; c1 < n; ++c1) {
            for (int c2 = c1; c2 < n; ++c2) {
                var dp = new Dictionary<int, int>();
                var sum = 0;
                dp[0] = 1;
                for (int r = 0; r < m; ++r) {
                    if (c1 == 0) {
                        sum += sums[r, c2];
                    } else {
                        sum += sums[r, c2] - sums[r, c1 - 1];
                    }
                    if (dp.TryGetValue(sum - target, out int c)) {
                        ret += c;
                    }
                    if (dp.TryGetValue(sum, out int a)) {
                        dp[sum] = a + 1;
                    } else {
                        dp[sum] = 1;
                    }
                }
            }
        }
        return ret;
    }
}
// @lc code=end

