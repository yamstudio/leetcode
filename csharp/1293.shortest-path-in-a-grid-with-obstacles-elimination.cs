/*
 * @lc app=leetcode id=1293 lang=csharp
 *
 * [1293] Shortest Path in a Grid with Obstacles Elimination
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    
    private static (int R, int C)[] Dirs = new (int R, int C)[] {
        (R: -1, C: 0),
        (R: 1, C: 0),
        (R: 0, C: -1),
        (R: 0, C: 1)
    };
    
    public int ShortestPath(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length, ret = 0;
        var queue = new Queue<(int R, int C, int K)>();
        var visited = new HashSet<(int R, int C, int K)>();
        var curr = (R: 0, C: 0, K: k);
        queue.Enqueue(curr);
        visited.Add(curr);
        while (queue.Count > 0) {
            for (int i = queue.Count; i > 0; --i) {
                curr = queue.Dequeue();
                if (curr.R == m - 1 && curr.C == n - 1) {
                    return ret;
                }
                foreach (var dir in Dirs) {
                    int nr = dir.R + curr.R, nc = dir.C + curr.C;
                    if (nr < 0 || nr >= m || nc < 0 || nc >= n) {
                        continue;
                    }
                    (int R, int C, int K) next;
                    if (grid[nr][nc] == 0) {
                        next = (R: nr, C: nc, K: curr.K);
                    } else {
                        if (curr.K == 0) {
                            continue;
                        }
                        next = (R: nr, C: nc, K: curr.K - 1);
                    }
                    if (visited.Add(next)) {
                        queue.Enqueue(next);
                    }
                }
            }
            ++ret;
        }
        return -1;
    }
}
// @lc code=end

