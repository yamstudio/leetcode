/*
 * @lc app=leetcode id=1278 lang=csharp
 *
 * [1278] Palindrome Partitioning III
 */

using System;

// @lc code=start
public class Solution {
    public int PalindromePartition(string s, int k) {
        int n = s.Length;
        int[,] cost = new int[n, n], dp = new int[k + 1, n];
        for (int len = 2; len <= n; ++len) {
            for (int i = 0; i + len <= n; ++i) {
                if (s[i] == s[len + i - 1]) {
                    cost[i, len + i - 1] = cost[i + 1, len + i - 2];
                } else {
                    cost[i, len + i - 1] = 1 + cost[i + 1, len + i - 2];
                }
            }
        }
        for (int i = 0; i < n; ++i) {
            dp[1, i] = cost[0, i];
        }
        for (int j = 2; j <= k; ++j) {
            for (int r = j - 1; r < n; ++r) {
                int min = r + 1;
                for (int l = j - 1; l <= r; ++l) {
                    min = Math.Min(min, dp[j - 1, l - 1] + cost[l, r]);
                }
                dp[j, r] = min;
            }
        }
        return dp[k, n - 1];
    }
}
// @lc code=end

