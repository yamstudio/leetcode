/*
 * @lc app=leetcode id=1473 lang=java
 *
 * [1473] Paint House III
 */

// @lc code=start
class Solution {

    private static final int IMPOSSIBLE = 1234567;

    public int minCost(int[] houses, int[][] cost, int m, int n, int target) {
        int ret = minCost(houses, cost, m, n, target, 0, 0, new Integer[target + 1][m][n + 1]);
        return ret < IMPOSSIBLE ? ret : -1;
    }

    private static int minCost(int[] houses, int[][] cost, int m, int n, int neighborhoods, int i, int prev, Integer[][][] memo) {
        if (i == m) {
            return neighborhoods == 0 ? 0 : IMPOSSIBLE;
        }
        if (neighborhoods < 0) {
            return IMPOSSIBLE;
        }
        Integer existing = memo[neighborhoods][i][prev];
        if (existing != null) {
            return existing;
        }
        int ret;
        if (houses[i] > 0) {
            ret = minCost(houses, cost, m, n, neighborhoods - (prev == houses[i] ? 0 : 1), i + 1, houses[i], memo);
        } else {
            ret = IMPOSSIBLE;
            for (int c = 0; c < n; ++c) {
                ret = Math.min(ret, cost[i][c] + minCost(houses, cost, m, n, neighborhoods - (prev == c + 1 ? 0 : 1), i + 1, c + 1, memo));
            }
        }
        memo[neighborhoods][i][prev] = ret;
        return ret;
    }
}
// @lc code=end

