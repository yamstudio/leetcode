/*
 * @lc app=leetcode id=522 lang=csharp
 *
 * [522] Longest Uncommon Subsequence II
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

    public int FindLUSlength(string[] strs) {
        ISet<string> one = new HashSet<string>(), multiple = new HashSet<string>();
        foreach (string s in strs) {
            if (one.Contains(s)) {
                one.Remove(s);
                multiple.Add(s);
            } else {
                if (!multiple.Contains(s)) {
                    one.Add(s);
                }
            }
        }

        foreach (string p in one.OrderByDescending(p => p.Length)) {
            if (!multiple.Any(s => isSubsequence(p, s))) {
                return p.Length;
            }
        }
        return -1;
    }
}
// @lc code=end

