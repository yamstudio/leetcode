/*
 * @lc app=leetcode id=1665 lang=csharp
 *
 * [1665] Minimum Initial Energy to Finish Tasks
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int MinimumEffort(int[][] tasks) {
        int ret = 0, acc = 0;
        foreach (var task in tasks.OrderByDescending(t => t[1] - t[0])) {
            if (acc < task[1]) {
                ret += task[1] - acc;
                acc = task[1];
            }
            acc -= task[0];
        }
        return ret;
    }
}
// @lc code=end

