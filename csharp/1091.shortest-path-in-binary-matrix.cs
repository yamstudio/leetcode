/*
 * @lc app=leetcode id=1091 lang=csharp
 *
 * [1091] Shortest Path in Binary Matrix
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int ShortestPathBinaryMatrix(int[][] grid) {
        var queue = new Queue<(int R, int C)>();
        int n = grid.Length, ret = 1;
        if (grid[0][0] != 0 || grid[n - 1][n - 1] != 0) {
            return -1;
        }
        grid[0][0] = 1;
        queue.Enqueue((R: 0, C: 0));
        while (queue.Count > 0) {
            for (int i = queue.Count; i > 0; --i) {
                var curr = queue.Dequeue();
                if (curr.R == n - 1 && curr.C == n - 1) {
                    return ret;
                }
                for (int dr = -1; dr <= 1; ++dr) {
                    int nr = curr.R + dr;
                    for (int dc = -1; dc <= 1; ++dc) {
                        int nc = curr.C + dc;
                        if (nr < 0 || nr >= n || nc < 0 || nc >= n || grid[nr][nc] == 1) {
                            continue;
                        }
                        grid[nr][nc] = 1;
                        queue.Enqueue((R: nr, C: nc));
                    }
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

