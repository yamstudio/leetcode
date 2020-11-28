/*
 * @lc app=leetcode id=1503 lang=csharp
 *
 * [1503] Last Moment Before All Ants Fall Out of a Plank
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int GetLastMoment(int n, int[] left, int[] right) {
        return right
            .Select(r => n - r)
            .Concat(left)
            .Max();
    }
}
// @lc code=end

