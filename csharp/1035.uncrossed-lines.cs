/*
 * @lc app=leetcode id=1035 lang=csharp
 *
 * [1035] Uncrossed Lines
 */

using System;

// @lc code=start
public class Solution {
    public int MaxUncrossedLines(int[] A, int[] B) {
        int m = A.Length, n = B.Length;
        var dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                if (A[i - 1] == B[j - 1]) {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                } else {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }
        return dp[m, n];
    }
}
// @lc code=end

