/*
 * @lc app=leetcode id=1703 lang=csharp
 *
 * [1703] Minimum Adjacent Swaps for K Consecutive Ones
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinMoves(int[] nums, int k) {
        var ones = nums.Select((n, i) => (Value: n, Index: (long)i)).Where(x => x.Value == 1).Select(x => x.Index).ToList();
        int n = ones.Count;
        var prefixSums = new List<long>(n + 1);
        long ret = long.MaxValue;
        prefixSums.Add(0);
        for (int i = 0; i < n; ++i) {
            prefixSums.Add(prefixSums[i] + ones[i]);
        }
        for (int i = 0; i + k - 1 < n; ++i) {
            ret = Math.Min(ret, (prefixSums[i + k] - prefixSums[i + k / 2]) - (prefixSums[i + (k + 1) / 2] - prefixSums[i]) - ((k + 1) / 2) * (k / 2));
        }
        return (int)ret;
    }
}
// @lc code=end

