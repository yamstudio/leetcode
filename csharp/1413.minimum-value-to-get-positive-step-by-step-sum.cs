/*
 * @lc app=leetcode id=1413 lang=csharp
 *
 * [1413] Minimum Value to Get Positive Step by Step Sum
 */

using System;

// @lc code=start
public class Solution {
    public int MinStartValue(int[] nums) {
        int acc = 0, min = int.MaxValue;
        foreach (var num in nums) {
            acc += num;
            min = Math.Min(acc, min);
        }
        return 1 - Math.Min(0, min);
    }
}
// @lc code=end

