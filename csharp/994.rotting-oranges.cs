/*
 * @lc app=leetcode id=994 lang=csharp
 *
 * [994] Rotting Oranges
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static readonly (int X, int Y)[] Dirs = new (int X, int Y)[] {
        (X: -1, Y: 0),
        (X: 1, Y: 0),
        (X: 0, Y: -1),
        (X: 0, Y: 1)
    };

    public int OrangesRotting(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, count = 0, min = 0;
        var visited = new HashSet<(int X, int Y)>();
        var queue = new Queue<(int X, int Y)>();
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (grid[i][j] == 2) {
                    queue.Enqueue((X: i, Y: j));
                } else if (grid[i][j] == 1) {
                    ++count;
                }
            }
        }
        if (count == 0) {
            return 0;
        }
        while (queue.Count > 0) {
            for (int i = queue.Count; i > 0; --i) {
                var curr = queue.Dequeue();
                foreach (var dir in Dirs) {
                    int nx = curr.X + dir.X, ny = curr.Y + dir.Y;
                    if (nx < 0 || nx >= m || ny < 0 || ny >= n || grid[nx][ny] != 1) {
                        continue;
                    }
                    var key = (X: nx, Y: ny);
                    if (visited.Contains(key)) {
                        continue;
                    }
                    visited.Add(key);
                    queue.Enqueue(key);
                }
            }
            ++min;
            if (visited.Count == count) {
                return min;
            }
        }
        return visited.Count == count ? min : -1;
    }
}
// @lc code=end

