/*
 * @lc app=leetcode id=115 lang=csharp
 *
 * [115] Distinct Subsequences
 */
public class Solution {
    public int NumDistinct(string s, string t) {
        int n1 = s.Length, n2 = t.Length;
        if (n2 > n1) {
            return 0;
        }
        int[,] dp = new int[n2 + 1, n1 + 1];
        for (int j = 0; j <= n1; ++j) {
            dp[0, j] = 1;
        }
        for (int i = 1; i <= n2; ++i) {
            for (int j = 1; j <= n1; ++j) {
                dp[i, j] = dp[i, j - 1] + (s[j - 1] == t[i - 1] ? dp[i - 1, j - 1] : 0);
            }
        }
        return dp[n2, n1];
    }
}

