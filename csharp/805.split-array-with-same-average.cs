/*
 * @lc app=leetcode id=805 lang=csharp
 *
 * [805] Split Array With Same Average
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public bool SplitArraySameAverage(int[] A) {
        int n = A.Length, sum = A.Sum(), m = n / 2;
        var lens = Enumerable
            .Range(1, m)
            .Where(x => sum * x % n == 0)
            .ToArray();
        if (lens.Length == 0) {
            return false;
        }
        var map = new HashSet<int>[m + 1];
        for (int i = 0; i <= m; ++i) {
            map[i] = new HashSet<int>();
        }
        map[0].Add(0);
        foreach (var num in A) {
            for (int i = m; i > 0; --i) {
                foreach (var prev in map[i - 1]) {
                    map[i].Add(prev + num);
                }
            }
        }
        return lens.Any(x => map[x].Contains(sum * x / n));
    }
}
// @lc code=end

