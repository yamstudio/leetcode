/*
 * @lc app=leetcode id=139 lang=csharp
 *
 * [139] Word Break
 */

using System.Collections.Generic;

public class Solution {
    public bool WordBreak(string s, IList<string> wordDict) {
        int n = s.Length;
        bool[] dp = new bool[n + 1];
        var set = new HashSet<string>(wordDict);
        dp[0] = true;
        for (int i = 1; i <= n; ++i) {
            for (int j = 0; j < i; ++j) {
                if (dp[j] && set.Contains(s.Substring(j, i - j))) {
                    dp[i] = true;
                    break;
                }
            }
        }
        return dp[n];
    }
}

