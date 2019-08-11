/*
 * @lc app=leetcode id=216 lang=csharp
 *
 * [216] Combination Sum III
 */

using System.Collections.Generic;

public class Solution {
    private void CombinationSum3DFS(int k, int n, int curr, IList<int> list, IList<IList<int>> ret) {
        int count = list.Count;
        if (k == count) {
            if (n == 0) {
                ret.Add(new List<int>(list));
            }
            return;
        }
        for (int i = curr + 1; i < 10; ++i) {
            list.Add(i);
            CombinationSum3DFS(k, n - i, i, list, ret);
            list.RemoveAt(count);
        }
    }
    
    public IList<IList<int>> CombinationSum3(int k, int n) {
        var ret = new List<IList<int>>();
        CombinationSum3DFS(k, n, 0, new List<int>(), ret);
        return ret;
    }
}

