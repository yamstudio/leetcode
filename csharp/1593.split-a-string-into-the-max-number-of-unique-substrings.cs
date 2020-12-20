/*
 * @lc app=leetcode id=1593 lang=csharp
 *
 * [1593] Split a String Into the Max Number of Unique Substrings
 */

using System;
using System.Collections.Generic;

// @lc code=start
public class Solution {

    private static int MaxUniqueSplit(string s, int i, HashSet<string> set) {
        int n = s.Length;
        if (i == n) {
            return 0;
        }
        int ret = -1;
        for (int j = i; j < n; ++j) {
            string t = s.Substring(i, j - i + 1);
            if (set.Add(t)) {
                ret = Math.Max(ret, MaxUniqueSplit(s, j + 1, set) + 1);
                set.Remove(t);
            }
        }
        return ret;
    }

    public int MaxUniqueSplit(string s) {
        return MaxUniqueSplit(s, 0, new HashSet<string>());
    }
}
// @lc code=end

