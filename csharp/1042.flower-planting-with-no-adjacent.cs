/*
 * @lc app=leetcode id=1042 lang=csharp
 *
 * [1042] Flower Planting With No Adjacent
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static HashSet<int> Colors = Enumerable.Range(1, 4).ToHashSet();

    public int[] GardenNoAdj(int N, int[][] paths) {
        var neighbors = new Dictionary<int, HashSet<int>>();
        var ret = new int[N];
        foreach (var path in paths) {
            int a = path[0], b = path[1];
            if (!neighbors.TryGetValue(a, out var na)) {
                na = new HashSet<int>();
                neighbors[a] = na;
            }
            if (!neighbors.TryGetValue(b, out var nb)) {
                nb = new HashSet<int>();
                neighbors[b] = nb;
            }
            na.Add(b);
            nb.Add(a);
        }
        for (int i = 0; i < N; ++i) {
            if (!neighbors.TryGetValue(i + 1, out var ni)) {
                ret[i] = 1;
                continue;
            }
            ret[i] = Colors
                .Except(ni.Select(n => ret[n - 1]))
                .FirstOrDefault();
        }
        return ret;
    }
}
// @lc code=end

