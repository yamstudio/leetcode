/*
 * @lc app=leetcode id=827 lang=csharp
 *
 * [827] Making A Large Island
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static int[] GetIsland(int[,][] map, int m, int n, int i, int j) {
        if (i < 0 || i >= m || j < 0 || j >= n) {
            return null;
        }
        return map[i, j];
    }

    private static IEnumerable<int[]> GetIslands(int[,][] map, int m, int n, int i, int j) {
        yield return GetIsland(map, m, n, i - 1, j);
        yield return GetIsland(map, m, n, i + 1, j);
        yield return GetIsland(map, m, n, i, j - 1);
        yield return GetIsland(map, m, n, i, j + 1);
    }

    private static void BuildIsland(int[][] grid, int m, int n, int i, int j, int[] island, int[,][] map) {
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] <= 0) {
            return;
        }
        ++island[0];
        grid[i][j] = -1;
        map[i, j] = island;
        BuildIsland(grid, m, n, i - 1, j, island, map);
        BuildIsland(grid, m, n, i + 1, j, island, map);
        BuildIsland(grid, m, n, i, j - 1, island, map);
        BuildIsland(grid, m, n, i, j + 1, island, map);
    }

    public int LargestIsland(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, single = 0;
        var map = new int[m, n][];
        var zeros = new List<(int X, int Y)>();
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 0) {
                    zeros.Add((X: i, Y: j));
                    continue;
                }
                if (grid[i][j] == -1) {
                    continue;
                }
                int[] island = new int[] { 0 };
                BuildIsland(grid, m, n, i, j, island, map);
                single = Math.Max(single, island[0]);
            }
        }
        return zeros
            .Select(zero => 
                1 + GetIslands(map, m, n, zero.X, zero.Y)
                    .Distinct()
                    .Select(island => island == null ? 0 : island[0])
                    .Sum())
            .Append(single)
            .Max();
    }
}
// @lc code=end

