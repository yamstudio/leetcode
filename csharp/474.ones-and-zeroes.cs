/*
 * @lc app=leetcode id=474 lang=csharp
 *
 * [474] Ones and Zeroes
 */

// @lc code=start
public class Solution {
    public int FindMaxForm(string[] strs, int m, int n) {
        int[,] dp = new int[m + 1, n + 1];
        foreach (string str in strs) {
            int ones = 0, zeroes = 0;
            foreach (char c in str) {
                if (c == '1') {
                    ++ones;
                } else {
                    ++zeroes;
                }
            }
            for (int i = m; i >= zeroes; --i) {
                for (int j = n; j >= ones; --j) {
                    dp[i, j] = Math.Max(dp[i, j], dp[i - zeroes, j - ones] + 1);
                }
            }
        }
        return dp[m, n];
    }
}
// @lc code=end

