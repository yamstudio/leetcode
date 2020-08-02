/*
 * @lc app=leetcode id=986 lang=csharp
 *
 * [986] Interval List Intersections
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int[][] IntervalIntersection(int[][] A, int[][] B) {
        var ret = new List<int[]>();
        int m = A.Length, n = B.Length, i = 0, j = 0;
        while (i < m && j < n) {
            int[] a = A[i], b = B[j];
            if (a[1] < b[0]) {
                ++i;
                continue;
            }
            if (a[1] <= b[1]) {
                ret.Add(new int[] { Math.Max(a[0], b[0]), a[1] });
                ++i;
                continue;
            }
            if (a[0] > b[1]) {
                ++j;
                continue;
            }
            ret.Add(new int[] { Math.Max(a[0], b[0]), b[1] });
            ++j;
        }
        return ret.ToArray();
    }
}
// @lc code=end

