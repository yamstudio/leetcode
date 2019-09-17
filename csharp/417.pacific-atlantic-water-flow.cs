/*
 * @lc app=leetcode id=417 lang=csharp
 *
 * [417] Pacific Atlantic Water Flow
 */

using System.Collections.Generic;
using System.Linq;

public class Solution {

    private void SearchRecurse(int[][] matrix, bool[,] flow, int prev, int i, int j, int m, int n) {
        if (i < 0 || i >= m || j < 0 || j >= n || flow[i, j]) {
            return;
        }
        int water = matrix[i][j];
        if (water < prev) {
            return;
        }
        flow[i, j] = true;
        SearchRecurse(matrix, flow, water, i - 1, j, m, n);
        SearchRecurse(matrix, flow, water, i + 1, j, m, n);
        SearchRecurse(matrix, flow, water, i, j - 1, m, n);
        SearchRecurse(matrix, flow, water, i, j + 1, m, n);
    }

    public IList<IList<int>> PacificAtlantic(int[][] matrix) {
        int m = matrix.Length, n;
        if (m == 0) {
            return new List<IList<int>>(0);
        }
        n = matrix[0].Length;
        bool[,] atlantic = new bool[m, n], pacific = new bool[m, n];
        for (int i = 0; i < m; ++i) {
            SearchRecurse(matrix, pacific, 0, i, 0, m, n);
            SearchRecurse(matrix, atlantic, 0, i, n - 1, m, n);
        }
        for (int j = 0; j < n; ++j) {
            SearchRecurse(matrix, pacific, 0, 0, j, m, n);
            SearchRecurse(matrix, atlantic, 0, m - 1, j, m, n);
        }
        return new List<IList<int>>(
            Enumerable.Range(0, m)
                .Select(i => Enumerable.Range(0, n)
                    .Where(j => pacific[i, j] && atlantic[i, j])
                    .Select(j => new List<int>(new int[] { i, j }))
                )
                .Aggregate((acc, list) => acc.Concat(list)));

    }
}

