/*
 * @lc app=leetcode id=97 lang=csharp
 *
 * [97] Interleaving String
 */
public class Solution {
    public bool IsInterleave(string s1, string s2, string s3) {
        int n1 = s1.Length, n2 = s2.Length;
        if (s3.Length != n1 + n2) {
            return false;
        }
        bool[,] dp = new bool[n1 + 1, n2 + 1];
        dp[0, 0] = true;
        for (int i = 1; i <= n1; ++i) {
            dp[i, 0] = dp[i - 1, 0] && s3[i - 1] == s1[i - 1];
        }
        for (int j = 1; j <= n2; ++j) {
            dp[0, j] = dp[0, j - 1] && s3[j - 1] == s2[j - 1];
        }
        for (int i =  1; i <= n1; ++i) {
            for (int j = 1; j <= n2; ++j) {
                dp[i, j] = (dp[i - 1, j] && s1[i - 1] == s3[i + j - 1]) || (dp[i, j - 1] && s2[j - 1] == s3[i + j  - 1]);
            }
        }
        return dp[n1, n2];
    }
}

