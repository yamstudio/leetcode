/*
 * @lc app=leetcode id=764 lang=csharp
 *
 * [764] Largest Plus Sign
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int OrderOfLargestPlusSign(int N, int[][] mines) {
        int[,] dp = new int[N, N];
        int ret = 0;
        var set = new HashSet<int>(mines.Select(loc => loc[0] * N + loc[1]));
        for (int i = 0; i < N; ++i) {
            int count = 0;
            for (int j = 0; j < N; ++j) {
                count = set.Contains(i * N + j) ? 0 : (1 + count);
                dp[i, j] = count;
            }
            count = 0;
            for (int j = N - 1; j >= 0; --j) {
                count = set.Contains(i * N + j) ? 0 : (1 + count);
                dp[i, j] = Math.Min(count, dp[i, j]);
            }
        }
        for (int j = 0; j < N; ++j) {
            int count = 0;
            for (int i = 0; i < N; ++i) {
                count = set.Contains(i * N + j) ? 0 : (1 + count);
                dp[i, j] = Math.Min(count, dp[i, j]);
            }
            count = 0;
            for (int i = N - 1; i >= 0; --i) {
                count = set.Contains(i * N + j) ? 0 : (1 + count);
                dp[i, j] = Math.Min(count, dp[i, j]);
                ret = Math.Max(ret, dp[i, j]);
            }
        }
        return ret;
    }
}
// @lc code=end

