/*
 * @lc app=leetcode id=646 lang=csharp
 *
 * [646] Maximum Length of Pair Chain
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int FindLongestChain(int[][] pairs) {
        return pairs.OrderBy(p => p[1]).Aggregate((max: int.MinValue, ret: 0), (acc, pair) => pair[0] > acc.max ? (pair[1], acc.ret + 1) : acc, acc => acc.ret);
    }
}
// @lc code=end

