/*
 * @lc app=leetcode id=1335 lang=csharp
 *
 * [1335] Minimum Difficulty of a Job Schedule
 */

using System;

// @lc code=start
public class Solution {
    public int MinDifficulty(int[] jobDifficulty, int d) {
        int n = jobDifficulty.Length;
        if (n < d) {
            return -1;
        }
        var dp = new int[n, d];
        dp[0, 0] = jobDifficulty[0];
        for (int i = 1; i < n; ++i) {
            dp[i, 0] = Math.Max(dp[i - 1, 0], jobDifficulty[i]);
        }
        for (int j = 1; j < d; ++j) {
            for (int i = j; i < n; ++i) {
                int m = jobDifficulty[i];
                dp[i, j] = int.MaxValue;
                for (int ni = i; ni >= j; --ni) {
                    m = Math.Max(m, jobDifficulty[ni]);
                    dp[i, j] = Math.Min(dp[i, j], m + dp[ni - 1, j - 1]);
                }
            }
        }
        return dp[n - 1, d - 1];
    }
}
// @lc code=end

