/*
 * @lc app=leetcode id=1376 lang=csharp
 *
 * [1376] Time Needed to Inform All Employees
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int NumOfMinutes(int n, int headID, int[] manager, int[] informTime) {
        int ret = 0;
        int[] time = Enumerable.Repeat(-1, n).ToArray();
        for (int i = 0; i < n; ++i) {
            int c = manager[i], acc = 0;
            while (c != -1) {
                acc += informTime[c];
                if (time[c] >= 0) {
                    acc += time[c];
                    break;
                }
                c = manager[c];
            }
            time[i] = acc;
            ret = Math.Max(ret, acc);
        }
        return ret;
    }
}
// @lc code=end

