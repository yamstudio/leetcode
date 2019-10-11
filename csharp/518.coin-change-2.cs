/*
 * @lc app=leetcode id=518 lang=csharp
 *
 * [518] Coin Change 2
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int Change(int amount, int[] coins) {
        int[] dp = new int[amount + 1];
        dp[0] = 1;
        foreach (int coin in coins) {
            for (int val = coin; val <= amount; ++val) {
                dp[val] += dp[val - coin];
            }
        }
        return dp[amount];
    }
}
// @lc code=end

