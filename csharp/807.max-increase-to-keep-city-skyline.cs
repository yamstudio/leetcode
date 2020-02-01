/*
 * @lc app=leetcode id=807 lang=csharp
 *
 * [807] Max Increase to Keep City Skyline
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MaxIncreaseKeepingSkyline(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        int[] row = new int[m], col = new int[n];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                int h = grid[i][j];
                row[i] = Math.Max(row[i], h);
                col[j] = Math.Max(col[j], h);
            }
        }
        return grid.SelectMany((r, i) => r.Select((h, j) => Math.Min(row[i], col[j]) - h)).Sum();
    }
}
// @lc code=end

