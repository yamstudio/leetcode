/*
 * @lc app=leetcode id=77 lang=csharp
 *
 * [77] Combinations
 */

using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> Combine(int n, int k) {
        if (k > n || k < 0) {
            return new List<IList<int>>();
        }
        IList<IList<int>> ret;
        if (k == 0) {
            ret = new List<IList<int>>();
            ret.Add(new List<int>());
            return ret;
        }
        ret = Combine(n - 1, k - 1);
        foreach (IList<int> comb in ret) {
            comb.Add(n);
        }
        foreach (IList<int> comb in Combine(n - 1, k)) {
            ret.Add(comb);
        }
        return ret;
    }
}

