/*
 * @lc app=leetcode id=15 lang=csharp
 *
 * [15] 3Sum
 */

using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> ThreeSum(int[] nums) {
        IList<IList<int>> ret = new List<IList<int>>();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 2; ++i) {
            int left = i + 1, right = nums.Length - 1, v = nums[i];
            if (i > 0 && v == nums[i - 1]) {
                continue;
            }
            while (left < right) {
                int vl = nums[left], vr = nums[right], sum = vl + vr;
                if (sum == -v) {
                    ret.Add(new List<int>(new int[] { v, vl, vr }));
                    while (left < nums.Length && nums[left] == vl) {
                        ++left;
                    }
                    while (right > i && nums[right] == vr) {
                        --right;
                    }
                } else if (sum < -v) {
                    ++left;
                } else {
                    --right;
                }
            }
        }
        return ret;
    }
}

