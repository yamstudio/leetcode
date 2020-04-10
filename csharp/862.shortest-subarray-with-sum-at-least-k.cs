/*
 * @lc app=leetcode id=862 lang=csharp
 *
 * [862] Shortest Subarray with Sum at Least K
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int ShortestSubarray(int[] A, int K) {
        var sorted = new SortedSet<(int Sum, int Index)>();
        int sum = 0, n = A.Length, ret = int.MaxValue;
        sorted.Add((Sum: 0, Index: -1));
        for (int i = 0; i < n; ++i) {
            sum += A[i];
            var candidates = sorted.GetViewBetween((Sum: int.MinValue, Index: int.MinValue), (Sum: sum - K, Index: int.MaxValue)).ToList();
            foreach (var candidate in candidates) {
                ret = Math.Min(ret, i - candidate.Index);
                sorted.Remove(candidate);
            }
            sorted.Add((Sum: sum, Index: i));
        }
        return ret == int.MaxValue ? -1 : ret;
    }
}
// @lc code=end

