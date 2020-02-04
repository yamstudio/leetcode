/*
 * @lc app=leetcode id=813 lang=csharp
 *
 * [813] Largest Sum of Averages
 */

using System;

// @lc code=start
public class Solution {
    public double LargestSumOfAverages(int[] A, int K) {
        int n = A.Length;
        int[] sums = new int[n + 1];
        double[,] dp = new double[n, K];
        for (int i = 0; i < n; ++i) {
            sums[i + 1] = sums[i] + A[i];
        }
        for (int i = 0; i < n; ++i) {
            dp[i, 0] = (double)(sums[n] - sums[i]) / (double)(n - i);
        }
        for (int k = 1; k < K; ++k) {
            for (int i = 0; i < n; ++i) {
                for (int j = i + 1; j < n; ++j) {
                    dp[i, k] = Math.Max(dp[i, k], dp[j, k - 1] + (double)(sums[j] - sums[i]) / (double)(j - i));
                }
            }
        }
        return dp[0, K - 1];
    }
}
// @lc code=end

