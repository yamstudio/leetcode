/*
 * @lc app=leetcode id=219 lang=csharp
 *
 * [219] Contains Duplicate II
 */

using System.Collections.Generic;

public class Solution {
    public bool ContainsNearbyDuplicate(int[] nums, int k) {
        ++k;
        var set = new HashSet<int>(nums.Length);
        for (int i = 0; i < nums.Length; ++i) {
            int num = nums[i];
            if (i >= k) {
                set.Remove(nums[i - k]);
            }
            if (set.Contains(num)) {
                return true;
            }
            set.Add(num);
        }
        return false;
    }
}

