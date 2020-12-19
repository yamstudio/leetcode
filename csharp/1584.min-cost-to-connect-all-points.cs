/*
 * @lc app=leetcode id=1584 lang=csharp
 *
 * [1584] Min Cost to Connect All Points
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinCostConnectPoints(int[][] points) {
        int curr = 0, n = points.Length, ret = 0;
        var dists = Enumerable.Repeat(int.MaxValue, n).ToArray();
        var available = Enumerable.Range(0, n).ToHashSet();
        while (--n > 0) {
            int next = -1, md = int.MaxValue;
            available.Remove(curr);
            foreach (var p in available) {
                int dist = Math.Abs(points[curr][0] - points[p][0]) + Math.Abs(points[curr][1] - points[p][1]);
                dists[p] = Math.Min(dists[p], dist);
                if (dists[p] < md) {
                    md = dists[p];
                    next = p;
                }
            }
            ret += md;
            curr = next;
        }
        return ret;
    }
}
// @lc code=end

