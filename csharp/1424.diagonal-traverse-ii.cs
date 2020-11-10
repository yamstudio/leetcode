/*
 * @lc app=leetcode id=1424 lang=csharp
 *
 * [1424] Diagonal Traverse II
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int[] FindDiagonalOrder(IList<IList<int>> nums) {
        var ret = new List<IList<int>>();
        int m = nums.Count;
        for (int i = 0; i < m; ++i) {
            var row = nums[i];
            int n = row.Count, t = i + n;
            while (ret.Count < t) {
                ret.Add(new List<int>());
            }
            for (int j = 0; j < n; ++j) {
                ret[i + j].Add(row[j]);
            }
        }
        return ret
            .SelectMany(d => d.Reverse())
            .ToArray();
    }
}
// @lc code=end

