/*
 * @lc app=leetcode id=1128 lang=csharp
 *
 * [1128] Number of Equivalent Domino Pairs
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int NumEquivDominoPairs(int[][] dominoes) {
        return dominoes
            .Select(d => (Left: Math.Min(d[0], d[1]), Right: Math.Max(d[0], d[1])))
            .GroupBy(d => d, ((int Left, int Right) key, IEnumerable<(int Left, int Right)> all) => all.Count())
            .Sum(x => x * (x - 1) / 2);
    }
}
// @lc code=end

