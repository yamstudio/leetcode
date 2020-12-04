/*
 * @lc app=leetcode id=1525 lang=csharp
 *
 * [1525] Number of Good Ways to Split a String
 */

using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public int NumSplits(string s) {
        int[] ls = Enumerable.Repeat(-1, 26).ToArray(), rs = new int[26];
        int k = s.Length, lc = 0, rc = 0, li = 0, ri;
        for (int i = 0; i < k; ++i) {
            int c = (int)s[i] - (int)'a';
            if (ls[c] == -1) {
                ++rc;
                ls[c] = i;
            }
            rs[c] = i;
        }
        while (lc < rc) {
            int c = (int)s[li] - (int)'a';
            if (ls[c] == li) {
                ++lc;
            }
            if (rs[c] == li) {
                --rc;
            }
            ++li;
        }
        ri = li;
        while (lc == rc) {
            int c = (int)s[ri] - (int)'a';
            if (ls[c] == ri) {
                ++lc;
            }
            if (rs[c] == ri) {
                --rc;
            }
            ++ri;
        }
        return ri - li;
    }
}
// @lc code=end

