/*
 * @lc app=leetcode id=1177 lang=csharp
 *
 * [1177] Can Make Palindrome from Substring
 */

using System.Collections.Generic;

// @lc code=start
public class Solution {
    public IList<bool> CanMakePaliQueries(string s, int[][] queries) {
        int n = s.Length;
        var count = new int[n + 1, 26];
        var ret = new List<bool>(queries.Length);
        for (int i = 0; i < n; ++i) {
            for (int j = 0; j < 26; ++j) {
                count[i + 1, j] = count[i, j];
            }
            ++count[i + 1, (int)s[i] - (int)'a'];
        }
        foreach (var query in queries) {
            int l = query[0], r = query[1], k = query[2], d = 0;
            for (int j = 0; j < 26; ++j) {
                if ((count[r + 1, j] - count[l, j]) % 2 != 0) {
                    ++d;
                }
            }
            ret.Add(k >= d / 2);
        }
        return ret;
    }
}
// @lc code=end

