/*
 * @lc app=leetcode id=1668 lang=csharp
 *
 * [1668] Maximum Repeating Substring
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int MaxRepeating(string sequence, string word) {
        int m = sequence.Length, n = word.Length;
        if (n > m) {
            return 0;
        }
        string pat = string.Concat(Enumerable.Repeat(word, m / n).Append("$"));
        int l = 0, ret = 0, p = pat.Length;
        int[] lps = new int[p];
        for (int i = 1; i < p; ++i) {
            while (l > 0 && pat[i] != pat[l]) {
                l = lps[l - 1];
            }
            if (pat[i] == pat[l]) {
                ++l;
            }
            lps[i] = l;
        }
        l = 0;
        for (int i = 0; i < m; ++i) {
            while (l > 0 && sequence[i] != pat[l]) {
                l = lps[l - 1];
            }
            if (sequence[i] == pat[l]) {
                ++l;
            }
            ret = Math.Max(l / n, ret);
        }
        return ret;
    }
}
// @lc code=end

