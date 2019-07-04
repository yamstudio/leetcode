/*
 * @lc app=leetcode id=32 lang=csharp
 *
 * [32] Longest Valid Parentheses
 */
public class Solution {
    public int LongestValidParentheses(string s) {
        int[] dp = new int[s.Length + 1];
        int ret = 0;
        dp[0] = 0;
        for (int i = 1; i <= s.Length; ++i) {
            if (s[i - 1] == '(') {
                dp[i] = 0;
            } else {
                int left = i - dp[i - 1] - 2;
                if (left < 0 || s[left] == ')') {
                    dp[i] = 0;
                } else {
                    dp[i] = 2 + dp[i - 1] + dp[left];
                    ret = ret > dp[i] ? ret : dp[i];
                }
            }
        }
        return ret;
    }
}

