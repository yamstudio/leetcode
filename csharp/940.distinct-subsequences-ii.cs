/*
 * @lc app=leetcode id=940 lang=csharp
 *
 * [940] Distinct Subsequences II
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public int DistinctSubseqII(string S) {
        int n = S.Length;
        int[,] dp = new int[2, n];
        var map = new Dictionary<char, int>();
        dp[1, 0] = 1;
        map[S[0]] = 0;
        for (int i = 1; i < n; ++i) {
            char c = S[i];
            dp[0, i] = (dp[0, i - 1] + dp[1, i - 1]) % 1000000007;
            if (map.TryGetValue(c, out int p)) {
                dp[1, i] = (1000000007 + dp[0, i] - p) % 1000000007;
            } else {
                dp[1, i] = (1 + dp[0, i]) % 1000000007;
            }
            map[c] = dp[0, i];
        }
        return (dp[0, n - 1] + dp[1, n - 1]) % 1000000007;
    }
}
// @lc code=end

