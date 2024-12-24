/*
 * @lc app=leetcode id=1092 lang=java
 *
 * [1092] Shortest Common Supersequence 
 */

// @lc code=start

class Solution {
    public String shortestCommonSupersequence(String str1, String str2) {
        int m = str1.length(), n = str2.length();
        int[][] dp = new int[m + 1][n + 1];
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (str1.charAt(i) == str2.charAt(j)) {
                    dp[i + 1][j + 1] = 1 + dp[i][j]; 
                } else {
                    dp[i + 1][j + 1] = Math.max(dp[i][j + 1], dp[i + 1][j]);
                }
            }
        }
        StringBuilder sb = new StringBuilder(m + n - dp[m][n]);
        while (m > 0 || n > 0) {
            if (m <= 0) {
                sb.append(str2.charAt(--n));
                continue;
            }
            if (n <= 0) {
                sb.append(str1.charAt(--m));
                continue;
            }
            if (str1.charAt(m - 1) == str2.charAt(n - 1)) {
                --m;
                --n;
                sb.append(str1.charAt(m));
                continue;
            }
            if (dp[m][n] == dp[m - 1][n]) {
                sb.append(str1.charAt(--m));
            } else {
                sb.append(str2.charAt(--n));
            }
        }
        return sb.reverse().toString();
    }
}
// @lc code=end

