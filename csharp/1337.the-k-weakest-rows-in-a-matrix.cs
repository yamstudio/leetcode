/*
 * @lc app=leetcode id=1337 lang=csharp
 *
 * [1337] The K Weakest Rows in a Matrix
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[] KWeakestRows(int[][] mat, int k) {
        return mat
            .Select((r, i) => (Index: i, Strength: r.TakeWhile(x => x == 1).Count()))
            .OrderBy(t => t.Strength)
            .ThenBy(t => t.Index)
            .Take(k)
            .Select(t => t.Index)
            .ToArray();
    }
}
// @lc code=end

