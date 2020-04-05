/*
 * @lc app=leetcode id=850 lang=csharp
 *
 * [850] Rectangle Area II
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static void AddRectangleRecurse(IList<int[]> split, int[] rectangle, int index) {
        if (index >= split.Count) {
            split.Add(rectangle);
            return;
        }
        var curr = split[index];
        if (rectangle[0] >= curr[2] ||
            rectangle[2] <= curr[0] ||
            rectangle[1] >= curr[3] ||
            rectangle[3] <= curr[1]) {
            AddRectangleRecurse(split, rectangle, index + 1);
            return;
        }

        if (rectangle[0] < curr[0]) {
            AddRectangleRecurse(split, new int[] {
                rectangle[0], rectangle[1], curr[0], rectangle[3]
            }, index + 1);
        }

        if (rectangle[2] > curr[2]) {
            AddRectangleRecurse(split, new int[] {
                curr[2], rectangle[1], rectangle[2], rectangle[3]
            }, index + 1);
        }

        if (rectangle[1] < curr[1]) {
            AddRectangleRecurse(split, new int[] {
                Math.Max(rectangle[0], curr[0]),
                rectangle[1], 
                Math.Min(rectangle[2], curr[2]),
                curr[1]
            }, index + 1);
        }

        if (rectangle[3] > curr[3]) {
            AddRectangleRecurse(split, new int[] {
                Math.Max(rectangle[0], curr[0]),
                curr[3], 
                Math.Min(rectangle[2], curr[2]),
                rectangle[3]
            }, index + 1);
        }
    }

    public int RectangleArea(int[][] rectangles) {
        var split = new List<int[]>();
        foreach (var rectangle in rectangles) {
            AddRectangleRecurse(split, rectangle, 0);
        }
        return split.Aggregate((long)0, (acc, rectangle) => (acc + (((long)rectangle[2] - (long)rectangle[0]) * ((long)rectangle[3] - (long)rectangle[1])) % 1000000007) % 1000000007, acc => (int)acc);
    }
}
// @lc code=end

