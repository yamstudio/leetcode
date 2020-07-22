/*
 * @lc app=leetcode id=952 lang=csharp
 *
 * [952] Largest Component Size by Common Factor
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    
    private static int FindRoot(int[] roots, int x) {
        return roots[x] == x ? x : (roots[x] = FindRoot(roots, roots[x]));
    }

    public int LargestComponentSize(int[] A) {
        int m = A.Max();
        int[] roots = Enumerable.Range(0, m + 1).ToArray();
        foreach (int x in A) {
            for (int y = (int)Math.Sqrt((double)x); y >= 2; --y) {
                if (x % y == 0) {
                    roots[FindRoot(roots, x)] = roots[FindRoot(roots, y)];
                    roots[FindRoot(roots, x)] = roots[FindRoot(roots, x / y)];
                }
            }
        }
        return A
            .Select(x => FindRoot(roots, x))
            .GroupBy((int r) => r, (int r, IEnumerable<int> all) => all.Count())
            .Max();
    }
}
// @lc code=end

