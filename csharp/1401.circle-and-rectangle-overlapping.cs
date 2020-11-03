/*
 * @lc app=leetcode id=1401 lang=csharp
 *
 * [1401] Circle and Rectangle Overlapping
 */

using System;

// @lc code=start
public class Solution {
    public bool CheckOverlap(int radius, int x_center, int y_center, int x1, int y1, int x2, int y2) {
        int cx = Math.Max(x1, Math.Min(x2, x_center)),
            cy = Math.Max(y1, Math.Min(y2, y_center)),
            dx = x_center - cx,
            dy = y_center - cy;
        return radius * radius >= dx * dx + dy * dy;
    }
}
// @lc code=end

