/*
 * @lc app=leetcode id=1771 lang=java
 *
 * [1771] Maximize Palindrome Length From Subsequences
 */

// @lc code=start
class Solution {
    public int longestPalindrome(String word1, String word2) {
        int l1 = word1.length(), l2 = word2.length(), l = l1 + l2, ret = 0;
        int[][] dp = new int[l][l];
        for (int i = 0; i < l; ++i) {
            dp[i][i] = 1;
        }
        for (int sl = 2; sl <= l; ++sl) {
            for (int i = 0; i + sl <= l; ++i) {
                int j = i + sl - 1;
                char c1 = i >= l1 ? word2.charAt(i - l1) : word1.charAt(i), c2 = j >= l1 ? word2.charAt(j - l1) : word1.charAt(j);
                if (c1 != c2) {
                    dp[i][j] = Math.max(dp[i + 1][j], dp[i][j - 1]);
                    continue;
                }
                dp[i][j] = dp[i + 1][j - 1] + 2;
                if (i < l1 && j >= l1) {
                    ret = Math.max(ret, dp[i][j]);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

