/*
 * @lc app=leetcode id=980 lang=csharp
 *
 * [980] Unique Paths III
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int UniquePathsRecurse(int[][] grid, int m, int n, int i, int j, int count, HashSet<(int Row, int Col)> visited) {
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] == -1) {
            return 0;
        }
        if (grid[i][j] == 2) {
            if (visited.Count == count) {
                return 1;
            }
            return 0;
        }
        var key = (Row: i, Col: j);
        if (visited.Contains(key)) {
            return 0;
        }
        visited.Add(key);
        int ret = UniquePathsRecurse(grid, m, n, i - 1, j, count, visited) + UniquePathsRecurse(grid, m, n, i + 1, j, count, visited) + UniquePathsRecurse(grid, m, n, i, j - 1, count, visited) + UniquePathsRecurse(grid, m, n, i, j + 1, count, visited);
        visited.Remove(key);
        return ret;
    }

    public int UniquePathsIII(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, si = -1, sj = -1, count = 1;
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 1) {
                    si = i;
                    sj = j;
                } else if (grid[i][j] == 0) {
                    ++count;
                }
            }
        }
        return UniquePathsRecurse(grid, m, n, si, sj, count, new HashSet<(int Row, int Col)>());
    }
}
// @lc code=end

