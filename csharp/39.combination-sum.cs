/*
 * @lc app=leetcode id=39 lang=csharp
 *
 * [39] Combination Sum
 */

using System.Collections.Generic;

public class Solution {
    private void CombinationSumDFS(int[] candidates, int target, int start, IList<IList<int>> ret, IList<int> curr) {
        if (target < 0) {
            return;
        }
        if (target == 0) {
            ret.Add(new List<int>(curr));
        }
        for (int i = start; i < candidates.Length; ++i) {
            curr.Add(candidates[i]);
            CombinationSumDFS(candidates, target - candidates[i], i, ret, curr);
            curr.RemoveAt(curr.Count - 1);
        }
    }

    public IList<IList<int>> CombinationSum(int[] candidates, int target) {
        IList<IList<int>> ret = new List<IList<int>>();
        CombinationSumDFS(candidates, target, 0, ret, new List<int>());
        return ret;
    }
}

