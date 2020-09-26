/*
 * @lc app=leetcode id=1260 lang=csharp
 *
 * [1260] Shift 2D Grid
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<IList<int>> ShiftGrid(int[][] grid, int k) {
        int m = grid.Length, n = grid[0].Length, t = m * n;
        return Enumerable
            .Range((t - k % t) % t, t)
            .Select((int x, int i) => (Index: i, Value: grid[(x / n) % m][x % n]))
            .GroupBy(t => t.Index / n, (int key, IEnumerable<(int Index, int Value)> all) => all.Select(t => t.Value).ToArray())
            .ToArray();
    }
}
// @lc code=end

