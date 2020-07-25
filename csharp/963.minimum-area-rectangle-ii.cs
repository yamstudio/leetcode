/*
 * @lc app=leetcode id=963 lang=csharp
 *
 * [963] Minimum Area Rectangle II
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public double MinAreaFreeRect(int[][] points) {
        var map = new Dictionary<(double X, double Y, double Length), IList<(double X1, double Y1, double X2, double Y2)>>();
        double ret = double.MaxValue;
        int n = points.Length;
        for (int i = 0; i < n; ++i) {
            var p1 = points[i];
            for (int j = i + 1; j < n; ++j) {
                var p2 = points[j];
                double dist = Math.Pow(p1[0] - p2[0], 2) + Math.Pow(p1[1] - p2[1], 2);
                double x = (p1[0] + p2[0]) / 2.0;
                double y = (p1[1] + p2[1]) / 2.0;
                var key = (X: x, Y: y, Length: dist);
                if (!map.TryGetValue(key, out var list)) {
                    list = new List<(double X1, double Y1, double X2, double Y2)>();
                    map[key] = list;
                }
                list.Add((X1: p1[0], Y1: p1[1], X2: p2[0], Y2: p2[1]));
            }
        }
        foreach (var pairs in map.Values) {
            int m = pairs.Count;
            if (m == 1) {
                continue;
            }
            for (int i = 0; i < m; ++i) {
                var pair1 = pairs[i];
                for (int j = i + 1; j < m; ++j) {
                    var pair2 = pairs[j];
                    var area = Math.Sqrt((Math.Pow(pair1.X1 - pair2.X1, 2) + Math.Pow(pair1.Y1 - pair2.Y1, 2)) * (Math.Pow(pair1.X2 - pair2.X1, 2) + Math.Pow(pair1.Y2 - pair2.Y1, 2)));
                    ret = Math.Min(ret, area);
                }
            }
        }
        return ret == double.MaxValue ? 0 : ret;
    }
}
// @lc code=end

