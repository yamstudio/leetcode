/*
 * @lc app=leetcode id=221 lang=csharp
 *
 * [221] Maximal Square
 */

using System.Linq;

public class Solution {
    public int MaximalSquare(char[][] matrix) {
        int m = matrix.Length, n, ret;
        if (m == 0) {
            return 0;
        }
        n = matrix[0].Length;
        int[] dp = matrix[0].Select(c => (int) c - (int) '0').ToArray();
        ret = dp.Any(s => s > 0) ? 1 : 0;
        for (int i = 1; i < m; ++i) {
            int prev = dp[0];
            dp[0] = matrix[i][0] == '0' ? 0 : 1;
            ret = Math.Max(ret, dp[0]);
            for (int j = 1; j < n; ++j) {
                int tmp = dp[j];
                dp[j] = matrix[i][j] == '0' ? 0 : Math.Min(dp[j - 1], Math.Min(prev, dp[j])) + 1;
                prev = tmp;
                ret = Math.Max(ret, dp[j]);
            }
        }
        return ret * ret;
    }
}

