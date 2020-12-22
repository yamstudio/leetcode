/*
 * @lc app=leetcode id=1595 lang=csharp
 *
 * [1595] Minimum Cost to Connect Two Groups of Points
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int ConnectTwoGroups(IList<IList<int>> cost, int[] mins, int m, int n, int i, int state, int?[,] memo) {
        if (memo[i, state].HasValue) {
            return memo[i, state].Value;
        }
        int ret = int.MaxValue;
        if (i == m) {
            ret = mins
                .Where((x, i) => (state & (1 << i)) == 0)
                .Sum();
            memo[i, state] = ret;
            return ret;
        }
        for (int j = 0; j < n; ++j) {
            ret = Math.Min(ret, cost[i][j] + ConnectTwoGroups(cost, mins, m, n, i + 1, state | (1 << j), memo));
        }
        memo[i, state] = ret;
        return ret;
    }

    public int ConnectTwoGroups(IList<IList<int>> cost) {
        int m = cost.Count, n = cost[0].Count;
        var mins = Enumerable.Repeat(int.MaxValue, n).ToArray();
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                mins[j] = Math.Min(mins[j], cost[i][j]);
            }
        }
        return ConnectTwoGroups(cost, mins, m, n, 0, 0, new int?[m + 1, 1 << n]);
    }
}
// @lc code=end

