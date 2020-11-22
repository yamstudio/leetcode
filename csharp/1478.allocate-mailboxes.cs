/*
 * @lc app=leetcode id=1478 lang=csharp
 *
 * [1478] Allocate Mailboxes
 */

using System;

// @lc code=start
public class Solution {

    private static int MinDistance(int[,] cost, int n, int k, int i, int?[,] memo) {
        if (i == n) {
            return k == 0 ? 0 : 2000000;
        }
        if (k < 0) {
            return 2000000;
        }
        if (memo[k, i].HasValue) {
            return memo[k, i].Value;
        }
        int ret = 2000000;
        for (int j = i; j < n; ++j) {
            ret = Math.Min(ret, cost[i, j] + MinDistance(cost, n, k - 1, j + 1, memo));
        }
        memo[k, i] = ret;
        return ret;
    }

    public int MinDistance(int[] houses, int k) {
        int n = houses.Length;
        int[,] cost = new int[n, n];
        Array.Sort(houses);
        for (int i = 0; i < n; ++i) {
            for (int j = i; j < n; ++j) {
                int p = houses[(i + j) / 2];
                for (int t = i; t <= j; ++t) {
                    cost[i, j] += Math.Abs(p - houses[t]);
                }
            }
        }
        return MinDistance(cost, n, k, 0, new int?[k + 1, n]);
    }
}
// @lc code=end

