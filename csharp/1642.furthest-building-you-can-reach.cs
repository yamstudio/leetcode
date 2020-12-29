/*
 * @lc app=leetcode id=1642 lang=csharp
 *
 * [1642] Furthest Building You Can Reach
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int FurthestBuilding(int[] heights, int bricks, int ladders) {
        var sorted = new SortedSet<(int Height, int Index)>();
        int n = heights.Length;
        for (int i = 0; i < n - 1; ++i) {
            if (heights[i] >= heights[i + 1]) {
                continue;
            }
            sorted.Add((Height: heights[i + 1] - heights[i], Index: i));
            while (sorted.Count > ladders) {
                bricks -= sorted.Min.Height;
                sorted.Remove(sorted.Min);
            }
            if (bricks < 0) {
                return i;
            }
        }
        return n - 1;
    }
}
// @lc code=end

