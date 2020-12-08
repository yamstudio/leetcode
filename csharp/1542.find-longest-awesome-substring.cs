/*
 * @lc app=leetcode id=1542 lang=csharp
 *
 * [1542] Find Longest Awesome Substring
 */

using System;
using System.Linq;

// @lc code=start
public class Solution {
    public int LongestAwesome(string s) {
        int n = s.Length, acc = 0, ret = 0;
        int[] prefix = Enumerable.Repeat(n, 1024).Prepend(-1).ToArray();
        for (int i = 0; i < n; ++i) {
            acc ^= 1 << ((int)s[i] - (int)'0');
            ret = Math.Max(ret, i - prefix[acc]);
            for (int x = 0; x <= 9; ++x) {
                ret = Math.Max(ret, i - prefix[acc ^ (1 << x)]);
            }
            prefix[acc] = Math.Min(i, prefix[acc]);
        }
        return ret;
    }
}
// @lc code=end

