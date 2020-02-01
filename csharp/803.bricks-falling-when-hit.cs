/*
 * @lc app=leetcode id=803 lang=csharp
 *
 * [803] Bricks Falling When Hit
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    private static void AddBrickRecurse(int[][] grid, int m, int n, int i, int j, HashSet<(int R, int C)> bricks) {
        var key = (R: i, C: j);
        if (i < 0 || i >= m || j < 0 || j >= n || grid[i][j] != 1 || bricks.Contains(key)) {
            return;
        }
        bricks.Add(key);
        AddBrickRecurse(grid, m, n, i - 1, j, bricks);
        AddBrickRecurse(grid, m, n, i + 1, j, bricks);
        AddBrickRecurse(grid, m, n, i, j - 1, bricks);
        AddBrickRecurse(grid, m, n, i, j + 1, bricks);
    }
    
    public int[] HitBricks(int[][] grid, int[][] hits) {
        int m = grid.Length, n = grid[0].Length, l = hits.Length;
        int[] ret = new int[l];
        var bricks = new HashSet<(int R, int C)>();
        foreach (var hit in hits) {
            --grid[hit[0]][hit[1]];
        }
        for (int j = 0; j < n; ++j) {
            AddBrickRecurse(grid, m, n, 0, j, bricks);
        }
        for (int k = l - 1; k >= 0; --k) {
            var hit = hits[k];
            int i = hit[0], j = hit[1];
            ++grid[i][j];
            if (grid[i][j] < 1) {
                continue;
            }
            if (i == 0 ||
                bricks.Contains((R: i - 1, C: j)) ||
                bricks.Contains((R: i + 1, C: j)) ||
                bricks.Contains((R: i, C: j - 1)) ||
                bricks.Contains((R: i, C: j + 1))) {
                int count = bricks.Count;
                AddBrickRecurse(grid, m, n, i, j, bricks);
                ret[k] = bricks.Count - count - 1;
            }
        }
        return ret;
    }
}
// @lc code=end

