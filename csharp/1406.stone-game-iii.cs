/*
 * @lc app=leetcode id=1406 lang=csharp
 *
 * [1406] Stone Game III
 */

using System;

// @lc code=start
public class Solution {
    public string StoneGameIII(int[] stoneValue) {
        int n = stoneValue.Length;
        var dp = new int[n + 1];
        for (int i = n - 1; i >= 0; --i) {
            int first = 0;
            dp[i] = int.MinValue;
            for (int k = 0; k < 3 && i + k < n; ++k) {
                first += stoneValue[i + k];
                dp[i] = Math.Max(dp[i], first - dp[1 + i + k]);
            }
        }
        return dp[0] == 0 ? "Tie" : (dp[0] > 0 ? "Alice" : "Bob");
    }
}
// @lc code=end

