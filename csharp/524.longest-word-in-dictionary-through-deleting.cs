/*
 * @lc app=leetcode id=524 lang=csharp
 *
 * [524] Longest Word in Dictionary through Deleting
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    private static bool isSubsequence(string p, string s) {
        int m = p.Length, n = s.Length, i = 0, j = 0;
        if (m > n) {
            return false;
        }
        while (i < m && j < n) {
            if (p[i] == s[j]) {
                ++i;
            }
            ++j;
        }
        return i == m;
    }

    public string FindLongestWord(string s, IList<string> d) {
        foreach (string p in d.OrderByDescending(p => p.Length).ThenBy(p => p)) {
            if (isSubsequence(p, s)) {
                return p;
            }
        }
        return "";
    }
}
// @lc code=end

