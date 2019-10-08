/*
 * @lc app=leetcode id=506 lang=csharp
 *
 * [506] Relative Ranks
 */

using System.Linq;

// @lc code=start
public class Solution {
    public string[] FindRelativeRanks(int[] nums) {
        return nums.Select((score, index) => (score, index)).OrderByDescending(tuple => tuple.score).Select((tuple, ranking) => (ranking == 0 ? "Gold Medal" : (ranking == 1 ? "Silver Medal" : (ranking == 2 ? "Bronze Medal" : (1 + ranking).ToString())), tuple.index)).OrderBy(tuple => tuple.index).Select(tuple => tuple.Item1).ToArray();
    }
}
// @lc code=end

