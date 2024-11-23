/*
 * @lc app=leetcode id=940 lang=java
 *
 * [940] Distinct Subsequences II
 */

// @lc code=start

class Solution {
    public int distinctSubseqII(String s) {
        int n = s.length();
        int[][] dp = new int[2][n];
        int[] lastCount = new int[26];
        for (int i = 0; i < 26; ++i) {
            lastCount[i] = -1;
        }
        dp[1][0] = 1;
        lastCount[s.charAt(0) - 'a'] = 0;
        for (int i = 1; i < n; ++i) {
            dp[0][i] = (dp[0][i - 1] + dp[1][i - 1]) % 1000000007;
            int c = s.charAt(i) - 'a';
            int l = lastCount[c];
            if (l >= 0) {
                dp[1][i] = (dp[0][i] - l + 1000000007) % 1000000007;
            } else {
                dp[1][i] = (1 + dp[0][i]) % 1000000007;
            }
            lastCount[c] = dp[0][i];
        }
        return (dp[0][n - 1] + dp[1][n - 1]) % 1000000007;
    }
}
// @lc code=end

