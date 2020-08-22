/*
 * @lc app=leetcode id=1048 lang=csharp
 *
 * [1048] Longest String Chain
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {

    private static bool IsChain(string shorter, string longer) {
        int m = shorter.Length, n = longer.Length, i = 0, j = 0;
        if (m != n - 1) {
            return false;
        }
        while (i < m && j < n && i >= j - 1) {
            if (shorter[i] == longer[j]) {
                ++i;
                ++j;
            } else {
                ++j;
            }
        }
        return i == m;
    }

    public int LongestStrChain(string[] words) {
        var ws = words.Distinct().ToHashSet();
        var groups = ws
            .GroupBy(word => word.Length, (int length, IEnumerable<string> all) => all.ToArray())
            .OrderBy(t => t[0].Length)
            .ToArray();
        var dp = ws
            .ToDictionary(word => word, word => 1);
        int ret = 1, n = groups.Length;
        for (int i = 0; i < n - 1; ++i) {
            var gc = groups[i];
            var gn = groups[i + 1];
            if (gc[0].Length != gn[0].Length - 1) {
                continue;
            }
            foreach (string curr in gc) {
                foreach (string next in gn) {
                    if (IsChain(curr, next)) {
                        int v = Math.Max(dp[curr] + 1, dp[next]);
                        dp[next] = v;
                        ret = Math.Max(v, ret);
                    }
                }
            }
        }
        return ret;
    }
}
// @lc code=end

