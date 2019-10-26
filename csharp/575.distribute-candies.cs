/*
 * @lc app=leetcode id=575 lang=csharp
 *
 * [575] Distribute Candies
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int DistributeCandies(int[] candies) {
        return Math.Min(candies.Length / 2, (new HashSet<int>(candies)).Count);
    }
}
// @lc code=end

