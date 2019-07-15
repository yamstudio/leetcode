/*
 * @lc app=leetcode id=87 lang=csharp
 *
 * [87] Scramble String
 */
public class Solution {
    public bool IsScramble(string s1, string s2) {
        int n = s1.Length;
        if (n != s2.Length) {
            return false;
        }
        bool[,,] dp = new bool[n, n, n];
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < n; ++j) {
                dp[i, j, 0] = s1[i] == s2[j];
            }
        }
        for (int len = 1; len < n; ++len) {
            for (int i = 0; i < n - len; ++i) {
                for (int j = 0; j < n - len; ++j) {
                    for (int leftLen = 0; leftLen < len; ++leftLen) {
                        if ((dp[i, j, leftLen] && dp[i + leftLen + 1, j + leftLen + 1, len - 1 - leftLen]) || (dp[i, j + len - leftLen, leftLen] && dp[i + leftLen + 1, j, len - 1 - leftLen])) {
                            dp[i, j, len] = true;
                            break;
                        }
                    }
                }
            }
        }
        return dp[0, 0, n - 1];
    }
}

