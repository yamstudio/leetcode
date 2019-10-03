/*
 * @lc app=leetcode id=485 lang=csharp
 *
 * [485] Max Consecutive Ones
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int FindMaxConsecutiveOnes(int[] nums) {
        return nums.Aggregate((0, 0, 0), (tuple, num) => {
            if (num == 1) {
                return (1, tuple.Item2 + 1, Math.Max(tuple.Item2 + 1, tuple.Item3));
            }
            return (0, 0, tuple.Item3);
        }, tuple => tuple.Item3);
    }
}
// @lc code=end

