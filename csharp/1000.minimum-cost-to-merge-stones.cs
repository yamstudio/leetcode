/*
 * @lc app=leetcode id=1000 lang=csharp
 *
 * [1000] Minimum Cost to Merge Stones
 */

using System;

// @lc code=start
public class Solution {
    public int MergeStones(int[] stones, int K) {
        int n = stones.Length;
        if ((n - 1) % (K - 1) != 0) {
            return -1;
        }
        var sums = new int[n + 1];
        var dp = new int[n, n];
        for (int i = 0; i < n; ++i) {
            sums[i + 1] = sums[i] + stones[i];
            for (int j = 0; j < n; ++j) {
                if (j != i) {
                    dp[i, j] = 1000000000;
                }
            }
        }
        for (int len = 2; len <= n; ++len) {
            bool canMerge = (len - 1) % (K - 1) == 0;
            int end = n - len;
            for (int i = 0; i <= end; ++i) {
                int r = i + len - 1;
                for (int p = i; p < r; p += K - 1) {
                    dp[i, r] = Math.Min(dp[i, r], dp[i, p] + dp[p + 1, r]);
                }
                if (canMerge) {
                    dp[i, r] += sums[r + 1] - sums[i];
                }
            }
        }
        return dp[0, n - 1];
    }
}
// @lc code=end

