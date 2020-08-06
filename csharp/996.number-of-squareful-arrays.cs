/*
 * @lc app=leetcode id=996 lang=csharp
 *
 * [996] Number of Squareful Arrays
 */

using System;

// @lc code=start
public class Solution {
    public int NumSquarefulPerms(int[] A) {
        int n = A.Length, m = 1 << n;
        var canPair = new bool[n, n];
        var dp = new int[m, n];
        Array.Sort(A);
        for (int i = 0; i < n; ++i) {
            for (int j = i + 1; j < n; ++j) {
                int sum = A[i] + A[j], q = (int)Math.Sqrt(sum);
                if (q * q == sum) {
                    canPair[i, j] = true;
                    canPair[j, i] = true;
                }
            }
        }
        for (int i = 0; i < n; ++i) {
            if (i > 0 && A[i] == A[i - 1]) {
                continue;
            }
            dp[1 << i, i] = 1;
        }
        for (int mask = 0; mask < m; ++mask) {
            for (int i = 0; i < n; ++i) {
                int v = dp[mask, i];
                if (v == 0) {
                    continue;
                }
                for (int j = 0; j < n; ++j) {
                    if (!canPair[i, j] || (mask & (1 << j)) != 0 || (j > 0 && A[j] == A[j - 1] && (mask & (1 << (j - 1))) == 0)) {
                        continue;
                    }
                    dp[mask | (1 << j), j] += v;
                }
            }
        }
        int ret = 0;
        for (int i = 0; i < n; ++i) {
            ret += dp[m - 1, i];
        }
        return ret;
    }
}
// @lc code=end

