/*
 * @lc app=leetcode id=861 lang=csharp
 *
 * [861] Score After Flipping Matrix
 */

using System;

// @lc code=start
public class Solution {
    public int MatrixScore(int[][] A) {
        int m = A.Length, n = A[0].Length, ret = m * (1 << (n - 1));
        for (int i = 1; i < n; ++i) {
            int flips = 0;
            for (int j = 0; j < m; ++j) {
                if (A[j][0] != A[j][i]) {
                    ++flips;
                }
            }
            ret += Math.Max(flips, m - flips) * (1 << (n - 1 - i));
        }
        return ret;
    }
}
// @lc code=end

