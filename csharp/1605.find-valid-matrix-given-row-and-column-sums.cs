/*
 * @lc app=leetcode id=1605 lang=csharp
 *
 * [1605] Find Valid Matrix Given Row and Column Sums
 */

using System;

// @lc code=start
public class Solution {
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum) {
        int m = rowSum.Length, n = colSum.Length;
        var ret = new int[m][];
        for (int i = 0; i < m; ++i) {
            var row = new int[n];
            for (int j = 0; j < n; ++j) {
                row[j] = Math.Min(rowSum[i], colSum[j]);
                rowSum[i] -= row[j];
                colSum[j] -= row[j];
            }
            ret[i] = row;
        }
        return ret;
    }
}
// @lc code=end

