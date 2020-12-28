/*
 * @lc app=leetcode id=1638 lang=csharp
 *
 * [1638] Count Substrings That Differ by One Character
 */

// @lc code=start
public class Solution {
    public int CountSubstrings(string s, string t) {
        int m = s.Length, n = t.Length, ret = 0;
        int[,,] dp = new int[m + 1, n + 1, 2];
        for (int sd = 0; sd < m; ++sd) {
            for (int td = 0; td < n; ++td) {
                if (s[sd] == t[td]) {
                    dp[sd + 1, td + 1, 0] = 1 + dp[sd, td, 0];
                }
                if (s[m - 1 - sd] == t[n - 1 - td]) {
                    dp[m - 1 - sd, n - 1 - td, 1] = 1 + dp[m - sd, n - td, 1];
                }
            }
        }
        for (int i = 0; i < m; ++i) {
            for (int j = 0; j < n; ++j) {
                if (s[i] != t[j]) {
                    ret += (1 + dp[i, j, 0]) * (1 + dp[i + 1, j + 1, 1]);
                }
            }
        }
        return ret;
    }
}
// @lc code=end

