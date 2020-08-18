/*
 * @lc app=leetcode id=1029 lang=csharp
 *
 * [1029] Two City Scheduling
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int TwoCitySchedCost(int[][] costs) {
        int ca = 0, cb = 0, ret = 0, n = costs.Length / 2;
        foreach (var cost in costs.OrderByDescending(c => Math.Abs(c[0] - c[1]))) {
            if (cb == n || (cost[0] < cost[1] && ca < n)) {
                ret += cost[0];
                ++ca;
            } else {
                ret += cost[1];
                ++cb;
            }
        }
        return ret;
    }
}
// @lc code=end

