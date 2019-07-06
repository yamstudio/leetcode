/*
 * @lc app=leetcode id=44 lang=csharp
 *
 * [44] Wildcard Matching
 */
public class Solution {
    public bool IsMatch(string s, string p) {
        bool[,] dp = new bool[s.Length + 1, p.Length + 1];
        dp[0, 0] = true;
        for (int j = 1; j <= p.Length; ++j) {
            dp[0, j] = p[j - 1] == '*' && dp[0, j - 1];
        }
        for (int i = 1; i <= s.Length; ++i) {
            for (int j = 1; j <= p.Length; ++j) {
                dp[i, j] = (p[j - 1] == '*' && (dp[i - 1, j] || dp[i, j - 1])) || (dp[i - 1, j - 1] && (p[j - 1] == '?' || p[j - 1] == s[i - 1]));
            }
        }
        return dp[s.Length, p.Length];
    }
}

