/*
 * @lc app=leetcode id=442 lang=csharp
 *
 * [442] Find All Duplicates in an Array
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> FindDuplicates(int[] nums) {
        int n = nums.Length;
        IList<int> ret = new List<int>();
        for (int i = 0; i < n; ++i) {
            int num = nums[i];
            if (num != nums[num - 1]) {
                nums[i] = nums[num - 1];
                nums[num - 1] = num;
                --i;
            }
        }
        for (int i = 0; i < n; ++i) {
            int num = nums[i];
            if (i != num - 1) {
                ret.Add(num);
            }
        }
        return ret;
    }
}

