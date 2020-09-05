/*
 * @lc app=leetcode id=1131 lang=csharp
 *
 * [1131] Maximum of Absolute Value Expression
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {

    private static int MaxAbsValExpr(int[,] sums, int row, int n) {
        int max = sums[row, 0], min = max;
        for (int i = 1; i < n; ++i) {
            max = Math.Max(max, sums[row, i]);
            min = Math.Min(min, sums[row, i]);
        }
        return max - min;
    }

    public int MaxAbsValExpr(int[] arr1, int[] arr2) {
        int n = arr1.Length;
        int[,] sums = new int[4, n];
        for (int i = 0; i < n; ++i) {
            int x = arr1[i], y = arr2[i];
            sums[0, i] = x - y + i;
            sums[1, i] = x - y - i;
            sums[2, i] = x + y + i;
            sums[3, i] = x + y - i;
        }
        return Enumerable.Range(0, 4).Max(r => MaxAbsValExpr(sums, r, n));
    }
}
// @lc code=end

