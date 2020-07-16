/*
 * @lc app=leetcode id=939 lang=csharp
 *
 * [939] Minimum Area Rectangle
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MinAreaRect(int[][] points) {
        var map = new Dictionary<int, HashSet<int>>();
        int ret = int.MaxValue;
        foreach (var point in points) {
            HashSet<int> set;
            if (!map.TryGetValue(point[0], out set)) {
                set = new HashSet<int>();
                map[point[0]] = set;
            }
            set.Add(point[1]);
        }
        for (int i = points.Length - 1; i >= 0; --i) {
            var a = points[i];
            for (int j = i - 1; j >= 0; --j) {
                var b = points[j];
                if (a[0] == b[0] || a[1] == b[1]) {
                    continue;
                }
                if (map[a[0]].Contains(b[1]) && map[b[0]].Contains(a[1])) {
                    ret = Math.Min(ret, Math.Abs(a[0] - b[0]) * Math.Abs(a[1] - b[1]));
                }
            }
        }
        return ret == int.MaxValue ? 0 : ret;
    }
}
// @lc code=end

