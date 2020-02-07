/*
 * @lc app=leetcode id=823 lang=csharp
 *
 * [823] Binary Trees With Factors
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int NumFactoredBinaryTrees(int[] A) {
        int n = A.Length;
        var dp = new Dictionary<int, long>();
        Array.Sort(A);
        for (int i = 0; i < n; ++i) {
            int curr = A[i];
            long r = 1;
            for (int j = 0; j < i; ++j) {
                int a = A[j];
                long val = 0;
                if (curr % a != 0 || !dp.TryGetValue(curr / a, out val)) {
                    continue;
                }
                r = (r + dp[a] * val) % 1000000007;
            }
            dp[curr] = r;
        }
        return (int)(dp.Values.Sum() % 1000000007);
    }
}
// @lc code=end

