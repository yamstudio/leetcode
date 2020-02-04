/*
 * @lc app=leetcode id=812 lang=csharp
 *
 * [812] Largest Triangle Area
 */

 using System;

// @lc code=start
public class Solution {
    public double LargestTriangleArea(int[][] points) {
        double ret = 0;
        int n = points.Length;
        for (int i = 0; i < n - 2; ++i) {
            int x1 = points[i][0], y1 = points[i][1];
            for (int j = i + 1; j < n - 1; ++j) {
                int x2 = points[j][0], y2 = points[j][1];
                for (int k = j + 1; k < n; ++k) {
                    int x3 = points[k][0], y3 = points[k][1];
                    ret = Math.Max(ret, Math.Abs(x1 * y2 + x2 * y3 + x3 * y1 - x2 * y1 - x3 * y2 - x1 * y3));
                }
            }
        }
        return 0.5 * ret;
    }
}
// @lc code=end

