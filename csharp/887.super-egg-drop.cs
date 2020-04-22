/*
 * @lc app=leetcode id=887 lang=csharp
 *
 * [887] Super Egg Drop
 */

using System;

// @lc code=start
public class Solution {
    public int SuperEggDrop(int K, int N) {
        int[,] dp = new int[K + 1, N + 1];
        for (int j = 1; j <= N; ++j) {
            dp[1, j] = j;
        }
        for (int i = 2; i <= K; ++i) {
            int l = 1;
            for (int j = 1; j <= N; ++j) {
                while (l < j && dp[i - 1, l - 1] < dp[i, j - l]) {
                    ++l;
                }
                dp[i, j] = Math.Min(j, dp[i - 1, l - 1] + 1);
            }
        }
        return dp[K, N];
    }
}
// @lc code=end

