/*
 * @lc app=leetcode id=1494 lang=csharp
 *
 * [1494] Parallel Courses II
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MinNumberOfSemesters(int n, int[][] dependencies, int k) {
        int t = 1 << n;
        int[] deps = new int[n], stateDeps = new int[t], dp = Enumerable.Repeat(n, t).ToArray();
        foreach (var d in dependencies) {
            int p = d[0] - 1, c = d[1] - 1;
            deps[c] |= 1 << p;
        }
        for (int i = 0; i < t; ++i) {
            for (int j = 0; j < n; ++j) {
                if ((i & (1 << j)) != 0) {
                    stateDeps[i] |= deps[j];
                }
            }
        }
        dp[0] = 0;
        for (int i = 0; i < t; ++i) {
            int taken = i ^ (t - 1);
            for (int j = i; j != 0; j = i & (j - 1)) {
                int tmp = j, count = 0;
                while (tmp != 0) {
                    if ((tmp & 1) == 1) {
                        ++count;
                    }
                    tmp >>= 1;
                }
                if (count > k || (taken & stateDeps[j]) != stateDeps[j]) {
                    continue;
                }
                dp[i] = Math.Min(dp[i], 1 + dp[i ^ j]);
            }
        }
        return dp[t - 1];
    }
}
// @lc code=end

