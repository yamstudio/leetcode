/*
 * @lc app=leetcode id=54 lang=csharp
 *
 * [54] Spiral Matrix
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> SpiralOrder(int[][] matrix) {
        if (matrix.Length == 0) {
            return new List<int>();
        }
        int rows = matrix.Length, cols = matrix[0].Length, ml = Math.Min(rows, cols) / 2;
        IList<int> ret = new List<int>(rows * cols);
        for (int l = 0; l < ml; ++l) {
            int rmax = rows - l - 1, cmax = cols - l - 1;
            for (int i = l; i < cmax; ++i) {
                ret.Add(matrix[l][i]);
            }
            for (int i = l; i < rmax; ++i) {
                ret.Add(matrix[i][cmax]);
            }
            for (int i = cmax; i > l; --i) {
                ret.Add(matrix[rmax][i]);
            }
            for (int i = rmax; i > l; --i) {
                ret.Add(matrix[i][l]);
            }
        }
        if (rows > cols && cols % 2 == 1) {
            for (int i = ml; i < rows - ml; ++i) {
                ret.Add(matrix[i][ml]);
            }
        } else if (rows % 2 == 1) {
            for (int i = ml; i < cols - ml; ++i) {
                ret.Add(matrix[ml][i]);
            }
        }
        return ret;
    }
}

