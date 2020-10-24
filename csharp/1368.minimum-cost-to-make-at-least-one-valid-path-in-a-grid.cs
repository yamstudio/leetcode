/*
 * @lc app=leetcode id=1368 lang=csharp
 *
 * [1368] Minimum Cost to Make at Least One Valid Path in a Grid
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static (int DR, int DC)[] Dirs = new (int DR, int DC)[] {
        (DR: 0, DC: 1),
        (DR: 0, DC: -1),
        (DR: 1, DC: 0),
        (DR: -1, DC: 0),
    };

    private static void MinCost(int m, int n, int x, int y, int c, int[][] grid, int[,] cost, Queue<(int R, int C)> queue) {
        while (x >= 0 && x < m && y >= 0 && y < n && cost[x, y] == 0) {
            cost[x, y] = c;
            var dir = Dirs[grid[x][y] - 1];
            queue.Enqueue((R: x, C: y));
            x += dir.DR;
            y += dir.DC;
        }
    }

    public int MinCost(int[][] grid) {
        int m = grid.Length, n = grid[0].Length, c = 1;
        int[,] cost = new int[m, n];
        var queue = new Queue<(int R, int C)>();
        MinCost(m, n, 0, 0, c, grid, cost, queue);
        while (queue.Count > 0 && cost[m - 1, n - 1] == 0) {
            ++c;
            for (int i = queue.Count; i > 0; --i) {
                var curr = queue.Dequeue();
                foreach (var dir in Dirs) {
                    MinCost(m, n, curr.R + dir.DR, curr.C + dir.DC, c,  grid, cost, queue);
                }
            }
        }
        return cost[m - 1, n - 1] - 1;
    }
}
// @lc code=end

