/*
 * @lc app=leetcode id=835 lang=csharp
 *
 * [835] Image Overlap
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static IEnumerable<(int X, int Y)> GetOnes(int[][] arr) {
        return arr
            .SelectMany(
                (row, i) => row.Select((d, j) => (Val: d, Y: j)).Where(tuple => tuple.Val == 1).Select(tuple => (X: i, Y: tuple.Y)));
    }

    public int LargestOverlap(int[][] A, int[][] B) {
        var map = new Dictionary<(int DX, int DY), int>();
        var aOnes = GetOnes(A).ToArray();
        foreach (var b in GetOnes(B)) {
            foreach (var a in aOnes) {
                var key = (DX: a.X - b.X, DY: a.Y - b.Y);
                if (map.TryGetValue(key, out int val)) {
                    map[key] = val + 1;
                } else {
                    map[key] = 1;
                }
            }
        }
        return map.Values.DefaultIfEmpty(0).Max();
    }
}
// @lc code=end

