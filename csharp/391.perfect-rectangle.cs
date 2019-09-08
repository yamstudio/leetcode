/*
 * @lc app=leetcode id=391 lang=csharp
 *
 * [391] Perfect Rectangle
 */

using System.Collections.Generic;

public class Solution {
    private static readonly int BOTTOM_LEFT = 0b1, BOTTOM_RIGHT = 0b10, TOP_LEFT = 0b100, TOP_RIGHT = 0b1000;
    
    private static bool Register(IDictionary<(int, int), int> map, int x, int y, int type) {
        var key = (x, y);
        int curr = map.ContainsKey(key) ? map[key] : 0;
        if ((curr & type) != 0) {
            return false;
        }
        map[key] = type | curr;
        return true;
    }

    public bool IsRectangleCover(int[][] rectangles) {
        int minX = int.MaxValue, minY = int.MaxValue, maxX = int.MinValue, maxY = int.MinValue, area = 0;
        IDictionary<(int, int), int> map = new Dictionary<(int, int), int>(4 * rectangles.Length);
        foreach (int[] rectangle in rectangles) {
            int left = rectangle[0], right = rectangle[2], bottom = rectangle[1], top = rectangle[3];
            area += (right - left) * (top - bottom);
            minX = Math.Min(left, minX);
            maxX = Math.Max(right, maxX);
            minY = Math.Min(bottom, minY);
            maxY = Math.Max(top, maxY);
            if (!Register(map, left, bottom, BOTTOM_LEFT)) {
                return false;
            }
            if (!Register(map, right, bottom, BOTTOM_RIGHT)) {
                return false;
            }
            if (!Register(map, left, top, TOP_LEFT)) {
                return false;
            }
            if (!Register(map, right, top, TOP_RIGHT)) {
                return false;
            }
        }
        int singles = 0;
        foreach (int curr in map.Values) {
            if (curr == BOTTOM_LEFT || curr == BOTTOM_RIGHT || curr == TOP_LEFT || curr == TOP_RIGHT) {
                ++singles;
            }
        }
        return singles == 4 && area == (maxX - minX) * (maxY - minY);
    }
}

