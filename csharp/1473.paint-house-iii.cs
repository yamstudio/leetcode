/*
 * @lc app=leetcode id=1473 lang=csharp
 *
 * [1473] Paint House III
 */

using System;

// @lc code=start
public class Solution {

    private const int MaxCost = 2000000;

    private static int MinCost(int[] houses, int[][] cost, int m, int n, int i, int nb, int prev, int?[,,] memo) {
        if (i == m) {
            return nb == 0 ? 0 : MaxCost;
        }
        if (nb < 0) {
            return MaxCost;
        }
        if (memo[i, nb, prev].HasValue) {
            return memo[i, nb, prev].Value;
        }
        int ret;
        if (houses[i] != 0) {
            ret = MinCost(houses, cost, m, n, i + 1, prev != houses[i] ? nb - 1 : nb, houses[i], memo);
        } else {
            ret = MaxCost;
            for (int c = 1; c <= n; ++c) {
                ret = Math.Min(ret, MinCost(houses, cost, m, n, i + 1, prev != c ? nb - 1 : nb, c, memo) + cost[i][c - 1]);
            }
        }
        memo[i, nb, prev] = ret;
        return ret;
    }

    public int MinCost(int[] houses, int[][] cost, int m, int n, int target) {
        int ret = MinCost(houses, cost, m, n, 0, target, 0, new int?[m, target + 1, n + 1]);
        return ret < MaxCost ? ret : -1;
    }
}
// @lc code=end

