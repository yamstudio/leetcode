/*
 * @lc app=leetcode id=179 lang=csharp
 *
 * [179] Largest Number
 */

using System;

public class Solution {
    public string LargestNumber(int[] nums) {
        Array.Sort(nums, new Comparison<int>((a, b) => String.Concat(b, a).CompareTo(String.Concat(a, b))));
        return nums[0] == 0 ? "0" : String.Join("", nums);
    }
}

