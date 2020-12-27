/*
 * @lc app=leetcode id=1631 lang=csharp
 *
 * [1631] Path With Minimum Effort
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static (int R, int C)[] Dirs = new (int R, int C)[] {
        (R: -1, C: 0),
        (R: 1, C: 0),
        (R: 0, C: -1),
        (R: 0, C: 1)
    };

    public int MinimumEffortPath(int[][] heights) {
        int m = heights.Length, n = heights[0].Length;
        var efforts = new int[m, n];
        var sorted = new SortedSet<(int Effort, int R, int C)>(Comparer<(int Effort, int R, int C)>.Create((a, b) => {
            if (a.Effort != b.Effort) {
                return a.Effort.CompareTo(b.Effort);
            }
            if (a.R != b.R) {
                return a.R.CompareTo(b.R);
            }
            return a.C.CompareTo(b.C);
        }));
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                efforts[i, j] = int.MaxValue;
            }
        }
        efforts[0, 0] = 0;
        sorted.Add((Effort: 0, R: 0, C: 0));
        while (sorted.Count > 0) {
            var curr = sorted.Min;
            sorted.Remove(curr);
            if (curr.Effort > efforts[curr.R, curr.C]) {
                continue;
            }
            if (curr.R == m - 1 && curr.C == n - 1) {
                return curr.Effort;
            }
            foreach (var dir in Dirs) {
                int nr = curr.R + dir.R, nc = curr.C + dir.C;
                if (nr < 0 || nr >= m || nc < 0 || nc >= n) {
                    continue;
                }
                int nd = Math.Max(curr.Effort, Math.Abs(heights[curr.R][curr.C] - heights[nr][nc]));
                if (nd < efforts[nr, nc]) {
                    efforts[nr, nc] = nd;
                    sorted.Add((Efforts: nd, R: nr, C: nc));
                }
            }
        }
        return -1;
    }
}
// @lc code=end

