/*
 * @lc app=leetcode id=730 lang=csharp
 *
 * [730] Count Different Palindromic Subsequences
 */

// @lc code=start
public class Solution {
    public int CountPalindromicSubsequences(string S) {
        int n = S.Length;
        int[,] dp = new int[n, n];
        for (int i = 0; i < n; ++i) {
            dp[i, i] = 1;
        }
        for (int len = 1; len < n; ++len) {
            for (int i = 0; i + len < n; ++i) {
                char c = S[i];
                int j = i + len;
                if (S[j] != c) {
                    dp[i, j] = dp[i + 1, j] + dp[i, j - 1] - dp[i + 1, j - 1];
                } else {
                    int left = i + 1, right = j - 1;
                    while (left <= right && S[left] != c) {
                        ++left;
                    }
                    while (right >= left && S[right] != c) {
                        --right;
                    }
                    if (left > right) {
                        dp[i, j] = dp[i + 1, j - 1] * 2 + 2;
                    } else if (left == right) {
                        dp[i, j] = dp[i + 1, j - 1] * 2 + 1;
                    } else {
                        dp[i, j] = dp[i + 1, j - 1] * 2 - dp[left + 1, right - 1];
                    }
                }
                if (dp[i, j] < 0) {
                    dp[i, j] += 1000000007;
                } else {
                    dp[i, j] %= 1000000007;
                }
            }
        }
        return dp[0, n - 1];
    }
}
// @lc code=end

