/*
 * @lc app=leetcode id=695 lang=csharp
 *
 * [695] Max Area of Island
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    
    private static readonly int[][] Dirs = new int[][] {
        new int[] { 0, -1, },
        new int[] { 0, 1, },
        new int[] { -1, 0, },
        new int[] { 1, 0, },
    };

    public int MaxAreaOfIsland(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, ret = 0;
        Queue<(int, int)> queue = new Queue<(int, int)>();
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] != 1) {
                    continue;
                }
                int curr = 0;
                grid[i][j] = -1;
                queue.Enqueue((i, j));
                while (queue.Count > 0) {
                    ++curr;
                    var l = queue.Dequeue();
                    foreach (var dir in Dirs) {
                        int nr = l.Item1 + dir[0], nc = l.Item2 + dir[1];
                        if (nr < 0 || nr >= m || nc < 0 || nc >= n || grid[nr][nc] != 1) {
                            continue;
                        }
                        grid[nr][nc] = -1;
                        queue.Enqueue((nr, nc));
                    }
                }
                ret = Math.Max(ret, curr);
            }
        }
        return ret;
    }
}
// @lc code=end

