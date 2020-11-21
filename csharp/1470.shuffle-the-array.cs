/*
 * @lc app=leetcode id=1470 lang=csharp
 *
 * [1470] Shuffle the Array
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int[] Shuffle(int[] nums, int n) {
        return nums
            .Take(n)
            .Zip(nums.Skip(n), (a, b) => new[] { a, b })
            .SelectMany(t => t)
            .ToArray();
    }
}
// @lc code=end

