/*
 * @lc app=leetcode id=1691 lang=csharp
 *
 * [1691] Maximum Height by Stacking Cuboids 
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int MaxHeight(int[][] cuboids) {
        int n = cuboids.Length, ret = 0;
        int[] dp = new int[n];
        foreach (var cuboid in cuboids) {
            Array.Sort(cuboid);
        }
        Array.Sort(cuboids, Comparer<int[]>.Create((a, b) => {
            if (a[0] != b[0]) {
                return a[0].CompareTo(b[0]);
            }
            if (a[1] != b[1]) {
                return a[1].CompareTo(b[1]);
            }
            return a[2].CompareTo(b[2]);
        }));
        for (int i = 0; i < n; ++i) {
            var curr = cuboids[i];
            dp[i] = curr[2];
            for (int j = 0; j < i; ++j) {
                var prev = cuboids[j];
                if (prev[0] <= curr[0] && prev[1] <= curr[1] && prev[2] <= curr[2]) {
                    dp[i] = Math.Max(dp[i], curr[2] + dp[j]);
                }
            }
            ret = Math.Max(ret, dp[i]);
        }
        return ret;
    }
}
// @lc code=end

