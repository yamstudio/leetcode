/*
 * @lc app=leetcode id=1 lang=csharp
 *
 * [1] Two Sum
 */

 using System.Collections.Generic;
public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; ++i) {
            if (dict.ContainsKey(target - nums[i])) {
                return new int[] { dict[target - nums[i]], i };
            }
            dict[nums[i]] = i;
        }
        return null;
    }
}

