/*
 * @lc app=leetcode id=47 lang=csharp
 *
 * [47] Permutations II
 */

using System.Collections.Generic;

public class Solution {

    private void PermuteUniqueDFS(int[] nums, ISet<int> used, IList<IList<int>> ret, IList<int> curr) {
        if (used.Count == nums.Length) {
            ret.Add(new List<int>(curr));
            return;
        }
        for (int i = 0; i < nums.Length; ++i) {
            if (used.Contains(i) || (i > 0 && nums[i] == nums[i - 1] && !used.Contains(i - 1))) {
                continue;
            }
            used.Add(i);
            curr.Add(nums[i]);
            PermuteUniqueDFS(nums, used, ret, curr);
            curr.RemoveAt(curr.Count - 1);
            used.Remove(i);
        }
    }

    public IList<IList<int>> PermuteUnique(int[] nums) {
        IList<IList<int>> ret = new List<IList<int>>();
        Array.Sort(nums);
        PermuteUniqueDFS(nums, new HashSet<int>(), ret, new List<int>());
        return ret;
    }
}

