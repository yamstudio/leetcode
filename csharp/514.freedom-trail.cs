/*
 * @lc app=leetcode id=514 lang=csharp
 *
 * [514] Freedom Trail
 */

// @lc code=start
public class Solution {
    public int FindRotateSteps(string ring, string key) {
        int m = ring.Length, n = key.Length;
        int[,] dp = new int[n + 1, m];
        for (int i = n - 1; i >= 0; --i) {
            char curr = key[i];
            for (int j = 0; j < m; ++j) {
                dp[i, j] = int.MaxValue;
                for (int k = 0; k < m; ++k) {
                    if (ring[k] == curr) {
                        int diff = Math.Abs(j - k);
                        int d = Math.Min(m - diff, diff);
                        dp[i, j] = Math.Min(dp[i, j], d + dp[i + 1, k]);
                    }
                }
            }
        }
        return dp[0, 0] + n;
    }
}
// @lc code=end

