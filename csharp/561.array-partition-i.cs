/*
 * @lc app=leetcode id=561 lang=csharp
 *
 * [561] Array Partition I
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int ArrayPairSum(int[] nums) {
        return nums.OrderBy(num => num).Where((num, i) => i % 2 == 0).Sum();
    }
}
// @lc code=end

