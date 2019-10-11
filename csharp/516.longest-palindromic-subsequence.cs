/*
 * @lc app=leetcode id=516 lang=csharp
 *
 * [516] Longest Palindromic Subsequence
 */

using System.Linq;

// @lc code=start
public class Solution {
    public int LongestPalindromeSubseq(string s) {
        int n = s.Length;
        int[] dp = new int[n];
        for (int i = n - 1; i >= 0; --i) {
            dp[i] = 1;
            char curr = s[i];
            int m = 0;
            for (int j = i + 1; j < n; ++j) {
                int tmp = dp[j];
                if (curr == s[j]) {
                    dp[j] = m + 2;
                }
                m = Math.Max(m, tmp);
            }
        }
        return dp.Max();
    }
}
// @lc code=end

