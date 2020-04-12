/*
 * @lc app=leetcode id=873 lang=csharp
 *
 * [873] Length of Longest Fibonacci Subsequence
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int LenLongestFibSubseq(int[] A) {
        int n = A.Length, ret = 0;
        int[,] dp = new int[n, n];
        var map = new Dictionary<int, int>();
        for (int i = 0; i < n; ++i) {
            int val = A[i];
            map[val] = i;
            for (int j = i - 1; j >= 0; --j) {
                int diff = val - A[j];
                if (2 * diff < val && map.TryGetValue(diff, out int k)) {
                    dp[i, j] = 1 + dp[j, k];
                    ret = Math.Max(ret, dp[i, j]);
                } else {
                    dp[i, j] = 2;
                }
            }
        }
        return ret > 2 ? ret : 0;
    }
}
// @lc code=end

