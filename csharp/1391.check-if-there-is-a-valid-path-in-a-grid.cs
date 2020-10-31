/*
 * @lc app=leetcode id=1391 lang=csharp
 *
 * [1391] Check if There is a Valid Path in a Grid
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int[] Outbound = new int[] {
        0b0011,
        0b1100,
        0b1001,
        0b1010,
        0b0101,
        0b0110
    };

    private static int[] Inbound = new int[] {
        0b0011,
        0b1100,
        0b0110,
        0b0101,
        0b1010,
        0b1001
    };

    private static (int R, int C, int Key)[] Dirs = new (int R, int C, int Key)[] {
        (R: 0, C: -1, Key: 0b0001),
        (R: 0, C: 1, Key: 0b0010),
        (R: -1, C: 0, Key: 0b0100),
        (R: 1, C: 0, Key: 0b1000)
    };

    public bool HasValidPath(int[][] grid) {
        int m = grid.Length, n = grid[0].Length;
        var visited = new HashSet<(int R, int C)>();
        var queue = new Queue<(int R, int C)>();
        visited.Add((R: 0, C: 0));
        queue.Enqueue((R: 0, C: 0));
        while (queue.Count > 0) {
            var curr = queue.Dequeue();
            if (curr.R == m - 1 && curr.C == n - 1) {
                return true;
            }
            int key = Outbound[grid[curr.R][curr.C] - 1];
            foreach (var dir in Dirs) {
                if ((key & dir.Key) == 0) {
                    continue;
                }
                int nr = curr.R + dir.R, nc = curr.C + dir.C;
                if (nr >= 0 && nr < m && nc >= 0 && nc < n && (Inbound[grid[nr][nc] - 1] & dir.Key) != 0) {
                    var next = (R: nr, C: nc);
                    if (visited.Add(next)) {
                        queue.Enqueue(next);
                    }
                }
            }
        }
        return false;
    }
}
// @lc code=end

