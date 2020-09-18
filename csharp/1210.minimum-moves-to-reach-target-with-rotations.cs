/*
 * @lc app=leetcode id=1210 lang=csharp
 *
 * [1210] Minimum Moves to Reach Target with Rotations
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static bool IsOkay(int[][] grid, int n, (int R, int C, bool IsHorizontal) curr) {
        return (curr.IsHorizontal && curr.R >= 0 && curr.R < n && curr.C >= 0 && curr.C < n - 1 && grid[curr.R][curr.C] == 0 && grid[curr.R][curr.C + 1] == 0) || (!curr.IsHorizontal && curr.R >= 0 && curr.R < n - 1 && curr.C >= 0 && curr.C < n && grid[curr.R][curr.C] == 0 && grid[curr.R + 1][curr.C] == 0);
    }

    private static void TryAdd(Queue<(int R, int C, bool IsHorizontal)> queue, HashSet<(int R, int C, bool IsHorizontal)> visited, (int R, int C, bool IsHorizontal) curr) {
        if (visited.Add(curr)) {
            queue.Enqueue(curr);
        }
    }

    public int MinimumMoves(int[][] grid) {
        var queue = new Queue<(int R, int C, bool IsHorizontal)>();
        var visited = new HashSet<(int R, int C, bool IsHorizontal)>();
        int steps = 0, n = grid.Length;
        TryAdd(queue, visited, (R: 0, C: 0, IsHorizontal: true));
        while (queue.Count > 0) {
            for (int i = queue.Count; i > 0; --i) {
                var curr = queue.Dequeue();
                if (curr.R == n - 1 && curr.C == n - 2 && curr.IsHorizontal) {
                    return steps;
                }
                var vertical = (R: curr.R + 1, C: curr.C, IsHorizontal: curr.IsHorizontal);
                if (IsOkay(grid, n, vertical)) {
                    TryAdd(queue, visited, vertical);
                }
                var horizontal = (R: curr.R, C: curr.C + 1, IsHorizontal: curr.IsHorizontal);
                if (IsOkay(grid, n, horizontal)) {
                    TryAdd(queue, visited, horizontal);
                }
                if (curr.IsHorizontal && IsOkay(grid, n, (R: curr.R + 1, C: curr.C, IsHorizontal: curr.IsHorizontal))) {
                    TryAdd(queue, visited, (R: curr.R, C: curr.C, IsHorizontal: false));
                }
                if (!curr.IsHorizontal && IsOkay(grid, n, (R: curr.R, C: curr.C + 1, IsHorizontal: curr.IsHorizontal))) {
                    TryAdd(queue, visited, (R: curr.R, C: curr.C, IsHorizontal: true));
                }
            }
            ++steps;
        }
        return -1;
    }
}
// @lc code=end

