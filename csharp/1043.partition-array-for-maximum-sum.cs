/*
 * @lc app=leetcode id=1043 lang=csharp
 *
 * [1043] Partition Array for Maximum Sum
 */

using System;

// @lc code=start
public class Solution {
    public int MaxSumAfterPartitioning(int[] A, int K) {
        int n = A.Length;
        var dp = new int[n + 1];
        for (int i = 0; i < n; ++i) {
            int m = A[i];
            for (int j = 1; j <= K && i - j + 1 >= 0; ++j) {
                m = Math.Max(m, A[i - j + 1]);
                dp[i + 1] = Math.Max(dp[i + 1], j * m + dp[i - j + 1]);
            }
        }
        return dp[n];
    }
}
// @lc code=end

