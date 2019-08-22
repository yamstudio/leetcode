/*
 * @lc app=leetcode id=279 lang=csharp
 *
 * [279] Perfect Squares
 */
public class Solution {
    public int NumSquares(int n) {
        int[] dp = new int[n + 1];
        for (int i = 1; i <= n; ++i) {
            int m = int.MaxValue;
            for (int j = 1; j * j <= i; ++j) {
                m = Math.Min(m, 1 + dp[i - j * j]);
            }
            dp[i] = m;
        }
        return dp[n];
    }
}

