/*
 * @lc app=leetcode id=89 lang=csharp
 *
 * [89] Gray Code
 */

using System.Collections.Generic;

public class Solution {
    public IList<int> GrayCode(int n) {
        IList<int> ret = new List<int>();
        ret.Add(0);
        for (int i = 0; i < n; ++i) {
            int len = ret.Count, mask = 1 << i;
            for (int j = len - 1; j >= 0; --j) {
                ret.Add(ret[j] | mask);
            }
        }
        return ret;
    }
}

