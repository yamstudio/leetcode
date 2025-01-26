/*
 * @lc app=leetcode id=1278 lang=java
 *
 * [1278] Palindrome Partitioning III
 */

// @lc code=start
class Solution {
    public int palindromePartition(String s, int k) {
        int n = s.length();
        int[][] cost = new int[n][n];
        for (int len = 2; len <= n; ++len) {
            for (int start = 0; start + len - 1 < n; ++start) {
                int end = start + len - 1;
                if (s.charAt(start) != s.charAt(end)) {
                    cost[start][end] = 1 + cost[start + 1][end - 1];
                } else {
                    cost[start][end] = cost[start + 1][end - 1];
                }
            }
        }
        int[][] dp = new int[k + 1][n];
        for (int end = 0; end < n; ++end) {
            dp[1][end] = cost[0][end];
        }
        for (int parts = 2; parts <= k; ++parts) {
            for (int end = parts - 1; end < n; ++end) {
                dp[parts][end] = end + 1;
                for (int start = parts - 1; start <= end; ++start) {
                    dp[parts][end] = Math.min(dp[parts][end], dp[parts - 1][start - 1] + cost[start][end]);
                }
            }
        }
        return dp[k][n - 1];
    }
}
// @lc code=end

