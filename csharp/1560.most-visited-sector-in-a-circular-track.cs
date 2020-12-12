/*
 * @lc app=leetcode id=1560 lang=csharp
 *
 * [1560] Most Visited Sector in  a Circular Track
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<int> MostVisited(int n, int[] rounds) {
        int start = rounds[0], end = rounds[rounds.Length - 1];
        if (start <= end) {
            return Enumerable.Range(start, end - start + 1).ToList();
        }
        return Enumerable
            .Range(1, end)
            .Concat(Enumerable.Range(start, n - start + 1))
            .ToList();
    }
}
// @lc code=end

