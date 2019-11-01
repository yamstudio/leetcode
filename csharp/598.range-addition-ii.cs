/*
 * @lc app=leetcode id=598 lang=csharp
 *
 * [598] Range Addition II
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int MaxCount(int m, int n, int[][] ops) {
        return ops.Aggregate((m, n), (pair, curr) => (Math.Min(pair.Item1, curr[0]), Math.Min(pair.Item2, curr[1])), pair => pair.Item1 * pair.Item2);
    }
}
// @lc code=end

