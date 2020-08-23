/*
 * @lc app=leetcode id=1051 lang=csharp
 *
 * [1051] Height Checker
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int HeightChecker(int[] heights) {
        return heights
            .OrderBy(x => x)
            .Zip(heights, (f, s) => f != s)
            .Count(d => d);
    }
}
// @lc code=end

