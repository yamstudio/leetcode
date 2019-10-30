/*
 * @lc app=leetcode id=593 lang=csharp
 *
 * [593] Valid Square
 */

using System.Linq;

// @lc code=start
public class Solution {
    public bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4) {
        var p = new int[][] {
            p1, p2, p3, p4,
        };
        var s = Enumerable.Range(0, 3).SelectMany(i => Enumerable.Range(i + 1, 4 - i - 1).Select(j => (p[i][0] - p[j][0]) * (p[i][0] - p[j][0]) + (p[i][1] - p[j][1]) * (p[i][1] - p[j][1]))).Distinct().ToList();
        return s.Count == 2 && !s.Contains(0);
    }
}
// @lc code=end

