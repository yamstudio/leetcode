/*
 * @lc app=leetcode id=1238 lang=csharp
 *
 * [1238] Circular Permutation in Binary Representation
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> CircularPermutation(int n, int start) {
        return Enumerable
            .Range(0, (int)Math.Pow(2, (double)n))
            .Select(x => x ^ (x >> 1) ^ start)
            .ToList();
    }
}
// @lc code=end

