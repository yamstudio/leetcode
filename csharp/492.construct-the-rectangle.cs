/*
 * @lc app=leetcode id=492 lang=csharp
 *
 * [492] Construct the Rectangle
 */

using System;

// @lc code=start
public class Solution {
    public int[] ConstructRectangle(int area) {
        int w = (int) Math.Sqrt(area);
        while (true) {
            if (area % w == 0) {
                return new int[] { area / w, w };
            }
            --w;
        }
    }
}
// @lc code=end

