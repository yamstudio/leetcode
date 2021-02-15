/*
 * @lc app=leetcode id=871 lang=java
 *
 * [871] Minimum Number of Refueling Stops
 */

// @lc code=start
class Solution {
    public int minRefuelStops(int target, int startFuel, int[][] stations) {
        int n = stations.length;
        long[] dp = new long[n + 1];
        dp[0] = (long)startFuel;
        for (int i = 0; i < n; ++i) {
            int t = stations[i][0], f = stations[i][1];
            for (int j = i; j >= 0 && dp[j] >= t; --j) {
                dp[j + 1] = Math.max(dp[j + 1], dp[j] + (long)f);
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

