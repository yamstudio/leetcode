/*
 * @lc app=leetcode id=629 lang=csharp
 *
 * [629] K Inverse Pairs Array
 */

// @lc code=start
public class Solution {
    public int KInversePairs(int n, int k) {
        int[,] dp = new int[n + 1, k + 1];
        dp[0, 0] = 1;
        for (int i = 1; i <= n; ++i) {
            dp[i, 0] = 1;
            for (int j = 1; j <= k; ++j) {
                dp[i, j] = (dp[i - 1, j] + dp[i, j - 1]) % 1000000007;
                if (j >= i) {
                    dp[i, j] = (dp[i, j] - dp[i - 1, j - i] + 1000000007) % 1000000007;
                }
            }
        }
        return dp[n, k];
    }
}
// @lc code=end

