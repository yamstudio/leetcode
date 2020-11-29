/*
 * @lc app=leetcode id=1509 lang=csharp
 *
 * [1509] Minimum Difference Between Largest and Smallest Value in Three Moves
 */

using System;

// @lc code=start
public class Solution {
    public int MinDifference(int[] nums) {
        int n = nums.Length;
        if (n <= 4) {
            return 0;
        }
        Array.Sort(nums);
        return Math.Min(
            nums[n - 4] - nums[0],
            Math.Min(
                nums[n - 3] - nums[1],
                Math.Min(
                    nums[n - 2] - nums[2],
                    nums[n - 1] - nums[3]
                )
            )
        );
    }
}
// @lc code=end

