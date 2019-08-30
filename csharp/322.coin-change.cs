/*
 * @lc app=leetcode id=322 lang=csharp
 *
 * [322] Coin Change
 */

using System.Linq;

public class Solution {
    public int CoinChange(int[] coins, int amount) {
        int[] dp = new int[amount + 1];
        for (int i = 1; i <= amount; ++i) {
            dp[i] = coins.Where(c => c <= i && dp[i - c] >= 0).Select(c => (1 + dp[i - c])).DefaultIfEmpty(-1).Min();
        }
        return dp[amount];
    }
}

