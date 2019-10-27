/*
 * @lc app=leetcode id=583 lang=csharp
 *
 * [583] Delete Operation for Two Strings
 */

// @lc code=start
public class Solution {
    public int MinDistance(string word1, string word2) {
        int m = word1.Length, n = word2.Length;
        int[,] dp = new int[m + 1, n + 1];
        for (int i = 1; i <= m; ++i) {
            for (int j = 1; j <= n; ++j) {
                if (word1[i - 1] == word2[j - 1]) {
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                } else {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }
        return m + n - 2 * dp[m, n];
    }
}
// @lc code=end

