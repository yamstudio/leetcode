/*
 * @lc app=leetcode id=462 lang=csharp
 *
 * [462] Minimum Moves to Equal Array Elements II
 */

using System;

public class Solution {
    public int MinMoves2(int[] nums) {
        Array.Sort(nums);
        int target = nums[nums.Length / 2], ret = 0;
        foreach (int num in nums) {
            ret += Math.Abs(num - target);
        }
        return ret;
    }
}

