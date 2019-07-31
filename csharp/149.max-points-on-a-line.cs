/*
 * @lc app=leetcode id=149 lang=csharp
 *
 * [149] Max Points on a Line
 */

using System.Collections.Generic;

public class Solution {

    private static int GetGCD(int x, int y) {
        return y == 0 ? x : GetGCD(y, x % y);
    }

    public int MaxPoints(int[][] points) {
        int ret = 0;
        var map = new Dictionary<(int, int), int>();
        for (int i = 0; i < points.Length; ++i) {
            int count = 0;
            int[] point = points[i];
            for (int j = i; j < points.Length; ++j) {
                int[] curr = points[j];
                if (curr[0] == point[0] && curr[1] == point[1]) {
                    ++count;
                    continue;
                }
                int dx = curr[0] - point[0], dy = curr[1] - point[1];
                int gcd = GetGCD(dx, dy);
                var key = (dx / gcd, dy / gcd);
                map[key] = map.ContainsKey(key) ? map[key] + 1 : 1;
            }
            foreach (var pair in map) {
                ret = Math.Max(ret, pair.Value + count);
            }
            ret = Math.Max(ret, count);
            map.Clear();
        }
        return ret;
    }
}

