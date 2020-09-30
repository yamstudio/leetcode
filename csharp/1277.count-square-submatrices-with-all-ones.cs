/*
 * @lc app=leetcode id=1277 lang=csharp
 *
 * [1277] Count Square Submatrices with All Ones
 */

using System;

// @lc code=start
public class Solution {
    public int CountSquares(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length, ret = 0;
        int[,] udp = new int[2, n + 1], ddp = new int[2, n + 1];
        for (int i = 0; i < m; ++i) {
            int c = i % 2, p = 1 - c, l = 0;
            for (int j = 1; j <= n; ++j) {
                if (matrix[i][j - 1] == 0) {
                    udp[c, j] = 0;
                    l = 0;
                    ddp[c, j] = 0;
                    continue;
                }
                ++l;
                udp[c, j] = udp[p, j] + 1;
                ddp[c, j] = Math.Min(l, Math.Min(udp[c, j], ddp[p, j - 1] + 1));
                ret += ddp[c, j];
            }
        }
        return ret;
    }
}
// @lc code=end

