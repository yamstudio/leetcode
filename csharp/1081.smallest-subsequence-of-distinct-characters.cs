/*
 * @lc app=leetcode id=1081 lang=csharp
 *
 * [1081] Smallest Subsequence of Distinct Characters
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public string SmallestSubsequence(string text) {
        var count = text
            .GroupBy(c => c, (char c, IEnumerable<char> all) => (Key: c, Value: all.Count()))
            .ToDictionary(t => t.Key, t => t.Value);
        var added = count.ToDictionary(t => t.Key, t => false);
        int i = 0, n = count.Count;
        char[] ret = new char[n];
        foreach (var c in text) {
            --count[c];
            if (added[c]) {
                continue;
            }
            while (i > 0 && ret[i - 1] > c && count[ret[i - 1]] > 0) {
                added[ret[i - 1]] = false;
                --i;
            }
            ret[i++] = c;
            added[c] = true;
            if (i == n) {
                break;
            }
        }
        return new string(ret);
    }
}
// @lc code=end

