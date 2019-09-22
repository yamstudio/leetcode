/*
 * @lc app=leetcode id=448 lang=csharp
 *
 * [448] Find All Numbers Disappeared in an Array
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> FindDisappearedNumbers(int[] nums) {
        IList<int> ret = new List<int>();
        int n = nums.Length;
        for (int i = 0; i < n; ++i) {
            int num = nums[i];
            while (nums[num - 1] != num) {
                nums[i] = nums[num - 1];
                nums[num - 1] = num;
                num = nums[i];
            }
        }
        for (int i = 0; i < n; ++i) {
            int num = nums[i];
            if (num != i + 1) {
                ret.Add(i + 1);
            }
        }
        return ret;
    }
}

