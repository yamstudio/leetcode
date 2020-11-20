/*
 * @lc app=leetcode id=1465 lang=csharp
 *
 * [1465] Maximum Area of a Piece of Cake After Horizontal and Vertical Cuts
 */

using System;

// @lc code=start
public class Solution {
    public int MaxArea(int h, int w, int[] horizontalCuts, int[] verticalCuts) {
        int mh = 0, mw = 0, p = 0;
        Array.Sort(horizontalCuts);
        Array.Sort(verticalCuts);
        foreach (var c in horizontalCuts) {
            mh = Math.Max(mh, c - p);
            p = c;
        }
        mh = Math.Max(mh, h - horizontalCuts[horizontalCuts.Length - 1]);
        p = 0;
        foreach (var c in verticalCuts) {
            mw = Math.Max(mw, c - p);
            p = c;
        }
        mw = Math.Max(mw, w - verticalCuts[verticalCuts.Length - 1]);
        return (int)((((long)mh % 1000000007) * ((long)mw % 1000000007)) % 1000000007);
    }
}
// @lc code=end

