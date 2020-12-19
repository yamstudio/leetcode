/*
 * @lc app=leetcode id=1591 lang=csharp
 *
 * [1591] Strange Printer II
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static bool HasCycle(int i, HashSet<int>[] deps, bool?[] visited) {
        visited[i] = false;
        foreach (int j in deps[i]) {
            if (visited[j].HasValue) {
                if (visited[j].Value) {
                    continue;
                }
                return true;
            }
            if (HasCycle(j, deps, visited)) {
                return true;
            }
        }
        visited[i] = true;
        return false;
    }

    public bool IsPrintable(int[][] targetGrid) {
        int m = targetGrid.Length, n = targetGrid[0].Length;
        int[][] boundaries = new int[61][];
        var deps = new HashSet<int>[61];
        var visited = new bool?[61];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                int c = targetGrid[i][j];
                if (boundaries[c] == null) {
                    boundaries[c] = new int[] { i, i, j, j };
                    continue;
                }
                boundaries[c][1] = i;
                boundaries[c][2] = Math.Min(boundaries[c][2], j);
                boundaries[c][3] = Math.Max(boundaries[c][3], j);
            }
        }
        for (int c = 1; c <= 60; ++c) {
            var boundary = boundaries[c];
            if (boundary == null) {
                continue;
            }
            var set = new HashSet<int>();
            for (int i = boundary[0]; i <= boundary[1]; ++i) {
                for (int j = boundary[2]; j <= boundary[3]; ++j) {
                    if (targetGrid[i][j] != c) {
                        set.Add(targetGrid[i][j]);
                    }
                }
            }
            deps[c] = set;
        }
        for (int c = 1; c <= 60; ++c) {
            if (deps[c] == null || visited[c].HasValue) {
                continue;
            }
            if (HasCycle(c, deps, visited)) {
                return false;
            }
        }
        return true;
    }
}
// @lc code=end

