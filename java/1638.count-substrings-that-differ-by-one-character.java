/*
 * @lc app=leetcode id=1638 lang=java
 *
 * [1638] Count Substrings That Differ by One Character
 */

// @lc code=start
class Solution {
    public int countSubstrings(String s, String t) {
        int ret = 0, m = s.length(), n = t.length();
        int[][][] dp = new int[2][n + 1][2];
        for (int i = 0; i < m; ++i) {
            char c = s.charAt(i);
            int[][] curr = dp[i % 2], prev = dp[1 - (i % 2)];
            for (int j = 0; j < n; ++j) {
                if (c == t.charAt(j)) {
                    curr[j + 1][0] = 1 + prev[j][0];
                    curr[j + 1][1] = prev[j][1];
                } else {
                    curr[j + 1][0] = 0;
                    curr[j + 1][1] = 1 + prev[j][0];
                }
                ret += dp[i % 2][j + 1][1];
            }
        }
        return ret;
    }
}
// @lc code=end

