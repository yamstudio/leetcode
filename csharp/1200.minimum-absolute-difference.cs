/*
 * @lc app=leetcode id=1200 lang=csharp
 *
 * [1200] Minimum Absolute Difference
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public IList<IList<int>> MinimumAbsDifference(int[] arr) {
        int n = arr.Length, md = int.MaxValue;
        Array.Sort(arr);
        var ret = new List<IList<int>>();
        for (int i = 0; i < n - 1; ++i) {
            int a = arr[i], b = arr[i + 1], d = b - a;
            if (d < md) {
                md = d;
                ret.Clear();
                ret.Add(new List<int>() { a, b });
            } else if (d == md) {
                ret.Add(new List<int>() { a, b });
            }
        }
        return ret;
    }
}
// @lc code=end

