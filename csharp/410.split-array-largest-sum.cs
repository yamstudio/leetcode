/*
 * @lc app=leetcode id=410 lang=csharp
 *
 * [410] Split Array Largest Sum
 */
public class Solution {
    public int SplitArray(int[] nums, int m) {
        int n = nums.Length;
        int[] sums = new int[n + 1];
        int[,] dp = new int[n + 1, m + 1];
        for (int i = 1; i <= n; ++i) {
            sums[i] = sums[i - 1] + nums[i - 1];
            for (int j = 0; j <= m; ++j) {
                dp[i, j] = int.MaxValue;
            }
        }
        dp[0, 0] = 0;
        for (int j = 1; j <= m; ++j) {
            for (int i = 1; i <= n; ++i) {
                int val = sums[i];
                for (int k = j - 1; k < i; ++k) {
                    dp[i, j] = Math.Min(dp[i, j], Math.Max(val - sums[k], dp[k, j - 1]));
                }
            }
        }
        return dp[n, m];
    }
}

