/*
 * @lc app=leetcode id=1431 lang=csharp
 *
 * [1431] Kids With the Greatest Number of Candies
 */

using System.Linq;

// @lc code=start
public class Solution {
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies) {
        var max = candies.Max();
        return candies
            .Select(c => max - c <= extraCandies)
            .ToList();
    }
}
// @lc code=end

