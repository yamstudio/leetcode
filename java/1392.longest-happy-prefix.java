/*
 * @lc app=leetcode id=1392 lang=java
 *
 * [1392] Longest Happy Prefix
 */

// @lc code=start
class Solution {
    public String longestPrefix(String s) {
        int n = s.length(), i = 1, j = 0;
        int[] dp = new int[n];
        while (i < n) {
            if (s.charAt(i) == s.charAt(j)) {
                dp[i++] = ++j;
            } else if (j > 0) {
                j = dp[j - 1];
            } else {
                ++i;
            }
        }
        return s.substring(0, j);
    }
}
// @lc code=end

