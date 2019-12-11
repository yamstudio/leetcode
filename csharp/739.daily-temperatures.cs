/*
 * @lc app=leetcode id=739 lang=csharp
 *
 * [739] Daily Temperatures
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int[] DailyTemperatures(int[] T) {
        IList<int> stack = new List<int>();
        int n = T.Length;
        int[] ret = new int[n];
        for (int i = 0; i < n; ++i) {
            int t = T[i];
            for (int j = stack.Count - 1; j >= 0; --j) {
                int p = stack[j];
                if (T[p] >= t) {
                    break;
                }
                stack.RemoveAt(j);
                ret[p] = i - p;
            }
            stack.Add(i);
        }
        return ret;
    }
}
// @lc code=end

