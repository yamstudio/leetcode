/*
 * @lc app=leetcode id=1499 lang=csharp
 *
 * [1499] Max Value of Equation
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int FindMaxValueOfEquation(int[][] points, int k) {
        var list = new LinkedList<int[]>();
        int ret = int.MinValue;
        foreach (var p in points) {
            while (list.Count > 0 && list.First.Value[0] < p[0] - k) {
                list.RemoveFirst();
            }
            if (list.Count > 0) {
                ret = Math.Max(ret, p[1] + list.First.Value[1] + p[0] - list.First.Value[0]);
                int diff = p[1] - p[0];
                while (list.Count > 0 && list.Last.Value[1] - list.Last.Value[0] < diff) {
                    list.RemoveLast();
                }
            }
            list.AddLast(p);
        }
        return ret;
    }
}
// @lc code=end

