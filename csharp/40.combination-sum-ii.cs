/*
 * @lc app=leetcode id=40 lang=csharp
 *
 * [40] Combination Sum II
 */

using System.Collections.Generic;

public class Solution {
    private void CombinationSumDFS(int[] candidates, int target, int start, IList<IList<int>> ret, IList<int> curr) {
        if (target == 0) {
            ret.Add(new List<int>(curr));
        }
        if (target < 0 || start >= candidates.Length) {
            return;
        }
        for (int i = start; i < candidates.Length; ++i) {
            if (i > start && candidates[i] == candidates[i - 1]) {
                continue;
            }
            curr.Add(candidates[i]);
            CombinationSumDFS(candidates, target - candidates[i], i + 1, ret, curr);
            curr.RemoveAt(curr.Count - 1);
        }
    }

    public IList<IList<int>> CombinationSum2(int[] candidates, int target) {
        IList<IList<int>> ret = new List<IList<int>>();
        Array.Sort(candidates);
        CombinationSumDFS(candidates, target, 0, ret, new List<int>());
        return ret;
    }
}

