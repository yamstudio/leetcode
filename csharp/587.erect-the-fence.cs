/*
 * @lc app=leetcode id=587 lang=csharp
 *
 * [587] Erect the Fence
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int GetConvexity(int[] a, int[] b, int[] c) {
        int v00 = b[0] - a[0], v01 = b[1] - a[1], v10 = c[0] - a[0], v11 = c[1] - a[1];
        return v00 * v11 - v01 * v10;
    }


    private static IList<int[]> SortPoints(int n, int[][] points) {
        var origin = points[0];
        int o = 0;
        for (int i = 1; i < n; ++i) {
            var curr = points[i];
            if (curr[1] < origin[1] || (curr[1] == origin[1] && curr[0] < origin[0])) {
                o = i;
                origin = curr;
            }
        }
        points[o] = points[0];
        points[0] = origin;
        Array.Sort(points, 1, n - 1, Comparer<int[]>.Create((int[] a, int[] b) => {
            var conv = GetConvexity(b, a, origin);
            if (conv != 0) {
                return conv;
            }
            return (Math.Abs(a[0] - origin[0]) + Math.Abs(a[1] - origin[1])).CompareTo(Math.Abs(b[0] - origin[0]) + Math.Abs(b[1] - origin[1]));
        }));
        var ret = new List<int[]>(n);
        o = n - 1;
        while (o > 0 && GetConvexity(origin, points[o], points[o - 1]) == 0)
            --o;
        for (int i = 0; i < o; ++i) {
            ret.Add(points[i]);
        }
        for (int i = n - 1; i >= o; --i) {
            ret.Add(points[i]);
        }
        return ret;
    }

    public int[][] OuterTrees(int[][] points) {
        int n = points.Length;
        if (n <= 3) {
            return points;
        }
        IList<int[]> ret = new List<int[]>();
        var pts = SortPoints(n, points);
        ret.Add(pts[0]);
        ret.Add(pts[1]);
        for (int i = 2; i < n; ++i) {
            var curr = pts[i];
            while (ret.Count > 1 && GetConvexity(ret[ret.Count - 2], ret[ret.Count - 1], curr) < 0)
                ret.RemoveAt(ret.Count - 1);
            ret.Add(curr);
        }

        return ret.ToArray();
    }
}
// @lc code=end

