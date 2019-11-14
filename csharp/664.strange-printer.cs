/*
 * @lc app=leetcode id=664 lang=csharp
 *
 * [664] Strange Printer
 */

// @lc code=start
public class Solution {
    public int StrangePrinter(string s) {
        int n = s.Length;
        if (n == 0) {
            return 0;
        }
        int[,] dp = new int[n, n];
        for (int i = n - 1; i >= 0; --i) {
            char c = s[i];
            dp[i, i] = 1;
            for (int j = i + 1; j < n; ++j) {
                dp[i, j] = 1 + dp[i + 1, j];
                for (int k = i + 1; k <= j; ++k) {
                    if (s[k] == c) {
                        dp[i, j] = Math.Min(dp[i, j], dp[k, j] + dp[i + 1, k - 1]);
                    }
                }
            }
        }
        return dp[0, n - 1];
    }
}
// @lc code=end

