/*
 * @lc app=leetcode id=1515 lang=csharp
 *
 * [1515] Best Position for a Service Centre
 */

using System;

// @lc code=start
public class Solution {

    private static double GetValue(int[][] positions, double x, double y) {
        double ret = 0;
        foreach (var p in positions) {
            ret += Math.Sqrt(Math.Pow(x - p[0], 2) + Math.Pow(y - p[1], 2));
        }
        return ret;
    }

    public double GetMinDistSum(int[][] positions) {
        double x = 0.5, y = 0.5, ret = GetValue(positions, x, y);
        while (true) {
            double dx = 0, dy = 0;
            foreach (var p in positions) {
                var denom = Math.Sqrt(Math.Pow(x - p[0], 2) + Math.Pow(y - p[1], 2));
                dx += (double)(x - p[0]) / denom;
                dy += (double)(y - p[1]) / denom;
            }
            double b = 1.0, t = dx * dx + dy * dy;
            while (true) {
                double l = GetValue(positions, x - b * dx, y - b * dy) - ret, r = -0.5 * b * t;
                if (l <= r) {
                    break;
                }
                b *= 0.8;
            }
            double nx = x - dx * b, ny = y - dy * b, nret = GetValue(positions, nx, ny);
            if (nret >= ret - 0.00000001) {
                break;
            }
            ret = nret;
            x = nx;
            y = ny;
        }
        return ret;
    }
}
// @lc code=end

