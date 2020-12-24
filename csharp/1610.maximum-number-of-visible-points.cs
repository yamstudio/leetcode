/*
 * @lc app=leetcode id=1610 lang=csharp
 *
 * [1610] Maximum Number of Visible Points
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int VisiblePoints(IList<IList<int>> points, int angle, IList<int> location) {
        int overlap = 0, ret = 0;
        var angles = new List<double>();
        foreach (var point in points) {
            double dx = (double)point[0] - (double)location[0], dy = (double)point[1] - (double)location[1];
            if (dx == 0) {
                if (dy == 0) {
                    ++overlap;
                } else if (dy < 0) {
                    angles.Add(270);
                } else {
                    angles.Add(90);
                }
                continue;
            }
            double a = Math.Atan(dy / dx) * 180 / Math.PI;
            if (dx > 0) {
                if (dy < 0) {
                    a += 360;
                }
            } else {
                a += 180;
            }
            angles.Add(a);
        }
        angles.Sort();
        int n = angles.Count, r = 0;
        if (n <= 1) {
            return n + overlap;
        }
        for (int l = 0; l < n;) {
            if (r == l) {
                r = (r + 1) % n;
            }
            while (r > l && angles[r] <= angles[l] + angle || r < l && angles[r] <= angles[l] + angle - 360) {
                r = (r + 1) % n;
            }
            if (l == r) {
                return n + overlap;
            } else if (l < r) {
                ret = Math.Max(ret, r - l);
            } else {
                ret = Math.Max(ret, r + n - l);
            }
            int nl = l + 1;
            while (nl < n && angles[nl] == angles[l]) {
                ++nl;
            }
            l = nl;
        }
        return ret + overlap;
    }
}
// @lc code=end

