/*
 * @lc app=leetcode id=10 lang=csharp
 *
 * [10] Regular Expression Matching
 */
public class Solution {
    public bool IsMatch(string s, string p) {
        bool[,] dp = new bool[s.Length + 1, p.Length + 1];
        dp[0, 0] = true;
        for (int i = 0; i <= s.Length; ++i) {
            for (int j = 1; j <= p.Length; ++j) {
                dp[i, j] = (p[j - 1] == '*' && (dp[i, j - 2] || (i > 0 && dp[i - 1, j] && (p[j - 2] == '.' || p[j - 2] == s[i - 1])))) || (i > 0 && dp[i - 1, j - 1] && (p[j - 1] == '.' || p[j - 1] == s[i - 1]));
            }
        }
        return dp[s.Length, p.Length];
    }
}

