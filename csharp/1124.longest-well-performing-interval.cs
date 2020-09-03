/*
 * @lc app=leetcode id=1124 lang=csharp
 *
 * [1124] Longest Well-Performing Interval
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int LongestWPI(int[] hours) {
        int acc = 0, ret = 0, n = hours.Length;
        var map = new Dictionary<int, int>();
        for (int i = 0; i < n; ++i) {
            if (hours[i] > 8) {
                ++acc;
            } else {
                --acc;
            }
            if (!map.ContainsKey(acc)) {
                map[acc] = i;
            }
            if (acc > 0) {
                ret = Math.Max(ret, i + 1);
            } else if (map.TryGetValue(acc - 1, out int prev)) {
                ret = Math.Max(ret, i - prev);
            }
        }
        return ret;
    }
}
// @lc code=end

