/*
 * @lc app=leetcode id=1547 lang=csharp
 *
 * [1547] Minimum Cost to Cut a Stick
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinCost(int n, int[] cuts) {
        var all = cuts.Append(0).Append(n).OrderBy(x => x).ToArray();
        int k = all.Length;
        int[,] dp = new int[k, k];
        for (int l = 2; l < k; ++l) {
            for (int i = 0; i + l < k; ++i) {
                int cost = all[i + l] - all[i];
                dp[i, i + l] = 100000000;
                for (int j = i + 1; j < i + l; ++j) {
                    dp[i, i + l] = Math.Min(dp[i, i + l], cost + dp[i, j] + dp[j, i + l]);
                }
            }
        }
        return dp[0, k - 1];
    }
}
// @lc code=end

