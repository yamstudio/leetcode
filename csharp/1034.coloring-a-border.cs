/*
 * @lc app=leetcode id=1034 lang=csharp
 *
 * [1034] Coloring A Border
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static (int DR, int DC)[] Dirs = new (int DR, int DC)[] {
        (DR: -1, DC: 0),
        (DR: 1, DC: 0),
        (DR: 0, DC: -1),
        (DR: 0, DC: 1)
    };

    public int[][] ColorBorder(int[][] grid, int r0, int c0, int color) {
        int m = grid.Length, n = grid[0].Length, source = grid[r0][c0];
        var visited = new HashSet<(int R, int C)>();
        var border = new HashSet<(int R, int C)>();
        var queue = new Queue<(int R, int C)>();
        visited.Add((R: r0, C: c0));
        queue.Enqueue((R: r0, C: c0));
        while (queue.TryDequeue(out var curr)) {
            bool isBorder = false;
            foreach (var dir in Dirs) {
                int nr = curr.R + dir.DR, nc = curr.C + dir.DC;
                if (nr < 0 || nr >= m || nc < 0 || nc >= n || grid[nr][nc] != source) {
                    isBorder = true;
                    continue;
                }
                var key = (R: nr, C: nc);
                if (!visited.Add(key)) {
                    continue;
                }
                queue.Enqueue(key);
            }
            if (isBorder) {
                border.Add(curr);
            }
        }
        foreach (var curr in border) {
            grid[curr.R][curr.C] = color;
        }
        return grid;
    }
}
// @lc code=end

