/*
 * @lc app=leetcode id=46 lang=csharp
 *
 * [46] Permutations
 */

using System.Collections.Generic;

public class Solution {

    private void PermuteDFS(int[] nums, ISet<int> used, IList<IList<int>> ret, IList<int> curr) {
        if (used.Count == nums.Length) {
            ret.Add(new List<int>(curr));
            return;
        }
        for (int i = 0; i < nums.Length; ++i) {
            if (used.Contains(i)) {
                continue;
            }
            used.Add(i);
            curr.Add(nums[i]);
            PermuteDFS(nums, used, ret, curr);
            curr.RemoveAt(curr.Count - 1);
            used.Remove(i);
        }
    }

    public IList<IList<int>> Permute(int[] nums) {
        IList<IList<int>> ret = new List<IList<int>>();
        PermuteDFS(nums, new HashSet<int>(), ret, new List<int>());
        return ret;
    }
}

