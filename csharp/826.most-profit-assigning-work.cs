/*
 * @lc app=leetcode id=826 lang=csharp
 *
 * [826] Most Profit Assigning Work
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MaxProfitAssignment(int[] difficulty, int[] profit, int[] worker) {
        var tasks = difficulty.Zip(profit, (d, p) => (Difficulty: d, Profit: p)).OrderBy(task => task.Difficulty).ToArray();
        int n = profit.Length, i = 0, m = 0, ret = 0;
        foreach (var w in worker.OrderBy(w => w)) {
            while (i < n && tasks[i].Difficulty <= w) {
                m = Math.Max(m, tasks[i++].Profit);
            }
            ret += m;
        }
        return ret;
    }
}
// @lc code=end

