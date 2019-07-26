/*
 * @lc app=leetcode id=132 lang=csharp
 *
 * [132] Palindrome Partitioning II
 */
public class Solution {
    public int MinCut(string s) {
        int n = s.Length;
        if (n == 0) {
            return 0;
        }
        int[] dp = new int[n + 1];
        dp[0] = -1;
        for (int i = 1; i <= n; ++i) {
            dp[i] = n;
        }
        for (int i = 0; i < n; ++i) {
            for (int len = 0; i - len >= 0 && i + len < n && s[i - len] == s[i + len]; ++len) {
                dp[i + len + 1] = Math.Min(dp[i + len + 1], 1 + dp[i - len]);
            }
            for (int len = 0; i - len >= 0 && i + len + 1 < n && s[i - len] == s[i + len  + 1]; ++len) {
                dp[i + len + 2] = Math.Min(dp[i + len + 2], 1 + dp[i - len]);
            }
        }
        return dp[n];
    }
}

