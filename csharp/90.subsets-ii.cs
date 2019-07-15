/*
 * @lc app=leetcode id=90 lang=csharp
 *
 * [90] Subsets II
 */

using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> SubsetsWithDup(int[] nums) {
        var ret = new List<IList<int>>();
        ret.Add(new List<int>(0));
        if (nums.Length == 0) {
            return ret;
        }
        Array.Sort(nums);
        int size = 1, prev = nums[0];
        for (int i = 0; i < nums.Length; ++i) {
            if (prev != nums[i]) {
                prev = nums[i];
                size = ret.Count;
            }
            int currSize = ret.Count;
            for (int j = currSize - size; j < currSize; ++j) {
                var add = new List<int>(ret[j]);
                add.Add(nums[i]);
                ret.Add(add);
            }
        }
        return ret;
    }
}

