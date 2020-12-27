/*
 * @lc app=leetcode id=1632 lang=csharp
 *
 * [1632] Rank Transform of a Matrix
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {

    private static int FindRoot(int[] roots, int i) {
        return roots[i] == i ? i : roots[i] = FindRoot(roots, roots[i]);
    }

    public int[][] MatrixRankTransform(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;
        var ret = new int[m][];
        var ranks = new int[m + n];
        var sorted = matrix
            .SelectMany((r, i) => r.Select((x, j) => (Value: x, Row: i, Col: j)))
            .GroupBy(t => t.Value, (x, a) => a.ToArray())
            .OrderBy(a => a[0].Value)
            .ToArray();
        for (int i = 0; i < m; ++i) {
            ret[i] = new int[n];
        }
        foreach (var l in sorted) {
            int[] roots = Enumerable.Range(0, m + n).ToArray(), maxRanks = ranks.ToArray();
            foreach (var p in l) {
                int rr = FindRoot(roots, p.Row), cr = FindRoot(roots, p.Col + m);
                maxRanks[cr] = Math.Max(maxRanks[rr], maxRanks[cr]);
                roots[rr] = cr;
            }
            foreach (var p in l) {
                int r = 1 + maxRanks[FindRoot(roots, p.Row)];
                ranks[p.Row] = r;
                ranks[p.Col + m] = r;
                ret[p.Row][p.Col] = r;
            }
        }
        return ret;
    }
}
// @lc code=end

