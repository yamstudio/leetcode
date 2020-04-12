/*
 * @lc app=leetcode id=871 lang=csharp
 *
 * [871] Minimum Number of Refueling Stops
 */

using System;

// @lc code=start
public class Solution {
    public int MinRefuelStops(int target, int startFuel, int[][] stations) {
        int n = stations.Length;
        long[] dp = new long[n + 1];
        dp[0] = (long)startFuel;
        for (int i = 0; i < n; ++i) {
            long pos = (long)stations[i][0], fuel = (long)stations[i][1];
            for (int j = i; j >= 0 && dp[j] >= pos; --j) {
                dp[j + 1] = Math.Max(dp[j + 1], dp[j] + fuel);
            }
        }
        for (int i = 0; i <= n; ++i) {
            if (dp[i] >= (long)target) {
                return i;
            }
        }
        return -1;
    }
}
// @lc code=end

