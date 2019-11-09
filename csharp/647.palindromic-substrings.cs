/*
 * @lc app=leetcode id=647 lang=csharp
 *
 * [647] Palindromic Substrings
 */

// @lc code=start
public class Solution {
    public int CountSubstrings(string s) {
        int n = s.Length, ret = 0;
        bool[,] dp = new bool[n, n];
        for (int i = n - 1; i >= 0; --i) {
            char curr = s[i];
            for (int j = i; j < n; ++j) {
                if (s[j] == curr && (j - i <= 2 || dp[i + 1, j - 1])) {
                    dp[i, j] = true;
                    ++ret;
                }
            }
        }
        return ret;
    }
}
// @lc code=end

