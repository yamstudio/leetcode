/*
 * @lc app=leetcode id=78 lang=csharp
 *
 * [78] Subsets
 */

using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> Subsets(int[] nums) {
        IList<IList<int>> ret = new List<IList<int>>();
        ret.Add(new List<int>());
        foreach (int n in nums) {
            int len = ret.Count;
            for (int i = 0; i < len; ++i) {
                IList<int> set = ret[i];
                ret.Add(new List<int>(set));
                set.Add(n);
            }
        }
        return ret;
    }
}

