/*
 * @lc app=leetcode id=879 lang=csharp
 *
 * [879] Profitable Schemes
 */

using System;;

// @lc code=start
public class Solution {
    public int ProfitableSchemes(int G, int P, int[] group, int[] profit) {
        int n = group.Length, ret = 0;
        int[,,] dp = new int[n + 1, G + 1, P + 1];
        dp[0, 0, 0] = 1;
        for (int i = 1; i <= n; ++i) {
            int g = group[i - 1], p = profit[i - 1];
            for (int j = 0; j <= G; ++j) {
                for (int k = 0; k <= P; ++k) {
                    dp[i, j, k] = dp[i - 1, j, k];
                    if (g <= j) {
                        dp[i, j, k] = (dp[i, j, k] + dp[i - 1, j - g, Math.Max(0, k - p)]) % 1000000007;
                    }
                }
            }
        }
        for (int j = 0; j <= G; ++j) {
            ret = (ret + dp[n, j, P]) % 1000000007;
        }
        return ret;
    }
}
// @lc code=end

