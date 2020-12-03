/*
 * @lc app=leetcode id=1520 lang=csharp
 *
 * [1520] Maximum Number of Non-Overlapping Substrings
 */

using System;
using System.Collections.Generic;
using System.Linq;

// @lc code=start
public class Solution {
    public IList<string> MaxNumOfSubstrings(string s) {
        int[] ls = Enumerable.Repeat(int.MaxValue, 26).ToArray(), rs = Enumerable.Repeat(int.MinValue, 26).ToArray();
        int n = s.Length, right = -1;
        var ret = new List<string>();
        for (int i = 0; i < n; ++i) {
            int c = (int)s[i] - (int)'a';
            ls[c] = Math.Min(ls[c], i);
            rs[c] = i;
        }
        for (int i = 0; i < n; ++i) {
            int c = (int)s[i] - (int)'a';
            if (i != ls[c]) {
                continue;
            }
            bool flag = false;
            int nr = rs[c];
            for (int j = i + 1; j < nr; ++j) {
                if (ls[(int)s[j] - (int)'a'] < i) {
                    flag = true;
                    break;
                }
                nr = Math.Max(nr, rs[(int)s[j] - (int)'a']);
            }
            if (flag) {
                continue;
            }
            if (i <= right) {
                ret.RemoveAt(ret.Count - 1);
            }
            ret.Add(s.Substring(i, nr - i + 1));
            right = nr;
        }
        return ret;
    }
}
// @lc code=end

