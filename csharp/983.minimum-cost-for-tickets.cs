/*
 * @lc app=leetcode id=983 lang=csharp
 *
 * [983] Minimum Cost For Tickets
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MincostTickets(int[] days, int[] costs) {
        int m = days[days.Length - 1];
        var travel = new HashSet<int>(days);
        var dp = new int[m + 1];
        for (int i = 1; i <= m; ++i) {
            if (!travel.Contains(i)) {
                dp[i] = dp[i - 1];
                continue;
            }
            dp[i] = Math.Min(dp[i - 1] + costs[0], Math.Min(dp[Math.Max(0, i - 7)] + costs[1], dp[Math.Max(0, i - 30)] + costs[2]));
        }
        return dp[m];
    }
}
// @lc code=end

